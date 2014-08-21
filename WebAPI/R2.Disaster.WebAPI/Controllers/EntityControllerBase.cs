﻿using ExpressionSerialization;
using R2.Disaster.CoreEntities;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.Service;
using R2.Disaster.WebFramework.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Xml.Linq;

namespace R2.Disaster.WebAPI.Controllers
{
    /// <summary>
    /// 实体类控制器基类
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="U">实体主键类型</typeparam>
    public class EntityControllerBase<T>:ApiController
        where T: BaseEntity
    {
        private IEntityServiceBase<T> _domainServiceBase;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="domainServiceBase"></param>
        public EntityControllerBase(IEntityServiceBase<T> domainServiceBase)
        {
            this._domainServiceBase = domainServiceBase;
        }

        /// <summary>
        /// 通过主键编号查询
        /// <param name="id">主键编号</param>
        /// </summary>
        /// <returns></returns>
        public T Get([FromUri]object id)
        {
            int idNum = Int32.Parse(id.ToString());
            T entity = this._domainServiceBase.Get(idNum);
            return entity;
        }

        /// <summary>
        /// 更新，仅更新主实体，不会更新导航属性，性能高，推荐
        /// </summary>
        /// <param name="entity">需要更新的实体对象</param>
        [HttpPost]
        public void Update([FromBody]T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            this._domainServiceBase.UpdateAttached(entity);
        }

        /// <summary>
        ///更新， 除更新主实体外，还会更新导航属性及导航属性的导航属性（无限递归判定），性能较差
        /// </summary>
        /// <param name="entity"></param>
        [HttpPost]
        public void UpdateWithRelation([FromBody]T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            this._domainServiceBase.UpdateRelationAttached(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">需要删除的实体对象</param>
        [HttpPost]
        public void Delete([FromBody]T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            this._domainServiceBase.Delete(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">需要删除的实体对象的主键</param>
        [HttpGet]
        public void DeleteKey(object id)
        {
            if (id ==null)
                throw new Exception("参数不合法，没有这样的防灾预案编号");
            this._domainServiceBase.Delete(id);
        }

        /// <summary>
        /// 新增
        /// 被新增的实体，必须有其相对应的PhyGeoDiaster信息存在，且PrePlan的主键（外键）
        /// 必须同PhyGeoDiaster主键相同；
        /// 如果新增的PrePlan实体没有对应的PhyGeoDiaster，则应当调用PhyGeoDiaster的New接口
        /// 并给PhyGeoDiaster的PrePlan导航属性赋值，以完成在新增PrePlan的信息的同时，PhyGeoDiaster
        /// 物理点信息也同样有相应的信息
        /// </summary>
        /// <param name="entity">需要新增的实体</param>
        [HttpPost]
        public object New([FromBody]T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            this._domainServiceBase.New(entity);
            return entity.Id;
        }

        /// <summary>
        /// 新增（一组）
        /// </summary>
        /// <param name="entities">一组相关实体</param>
        [HttpPost]
        public List<Object> NewSet([FromBody] List<T> entities)
        {
            if (entities == null)
                throw new ArgumentException("entities");
            this._domainServiceBase.New(entities);
            List<Object> ids = new List<object>();
            foreach (var t in entities)
            {
                ids.Add(t.Id);
            }
            return ids;
        }

        ///// <summary>
        ///// 更新（一组）
        ///// </summary>
        ///// <param name="entities">一组相关实体</param>
        //[HttpPost]
        //public void UpdateSet([FromBody] List<T> entities)
        //{
        //    if (entities == null)
        //        throw new ArgumentException("entities");
        //    this._domainServiceBase.Update(entities);
        //}

        /// <summary>
        /// 删除（一组）
        /// </summary>
          /// <param name="entities">一组相关实体</param>
          [HttpPost]
          public void DeleteSet([FromBody] List<T> entities)
          {
              if (entities == null)
                  throw new ArgumentException("entities");
              this._domainServiceBase.Delete(entities);
          }

        /// <summary>
        /// 删除（一组）
        /// </summary>
        /// <param name="ids">一组实体的主键</param>
          [HttpPost]
          public void DeleteKeySet([FromBody] List<object> ids)
          {
              if (ids == null)
                  throw new ArgumentException("entities");
              this._domainServiceBase.Delete(ids);
          }

          dynamic FnGetDatabaseObjects(Type elementType)
          {
              return this._domainServiceBase.FindAll();
          }

         [HttpPost]
         [PagingFilterAttribute]
          public virtual IList<T> GetByExpression([FromBody]XElement x,[FromUri]int ps=10,[FromUri]int pn=1)
          {
              //TODO:后期回顾整理(重要)
              var creator = new QueryCreator(this.FnGetDatabaseObjects);

              var assemblies = new Assembly[]
            { 
                typeof(PhyGeoDisaster).Assembly,
                typeof(ExpressionType).Assembly, 
                typeof(IQueryable).Assembly,
                typeof(Enum).Assembly
            };
              var resolver = new TypeResolver(assemblies, new Type[] 
			{ 
                //typeof(PhyGeoDisaster),typeof(Enum)
			});

              CustomExpressionXmlConverter queryconverter = new QueryExpressionXmlConverter(creator, resolver);
              CustomExpressionXmlConverter knowntypeconverter = new KnownTypeExpressionXmlConverter(resolver);
              var serializer = new ExpressionSerializer(resolver, new CustomExpressionXmlConverter[] { queryconverter, knowntypeconverter });

              Expression e = serializer.Deserialize(x);
              MethodCallExpression m = (MethodCallExpression)e;
              LambdaExpression lambda = Expression.Lambda(m);
              Delegate fn = lambda.Compile();
              dynamic result = fn.DynamicInvoke(new object[0]);
              //dynamic array = Enumerable.ToArray(result);			
              var array = Enumerable.ToArray(Enumerable.Cast<T>(result));
   //           IList<PhyGeoDisasterSimplify> phyModels = Mapper.Map<IEnumerable<PhyGeoDisaster>,
   //IList<PhyGeoDisasterSimplify>>(array);
              return array;
          }
    }
}

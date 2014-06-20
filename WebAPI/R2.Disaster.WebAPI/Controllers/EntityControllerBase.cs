using R2.Disaster.Service.GeoDisaster;
using System;
using System.Web.Http;

namespace R2.Disaster.WebAPI.Controllers
{
    /// <summary>
    /// 实体类控制器基类
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="U">实体主键类型</typeparam>
    public class EntityControllerBase<T,U>:ApiController
        where T: class
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
        public T Get([FromUri]U id)
        {
            T entity = this._domainServiceBase.Get(id);
            return entity;
        }



        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">需要更新的实体对象</param>
        [HttpPost]
        public void Update([FromBody]T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            this._domainServiceBase.Update(entity);
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
        public void Delete(U id)
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
        public void New([FromBody]T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            this._domainServiceBase.New(entity);
        }
    }
}

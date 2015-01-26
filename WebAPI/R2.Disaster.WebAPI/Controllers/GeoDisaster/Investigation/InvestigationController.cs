using AutoMapper;
using Newtonsoft.Json;
using R2.Disaster.CoreEntities;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using R2.Disaster.Data;
using R2.Disaster.Service.GeoDisaster;
using R2.Disaster.Service.GeoDisaster.Investigation;
using R2.Disaster.WebAPI.Model;
using R2.Disaster.WebAPI.Model.Investigation;
using R2.Disaster.WebAPI.ServiceModel.GeoDisaster.Investigation;
using R2.Disaster.WebFramework.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace R2.Disaster.WebAPI.Controllers.GeoDisaster.Investigation
{
    /// <summary>
    /// 地质灾害综合信息服务
    /// </summary>
     [PagingFilterWithMapper(typeof(Comprehensive), typeof(ComprehensiveSimplify))]
    public class InvestigationController:PhyRelationEntityController<Comprehensive>
    {
        private IComprehensiveService _cpsService;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cpsService"></param>
        public InvestigationController(IComprehensiveService cpsService)
            :base(cpsService)
        {
            this._cpsService = cpsService;
            //Mapper.CreateMap<Comprehensive, ComprehensiveModel>();
            //Mapper.CreateMap<ComprehensiveModel, Comprehensive>();
        }

        /// <summary>
        /// 通过统一编号查询灾害点地质调查综合信息
        /// </summary>
        /// <param name="uid">统一编号</param>
        /// <returns>地质灾害完整信息</returns>
        public Comprehensive GetCompleteByUId(string uid)
        {
            if (String.IsNullOrEmpty(uid))
                throw new Exception("灾害点的统一编号不能为Null或者空字符串");
            IQueryable<Comprehensive> g=_cpsService.GetByUnifiedId(uid);
           
            //JsonSerializerSettings a = new JsonSerializerSettings();
            //a.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //string s = JsonConvert.SerializeObject(g, a);
            HomeController.SendMessage("Investigation", "Invoke");
            return g.FirstOrDefault();
        }

        /// <summary>
        /// 通过关键字检索灾害点简要信息，关键字将检索灾害点名称、灾害点地理位置、统一编号
        /// </summary>
        /// <param name="keyWord">关键字</param>
        /// <returns>符合条件的调查表简要信息</returns>
   //    [PagingFilterWithMapper(typeof(Comprehensive), typeof(ComprehensiveSimplify))]
        public IQueryable<Comprehensive> GetByKeyWord(string keyWord, int ps = 10, int pn = 1)
        {
            if (String.IsNullOrEmpty(keyWord))
                throw new Exception("查询的关键字不允许是类型“null”或者空字符串");
            IQueryable<Comprehensive> comprehensives = this._cpsService.GetByKeyWord(keyWord);
            //IList<ComprehensiveSimplify> cpsModels = Mapper.Map<IQueryable<Comprehensive>,
            //    IList<ComprehensiveSimplify>>(comprehensives);
            return comprehensives;
        }

        /// <summary>
        /// 空间“圆”查询
        /// </summary>
        /// <param name="x">圆心X</param>
        /// <param name="y">圆心Y</param>
        /// <param name="radius">半径</param>
        /// <returns>符合条件的实体信息</returns>
      
       public IQueryable<Comprehensive> GetByCircle(double x, double y, double radius, int ps = 10,
           int pn=1)
        {
            IQueryable<Comprehensive> Comprehensive = this._cpsService.GetByCircle(
                x, y, radius);
            //IList<ComprehensiveSimplify> cpsModels = Mapper.Map<IQueryable<Comprehensive>,
            //    IList<ComprehensiveSimplify>>(comprehensives);
            return Comprehensive;
        }

        /// <summary>
        /// 空间“矩形”查询
        /// </summary>
        /// <param name="x1">矩形左下角点X</param>
        /// <param name="x2">矩形右上角X</param>
        /// <param name="y1">矩形左下角Y</param>
        /// <param name="y2">矩形右上角Y</param>
        /// <returns>符合条件的实体信息</returns>
     //   [PagingFilterWithMapper(typeof(Comprehensive), typeof(ComprehensiveSimplify))]
        public IQueryable<Comprehensive> GetByRect(double x1, double x2, double y1, double y2,
            int ps=10,int pn=1)
        {
            IQueryable<Comprehensive> comprehensives = this._cpsService.GetByRect(
                x1, x2, y1, y2);
            //IList<ComprehensiveSimplify> cpsModels = Mapper.Map<IQueryable<Comprehensive>,
            //    IList<ComprehensiveSimplify>>(comprehensives);
            return comprehensives;
        }

        ///// <summary>
        ///// 通过主键编号精准查询唯一的灾害点地质调查完整实体
        ///// 请根据业务调用具体实体
        ///// </summary>
        ///// <param name="id">灾害点唯一编号</param>
        ///// <returns>灾害点完整信息</returns>
        //public Comprehensive Get(int id)
        //{
        //    if (id <= 0)
        //        throw new Exception("不存在这样的灾害点信息主键编号");
        //   Comprehensive g = _cpsService.Get(id);
        //   return g;
        //}

        /// <summary>
        /// 通过主键编号获取灾害点简要实体
        /// </summary>
        /// <param name="id">灾害点唯一编号</param>
        /// <returns></returns>
        public ComprehensiveSimplify GetById(int id)
        {
            if (id <= 0)
                throw new Exception("不存在这样的灾害点信息主键编号");
            Comprehensive g = _cpsService.Get(id);
            ComprehensiveSimplify c = Mapper.Map<ComprehensiveSimplify>(g);
            return c;
        }
              
        /// <summary>
        /// 通过行政区编码、灾害类型、险情大小、灾情大小查询灾害点简要信息（POST）
        /// </summary>
        ///<param name="condition">InvestigationCondition类型</param>
        /// <returns>地质调查实体简要信息</returns>
       [HttpPost]
     //  [PagingFilterWithMapper(typeof(Comprehensive), typeof(ComprehensiveSimplify))]
        public IQueryable<Comprehensive> GetByConditions([FromBody]InvestigationQueryCondition condition
           ,int ps=10,int pn=1)
        {
            IQueryable<Comprehensive> Comprehensive =
                this._cpsService.GetByConditions(condition.GbCodes, condition.SituationLevs
                , condition.DangerLevs, condition.Types);
            //IList<ComprehensiveSimplify> cpsModels = Mapper.Map<IQueryable<Comprehensive>,
            //IList<ComprehensiveSimplify>>(comprehensives);
            return Comprehensive;
        }

        /// <summary>
       ///  通过行政区编码、灾害类型、险情大小、灾情大小查询灾害点简要信息（Get）
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="gbcode">行政区编码</param>
        /// <param name="dangerLev">险情等级</param>
        /// <param name="situationLev">灾情等级</param>
       /// <returns>地质调查实体简要信息</returns>
 //       [PagingFilterWithMapper(typeof(Comprehensive), typeof(ComprehensiveSimplify))]
       public IQueryable<Comprehensive> GetByConditions(EnumGeoDisasterType? type = null,
           String gbcode = null, String dangerLev = null, String situationLev = null,int ps=1,int pn=10)
       {
           IQueryable<Comprehensive> Comprehensive =
               this._cpsService.GetByConditions(gbcode, situationLev, dangerLev, type);
           //IList<ComprehensiveSimplify> cpsModels = Mapper.Map<IQueryable<Comprehensive>,
           //IList<ComprehensiveSimplify>>(comprehensives);
           return Comprehensive;
       }
         /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
       public IList<Comprehensive> Comprehensives()
       {
           var lists = _cpsService.FindAll().ToList();
           lists.ForEach(m =>
           {
               m.PhyGeoDisaster = null;
           });
           return lists;
       }

    }
}

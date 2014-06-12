using AutoMapper;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.Service.GeoDisaster;
using R2.Disaster.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace R2.Disaster.WebAPI.Controllers.GeoDisaster
{
    /// <summary>
    /// 地质灾害物理点实体控制器
    /// </summary>
    public class PhyGeoDisasterController : ApiController
    {
        private IPhyGeoDisasterService _phyService;
        public PhyGeoDisasterController(IPhyGeoDisasterService phyService)
        {
            this._phyService = phyService;
        }

       /// <summary>
       /// 通过编号获取物理点实体信息，物理点信息会关联大量信息，
       /// 如无特殊需求，请不要随意调用
       /// </summary>
       /// <param name="id">物理点编号</param>
       /// <returns></returns>
        public PhyGeoDisaster Get(int id)
        {
            if (id <= 0)
                throw new Exception("不存在这样的物理点信息主键编号");
            PhyGeoDisaster phy = this._phyService.GetById(id);
            return phy;
        }


        /// <summary>
        /// 通过编号获取物理点简要信息
        /// </summary>
        /// <param name="id">物理点编号</param>
        /// <returns></returns>
        public PhyGeoDisasterSimplify GetSimplifyById(int id)
        {
            if (id <= 0)
                throw new Exception("不存在这样的物理点信息主键编号");
            PhyGeoDisaster phy = this._phyService.GetById(id);
            PhyGeoDisasterSimplify phyModel = Mapper.Map<PhyGeoDisasterSimplify>(phy);
            return phyModel;
        }

        /// <summary>
        /// 通过名称、地理位置进行物理点检索
        /// 可以将需要忽略的条件设置为Null
        /// </summary>
        ///<param name="keyword">关键字</param>
        /// <returns>物理点简要信息</returns>
        public IList<PhyGeoDisasterSimplify> Get(string keyword)
        {
            if (String.IsNullOrEmpty(keyword))
                throw new Exception("查询的关键字不允许是类型“null”或者空字符串");
            IQueryable<PhyGeoDisaster> phyGeos = this._phyService.GetByKeyWord(keyword);
            IList<PhyGeoDisasterSimplify> phyModels = Mapper.Map<IQueryable<PhyGeoDisaster>,
                IList<PhyGeoDisasterSimplify>>(phyGeos);
            return phyModels;
        }

        /// <summary>
        /// 通过行政区编码，灾害类型进行查询
        /// </summary>
        /// <param name="gbcodes">多个行政区编码</param>
        /// <param name="types">多种灾害类型</param>
        /// <returns>物理点简要信息</returns>
        public IList<PhyGeoDisasterSimplify> Get(List<string> gbcodes=null,
            List<EnumGeoDisasterType> types=null)
        {
            IQueryable<PhyGeoDisaster> phys =
                  this._phyService.GetByConditions(gbcodes,types);
            IList<PhyGeoDisasterSimplify> phyModels = Mapper.Map<IQueryable<PhyGeoDisaster>,
            IList<PhyGeoDisasterSimplify>>(phys);
            return phyModels;
        }



        // POST api/phygeodisaster
        public void Post([FromBody]string value)
        {
        }

        // PUT api/phygeodisaster/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/phygeodisaster/5
        public void Delete(int id)
        {
        }
    }
}

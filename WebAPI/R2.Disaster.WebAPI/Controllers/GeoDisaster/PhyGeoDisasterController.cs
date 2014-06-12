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
    public class PhyGeoDisasterController : ApiController
    {
        private IPhyGeoDisasterService _phyService;
        public PhyGeoDisasterController(IPhyGeoDisasterService phyService)
        {
            this._phyService = phyService;
        }

       /// <summary>
       /// 通过编号获取物理点实体信息
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// 通过名称、地理位置进行物理点检索
        /// 可以将需要忽略的条件设置为Null
        /// </summary>
        /// <param name="name">灾害点名称关键字</param>
        /// <param name="location">地理位置关键字</param>
        /// <returns></returns>
        public IList<PhyGeoDisasterSimplify> Get(string keyword)
        {
            if (String.IsNullOrEmpty(keyword))
                throw new Exception("查询的关键字不允许是类型“null”或者空字符串");
            IQueryable<PhyGeoDisaster> phyGeos = this._phyService.GetByKeyWord(keyword);
            IList<PhyGeoDisasterSimplify> phyModels = Mapper.Map<IQueryable<PhyGeoDisaster>,
                IList<PhyGeoDisasterSimplify>>(phyGeos);
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

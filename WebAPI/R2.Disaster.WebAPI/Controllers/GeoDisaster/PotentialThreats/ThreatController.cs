using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.PotentialThreats;
using R2.Disaster.Service.GeoDisaster.PotentialThreats;

namespace R2.Disaster.WebAPI.Controllers.GeoDisaster.PotentialThreats
{
    /// <summary>
    /// 隐患点主表
    /// </summary>
    public class ThreatController : PhyRelationEntityController<Threat>
    {


        private IThreatService _threatService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="threatService"></param>
        public ThreatController(IThreatService threatService)
            : base(threatService)
        {
            this._threatService = threatService;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using R2.Disaster.Service.GeoDisaster.MassPres;

namespace R2.Disaster.WebAPI.Controllers.GeoDisaster.MassPres
{
    /// <summary>
    /// 防治规划
    /// </summary>
    public class PreventionPlanningController:EntityControllerBase<PreventionPlanning>
    {
        private IPreventionPlanningService _planService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="planService"></param>
        public PreventionPlanningController(IPreventionPlanningService planService)
            : base(planService)
        {
            this._planService = planService;
        }

    }
}
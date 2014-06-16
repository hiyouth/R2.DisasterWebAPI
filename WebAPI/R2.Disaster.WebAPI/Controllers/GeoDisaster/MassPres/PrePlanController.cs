using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using R2.Disaster.Service.GeoDisaster.MassPres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace R2.Disaster.WebAPI.Controllers.GeoDisaster.MassPres
{
    /// <summary>
    /// 防灾预案相关服务
    /// </summary>
    public class PrePlanController : ApiController
    {
        private IPrePlanService _preplanService;

        public PrePlanController(IPrePlanService preplanService )
        {
            this._preplanService = preplanService;
        }

        /// <summary>
        /// 通过主键编号查询
        /// <param name="id">主键编号</param>
        /// </summary>
        /// <returns></returns>
        public PrePlan Get(int id)
        {
                 if (id <= 0)
                throw new Exception("不存在这样的主键编号");
            //return new string[] { "value1", "value2" };
                 PrePlan plan=this._preplanService.GetById(id);
                 return plan;
        }

        /// <summary>
        /// 通过Phy物理点编号查询
        /// </summary>
        /// <param name="id">物理点相关唯一编号</param>
        /// <returns></returns>
        public PrePlan GetByPhyId(int id)
        {
            if (id <= 0)
                throw new Exception("不存在这样的主键编号");
            PrePlan plan = this._preplanService.GetByPhyId(id);
            return plan;
        }

        /// <summary>
        /// 通过统一编号查询
        /// </summary>
        /// <param name="uid">统一编号编码</param>
        /// <returns></returns>
        public IList<PrePlan> GetByUId(string uid)
        {
            if (String.IsNullOrEmpty(uid))
                throw new Exception("防灾预案的统一编号不能是“ ”或者Null");
            List<PrePlan> plans = this._preplanService.GetByUId(uid).ToList();
            return plans;
        }

        /// <summary>
        /// 通过关键字检索
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public IList<PrePlan> GetByKeyWords(string keyword)
        {
            if (String.IsNullOrEmpty(keyword))
                throw new Exception("防灾预案的统一编号不能是“ ”或者Null");
            List<PrePlan> plans = this._preplanService.GetByKeyWord(keyword).ToList();
            return plans;
        }
    }
}

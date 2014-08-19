using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Relocation;
using R2.Disaster.Service.GeoDisaster.Relocation;

namespace R2.Disaster.WebAPI.Controllers.GeoDisaster.Relocation
{
    /// <summary>
    /// 移民搬迁
    /// </summary>
    public class RelocationComprehensiveController : PhyRelationEntityController<RelocationComprehensive>
    {
        private IRelocationComprehensiveService _rcService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rcService"></param>
        public RelocationComprehensiveController(IRelocationComprehensiveService rcService)
            : base(rcService)
        {
            this._rcService = rcService;
        }

        /// <summary>
        /// 根据统一编号查询移民搬迁信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public IList<RelocationComprehensive> GetCompleteByUid(string uid)
        {
            if (string.IsNullOrEmpty(uid))
                throw new Exception(@"统一编号不能为null或者空字符串");

            IQueryable<RelocationComprehensive> result = this._rcService.GetByUnifiedId(uid);
            return result.ToList();
        }
    }
}
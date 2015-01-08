using Corner.Core;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.CoreEntities.Domain.FiveScale
{
    /// <summary>
    /// 1:5万数据实体
    /// </summary>
    public class FiveScaleProperty : PhyRelationEntity
    {
        /// <summary>
        /// 基础调查信息
        /// </summary>
        public virtual ICollection<ComprehensiveFS> ComprehensiveFSes { get; set; }

        /// <summary>
        /// 避险明白卡
        /// </summary>
        public virtual ICollection<AvoidRiskCardFS> AvoidRiskCardFSes { get; set; }

        /// <summary>
        /// 工作明白卡
        /// </summary>
        public virtual ICollection<WorkingGuideCardFS> WorkingGuideCardFSes { get; set; }


        /// <summary>
        /// 防灾预案
        /// </summary>
        public virtual ICollection<PrePlanFS> PrePlanFSes { get; set; }
    }
}

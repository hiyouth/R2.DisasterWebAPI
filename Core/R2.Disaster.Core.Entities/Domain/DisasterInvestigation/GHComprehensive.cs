

namespace R2.Disaster.CoreEntities.Domain.DisasterInvestigation
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// 地质灾害调查数据综合表
    /// </summary>
    public partial class GHComprehensive
    {

        //public int DebrisFlowId { get; set; }
        /// <summary>
        /// 泥石流
        /// </summary>
        public virtual GHDebrisFlow GHDebrisFlow { get; set; }
        /// <summary>
        /// 地面沉降
        /// </summary>
        public virtual GHLandSubsidence GHLandSubsidence { get; set; }

        /// <summary>
        /// 崩塌
        /// </summary>
        public virtual GHLandSlip GHLandSlip { get; set; }

        /// <summary>
        /// 斜坡
        /// </summary>
        public virtual GHSlope GHSlope { get; set; }

        /// <summary>
        /// 滑坡
        /// </summary>
        public virtual GHLandSlide GHLandSlide { get; set; }

        /// <summary>
        /// 地面塌陷
        /// </summary>
        public virtual GHLandCollapse GHLandCollapse { get; set; }

        /// <summary>
        /// 地裂缝
        /// </summary>
        public virtual GHLandFracture GHLandFracture { get; set; }


        public int Id { get; set; }
        public string 统一编号 { get; set; }
        public string 地理位置 { get; set; }
        public string 名称 { get; set; }
        public string 经度 { get; set; }
        public string 纬度 { get; set; }
        public int 死亡人数 { get; set; }
        public int 威胁人口 { get; set; }
        public double 直接经济损失 { get; set; }
        public double 威胁财产 { get; set; }
        public string 目前稳定状态 { get; set; }
        public string 灾害规模等级 { get; set; }
        public string 灾情等级 { get; set; }
        public string 险情等级 { get; set; }
        public double X坐标 { get; set; }
        public double Y坐标 { get; set; }
        public double 灾害体积 { get; set; }
        public string 灾害类型 { get; set; }
        public string 国际代码 { get; set; }


        //public virtual Collaps Collaps { get; set; }
        //public virtual DisasterType DisasterType { get; set; }
        //public virtual RegionCode RegionCode { get; set; }
        //public virtual ICollection<DisaImage> DisaImages { get; set; }
        //public virtual ICollection<EmergencySurveyTable> EmergencySurveyTables { get; set; }
        //public virtual GroundFissure GroundFissure { get; set; }
        //public virtual GroundSettle GroundSettle { get; set; }
        //public virtual GroundSubside GroundSubside { get; set; }
        //public virtual Landslide Landslide { get; set; }
        //public virtual LeanSlope LeanSlope { get; set; }
        
        //public virtual ICollection<PrecautionPlan> PrecautionPlans { get; set; }
    }
}

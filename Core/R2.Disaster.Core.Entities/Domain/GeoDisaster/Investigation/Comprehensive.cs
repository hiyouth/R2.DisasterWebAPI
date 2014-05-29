

namespace R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation
{
 using R2.Disaster.CoreEntities.Domain.GeoDisaster.Emergency;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using System;
using System.Collections.Generic;
    
    /// <summary>
    /// 地质灾害调查数据综合表
    /// </summary>
    public partial class Comprehensive
    {
        private bool _deleted = false;
        private ICollection<DamageReport> _damageReports;
        private ICollection<EmergencySurvey> _emergencySurveys;

        public Comprehensive()
        {

        }

        /// 标示一个灾害点是否被删除（大部分的删除操作只修改此状态，不做物理删除）
        /// </summary>
        public bool Deleted
        {
            get { return _deleted; }
            set { _deleted = value; }
        }

        //public int DebrisFlowId { get; set; }
        /// <summary>
        /// 泥石流
        /// </summary>
        public virtual DebrisFlow DebrisFlow { get; set; }
        /// <summary>
        /// 地面沉降
        /// </summary>
        public virtual LandSubsidence LandSubsidence { get; set; }

        /// <summary>
        /// 崩塌
        /// </summary>
        public virtual LandSlip LandSlip { get; set; }

        /// <summary>
        /// 斜坡
        /// </summary>
        public virtual Slope Slope { get; set; }

        /// <summary>
        /// 滑坡
        /// </summary>
        public virtual LandSlide LandSlide { get; set; }

        /// <summary>
        /// 地面塌陷
        /// </summary>
        public virtual LandCollapse LandCollapse { get; set; }

        /// <summary>
        /// 地裂缝
        /// </summary>
        public virtual LandFracture LandFracture { get; set; }

        /// <summary>
        /// 群测群防基本信息
        /// </summary>
        public virtual MassPre MassPre { get; set; }
        
        /// <summary>
        /// 避险明白卡
        /// </summary>
        public virtual AvoidRiskCard AvoidRiskCard { get; set; }

        /// <summary>
        /// 工作明白卡
        /// </summary>
        public virtual WorkingGuideCard WorkingGuideCard { get; set; }

        /// <summary>
        /// 国标代码
        /// </summary>
        public virtual GBCode GBCode { get; set; }
        public string GBCodeId { get; set; }

        /// <summary>
        /// 灾情速报
        /// </summary>
        public virtual ICollection<DamageReport> DamageReports
        {
            get
            {
                return this._damageReports == null ? (new List<DamageReport>()) : this._damageReports;
            }
            set
            {
                this._damageReports = value;
            }
        }

        /// <summary>
        /// 应急调查
        /// </summary>
        public virtual ICollection<EmergencySurvey> EmergencySurveys
        {
            get
            {
                return this._emergencySurveys == null ? (new List<EmergencySurvey>()) : this._emergencySurveys;
            }
            set
            {
                this._emergencySurveys = value;
            }
        }

        public EnumGeoDisasterType 灾害类型 { get; set; }

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

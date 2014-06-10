

namespace R2.Disaster.CoreEntities.Domain.GeoDisaster
{
    using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;

    /// <summary>
    /// 地质灾害调查数据综合表
    /// </summary>
    public partial class Comprehensive
    {
        
        //private bool _investigated=true;
        //private ICollection<DamageReport> _damageReports;
        //private ICollection<EmergencySurvey> _emergencySurveys;

        public Comprehensive()
        {
            //this._damageReports = new List<DamageReport>();
        }

        public virtual PhyGeoDisaster PhyGeoDisaster { get; set; }

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



        public int Id { get; set; }
        public string 统一编号 { get; set; }

        public string 名称 { get; set; }
        public string 经度 { get; set; }
        public string 纬度 { get; set; }
        public int 死亡人数 { get; set; }
        public int 威胁人口 { get; set; }

        public double 直接经济损失 { get; set; }
        public double 威胁财产 { get; set; }
        public string 目前稳定状态 { get; set; }
        public string 规模等级 { get; set; }
        
        public string 灾情等级 { get; set; }
        public string 险情等级 { get; set; }
        public double X坐标 { get; set; }
        public double Y坐标 { get; set; }
        public double 灾害体积 { get; set; }
        public double 灾害面积 { get; set; }
        public double 标高 { get; set; }
        public string 今后变化趋势 { get; set; }
        public string 危害程度 { get; set; }
    }
}

namespace Corner.Core
{
    using R2.Disaster.CoreEntities.Domain.GeoDisaster;
    using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
    using System;
    using System.Collections.Generic;

    public partial class ComprehensiveFS
    {
       
        public string 统一编号 { get; set; }

        /// <summary>
        /// 泥石流
        /// </summary>
        public virtual DebrisFlowFS DebrisFlowFS { get; set; }
        /// <summary>
        /// 地面沉降
        /// </summary>
        public virtual LandSubsidenceFS LandSubsidenceFS { get; set; }

        /// <summary>
        /// 崩塌
        /// </summary>
        public virtual LandSlipFS LandSlipFS { get; set; }

        /// <summary>
        /// 斜坡
        /// </summary>
        public virtual SlopeFS SlopeFS { get; set; }

        /// <summary>
        /// 滑坡
        /// </summary>
        public virtual LandSlideFS LandSlideFS { get; set; }

        /// <summary>
        /// 地面塌陷
        /// </summary>
        public virtual LandCollapseFS LandCollapseFS { get; set; }

        /// <summary>
        /// 地裂缝
        /// </summary>
        public virtual LandFractureFS LandFractureFS { get; set; }


        /// <summary>
        /// 灾害类型
        /// </summary>
        public virtual EnumGeoDisasterType 灾害类型 { get; set; }

        /// <summary>
        /// 行政区编码
        /// </summary>
        public virtual GBCode GBCode { get; set; }

        /// <summary>
        /// 行政区编码外键标示
        /// </summary>
        public string GBCodeId { get; set; }

       
        public string 野外编号 { get; set; }

       
        public string 名称 { get; set; }

       
        public string 省 { get; set; }

       
        public string 市 { get; set; }

       
        public string 县 { get; set; }

       
        public string 地理位置 { get; set; }

       
        public string 经度 { get; set; }

       
        public string 纬度 { get; set; }

        public int? 发生时间年 { get; set; }

        public int? 发生时间月 { get; set; }

        public int? 发生时间日 { get; set; }

        public int? 死亡人数 { get; set; }

        public int? 威胁人口 { get; set; }

        public float? 直接经济损失 { get; set; }

        public float? 威胁财产 { get; set; }

       
        public string 目前稳定状态 { get; set; }

       
        public string 灾害规模等级 { get; set; }

       
        public string 灾情等级 { get; set; }

       
        public string 险情等级 { get; set; }

        public int? X坐标 { get; set; }

        public int? Y坐标 { get; set; }

        public float? 灾害体积 { get; set; }

        public string 国际代码 { get; set; }


        public bool 遥感 { get; set; }

        public bool 调查 { get; set; }

        public bool 测绘 { get; set; }

        public bool 勘查 { get; set; }

       
        public string 调查点类型 { get; set; }

       
        public string 方向 { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace R2.Disaster.CoreEntities.Domain.GeoDisaster.Emergency
{
    using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using System;
using System.Collections.Generic;
    
    /// <summary>
    /// 应急调查实体
    /// </summary>
    public partial class EmergencySurvey:BaseEntity
    {
        public PhyGeoDisaster PhyGeoDisaster { get; set; }
        public int PhyGeoDisasterId { get; set; }

        //public int Id { get; set; }

        ///// <summary>
        ///// 记录时间
        ///// </summary>
        //public DateTime RecordTime { get; set; }

        public string 应急调查点 { get; set; }
        public double X坐标 { get; set; }
        public double Y坐标 { get; set; }
        public string 调查时间 { get; set; }
        public string 变形初始时间 { get; set; }
        public string 地理位置 { get; set; }
        public double 前缘高程 { get; set; }
        public double 后缘高程 { get; set; }
        public string 地层岩性 { get; set; }
        public string 地质构造 { get; set; }
        public double 多年平均降雨量 { get; set; }
        public double 长 { get; set; }
        public double 宽 { get; set; }
        public double 高 { get; set; }
        public double 面积 { get; set; }
        public double 体积 { get; set; }
        public string 影响因素 { get; set; }
        public string 目前稳定状态 { get; set; }
        public string 今后变化趋势 { get; set; }
        public double 直接经济损失 { get; set; }
        public int 死亡人数 { get; set; }
        public int 威胁人口 { get; set; }
        public double 威胁财产 { get; set; }
        public string 防治建议 { get; set; }
        public string 监测建议 { get; set; }
        public string 险情等级 { get; set; }
        public string 规模等级 { get; set; }
        public string 调查人 { get; set; }
        public string 调查单位 { get; set; }
        public string 照片名称 { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres
{
    using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using System;
using System.Collections.Generic;
    
    /// <summary>
    /// 防灾预案实体
    /// </summary>
    

    public partial class PrePlan : PhyRelationEntity
    {
        //public PhyGeoDisaster PhyGeoDisaster { get; set; }

        //public int Id { get; set; }

        public virtual PhyGeoDisaster PhyGeoDisaster { get; set; }

        public string 统一编号 { get; set; }
        public string 名称 { get; set; }
        public string 野外编号 { get; set; }
        public string 地理位置 { get; set; }
        public double X坐标 { get; set; }
        public double Y坐标 { get; set; }
        public string 经度 { get; set; }
        public string 纬度 { get; set; }
        public EnumGeoDisasterType 隐患点类型 { get; set; }
        public string 规模等级 { get; set; }
        public int 威胁人口 { get; set; }
        public double 威胁财产 { get; set; }
        public string 险情等级 { get; set; }
        public string 曾经发生灾害时间 { get; set; }
        public string 地质环境条件 { get; set; }
        public string 变形特征及历史活动情况 { get; set; }
        public string 稳定性分析 { get; set; }
        public string 引发因素 { get; set; }
        public string 潜在危害 { get; set; }
        public string 临灾状态预测 { get; set; }
        public string 监测方法 { get; set; }
        public string 监测周期 { get; set; }
        public string 监测责任人 { get; set; }
        public string 监测责任人电话 { get; set; }
        public string 群测群防人员 { get; set; }
        public string 群测群防人员电话 { get; set; }
        public string 报警方法 { get; set; }
        public string 报警信号 { get; set; }
        public string 报警人 { get; set; }
        public string 报警人电话 { get; set; }
        public string 预定避灾地点 { get; set; }
        public string 人员撤离路线 { get; set; }
        public string 防治建议 { get; set; }
        public byte[] 示意图 { get; set; }
        public string 图片名称 { get; set; }
        public string 文档路径 { get; set; }
    }
}

namespace Corner.Core
{
    using R2.Disaster.CoreEntities;
    using R2.Disaster.CoreEntities.Domain.GeoDisaster;
    using System;
    using System.Collections.Generic;

    public partial class PrePlanFS : PhyRelationEntity
    {
        public virtual PhyGeoDisaster PhyGeoDisaster { get; set; }
       
        public string 统一编号 { get; set; }

        public string 名称 { get; set; }

        public string 野外编号 { get; set; }

        public string 省 { get; set; }

        public string 市 { get; set; }
        public string 县 { get; set; }

        public string 乡 { get; set; }

        public string 村 { get; set; }

        public string 组 { get; set; }

        public string 地点 { get; set; }

        public int? X坐标 { get; set; }

        public int? Y坐标 { get; set; }
        public string 经度 { get; set; }

        public string 纬度 { get; set; }

        public string 隐患点类型 { get; set; }

        public string 规模 { get; set; }

        public string 规模等级 { get; set; }

        public int? 威胁人口 { get; set; }

        public double? 威胁财产 { get; set; }
        public string 险情等级 { get; set; }

        public string 曾经发生灾害时间 { get; set; }
        public string 地质环境条件 { get; set; }

        public string 变形特征及历史活动情况 { get; set; }

        public string 稳定性分析 { get; set; }

        public string 引发因素 { get; set; }

        public string 潜在危害 { get; set; }
        public string 临灾状态预测 { get; set; }
        public string 监测方法 { get; set; }

        public string 监测仪器 { get; set; }

        public string 监测周期 { get; set; }
        public string 监测责任人 { get; set; }

        public string 监测责任人电话 { get; set; }
        public string 监测责任人手机 { get; set; }

        public string 群测群防人员 { get; set; }
        public string 群测群防人员电话 { get; set; }
        public string 群测群防人员手机 { get; set; }
        public string 报警方法 { get; set; }

        public string 报警信号 { get; set; }

        public string 报警人 { get; set; }

        public string 报警人电话 { get; set; }

        public string 预定避灾地点 { get; set; }

        public string 人员撤离路线 { get; set; }

        public string 防治建议 { get; set; }

        public bool 栅格撤离路线图 { get; set; }
        public bool 多媒体 { get; set; }
        public bool 监测信息 { get; set; }
        public bool 矢量撤离路线图 { get; set; }
    }
}

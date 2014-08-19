using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres
{
    /// <summary>
    /// 防治规划实体
    /// </summary>
    public class PreventionPlanning : BaseEntity
    {

        public EnumGeoDisasterType 灾害类型 { get; set; }
        public string GBCodeId { get; set; }


        public string 市 { get; set; }
        public string 县 { get; set; }
        public string 乡村组 { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string 稳定性易发性 { get; set; }
        public string 潜在规模面积 { get; set; }
        public double 潜在规模体积 { get; set; }
        public string 规模等级 { get; set; }
        public string 主要威胁对象 { get; set; }
        public int 威胁人口户数 { get; set; }
        public int 威胁人口人数 { get; set; }
        public double 经济损失评估万元 { get; set; }
        public string 险情等级 { get; set; }
        public string 防治分级 { get; set; }
        public string 防治分期 { get; set; }
        public string 防治措施 { get; set; }
        public double 防治经费万元 { get; set; }
        public string 备注 { get; set; }
    }
}

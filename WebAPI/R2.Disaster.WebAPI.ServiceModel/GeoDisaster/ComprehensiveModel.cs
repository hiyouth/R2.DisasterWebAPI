﻿using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R2.Disaster.WebAPI.Model
{
    public class ComprehensiveModel
    {
        //public EnumGeoDisasterType 灾害类型 { get; set; }

        public int Id { get; set; }
        public string 统一编号 { get; set; }
        //public string 地理位置 { get; set; }
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

        //public string GBCodeId { get; set; }
    }
}
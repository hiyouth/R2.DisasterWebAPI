﻿using R2.Disaster.CoreEntities.Domain.GeoDisaster.Emergency;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.CoreEntities.Domain.GeoDisaster
{
    /// <summary>
    /// 地质灾害物理点
    /// </summary>
    public class PhyGeoDisaster
    {
        private bool _deleted = false;

        public int Id { get; set; }
        /// <summary>
        /// 地理位置描述，必要属性，不允许Null
        /// </summary>
        public String 地理位置 { get; set; }

        /// <summary>
        /// 行政区编码，必要属性，不允许Null
        /// </summary>
        public GBCode GBCode { get; set; }
        public string GBCodeId { get; set; }

        /// <summary>
        /// 灾害类型，必要属性
        /// </summary>
        public EnumGeoDisasterType 灾害类型 { get; set; }

        /// <summary>
        /// 是否已进行了基础调查，并包含有地质调查的数据，默认为已进行地质调查
        /// </summary>
        public bool? Investigated { get; set; }

        /// 标示一个灾害点是否被删除（大部分的删除操作只修改此状态，不做物理删除）
        /// </summary>
        public bool Deleted
        {
            get { return _deleted; }
            set { _deleted = value; }
        }

        /// <summary>
        /// 基础调查信息
        /// </summary>
        public virtual Comprehensive Comprehensive { get; set; }

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
        /// 防灾预案
        /// </summary>
        public virtual PrePlan PrePlan { get; set; }

        /// <summary>
        /// 灾情速报
        /// </summary>
        public virtual ICollection<DamageReport> DamageReports { get; set; }

        /// <summary>
        /// 应急调查
        /// </summary>
        public virtual ICollection<EmergencySurvey> EmergencySurveys { get; set; }

        /// <summary>
        /// 群测群防巡查记录
        /// </summary>
        public virtual ICollection<MassPatrol> MassPatrols { get; set; }
    }
}

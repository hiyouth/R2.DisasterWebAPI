﻿using R2.Disaster.CoreEntities.Domain.GeoDisaster.Emergency;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.PotentialThreats;
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
    public class PhyGeoDisaster:BaseEntity
    {
        private bool _deleted = false;

        //public int Id { get; set; }

        /// <summary>
        /// 给予用户一个自定义的标示键，以便于用户可以使用一个自定义的键位来串接整个灾害实体关系
        /// 但本属性并不会作为真正的主键
        /// </summary>
        public string CustomizeId { get; set; }

        /// <summary>
        /// 物理点表示名称
        /// 这个名称和地质调查综合表中的名称可以不同
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 地理位置描述，必要属性，不允许Null
        /// </summary>
        public String Location { get; set; }

        /// <summary>
        /// 经度，X
        /// </summary>
        public double Lon { get; set; }

        /// <summary>
        /// 纬度，Y
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// 行政区编码，必要属性，不允许Null
        /// </summary>
        public virtual GBCode GBCode { get; set; }
        public string GBCodeId { get; set; }

        /// <summary>
        /// 灾害类型，必要属性，不允许Null
        /// </summary>
        public EnumGeoDisasterType DisasterType { get; set; }

        ///// <summary>
        ///// 是否已进行了基础调查，并包含有地质调查的数据，默认为已进行地质调查
        ///// </summary>
        //public bool? Investigated { get; set; }

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
        /// 隐患
        /// </summary>
        public virtual Threat Threat { get; set; }

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

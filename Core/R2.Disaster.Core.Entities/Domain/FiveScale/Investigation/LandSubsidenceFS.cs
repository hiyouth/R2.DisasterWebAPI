namespace Corner.Core
{
    using R2.Disaster.CoreEntities;
    using System;
    using System.Collections.Generic;

    public partial class LandSubsidenceFS:BaseEntity
    {
       
        public string 项目名称 { get; set; }

       
        public string 图幅名 { get; set; }

       
        public string 图幅编号 { get; set; }

       
        public string 县市编号 { get; set; }

       
        public string 统一编号 { get; set; }

       
        public string 名称 { get; set; }

        public int? 发生时间年 { get; set; }

        public int? 发生时间月 { get; set; }

        public int? 发生时间日 { get; set; }

       
        public string 野外编号 { get; set; }

       
        public string 室内编号 { get; set; }

        public int? X坐标 { get; set; }

        public int? Y坐标 { get; set; }

       
        public string 经度 { get; set; }

       
        public string 纬度 { get; set; }

       
        public string 沉降类型 { get; set; }

       
        public string 省 { get; set; }

       
        public string 市 { get; set; }

       
        public string 县 { get; set; }

       
        public string 乡 { get; set; }

       
        public string 村 { get; set; }

       
        public string 组 { get; set; }

       
        public string 地点 { get; set; }

       
        public string 沉降中心位置 { get; set; }

       
        public string 沉降中心经度 { get; set; }

       
        public string 沉降中心纬度 { get; set; }

        public double? 沉降区面积 { get; set; }

        public double? 年平均沉降量 { get; set; }

        public double? 历年累计沉降量 { get; set; }

        public double? 平均沉降速率 { get; set; }

       
        public string 地形地貌 { get; set; }

       
        public string 地质构造及活动情况 { get; set; }

       
        public string 岩性 { get; set; }

       
        public string 厚度 { get; set; }

       
        public string 结构 { get; set; }

       
        public string 空间变化规律 { get; set; }

       
        public string 水文地质特征 { get; set; }

       
        public string 主要沉降层位 { get; set; }

        public double? 年开采量 { get; set; }

        public double? 年补给量 { get; set; }

        public double? 地下水埋深 { get; set; }

        public double? 年水位变化幅度 { get; set; }

       
        public string 其它 { get; set; }

       
        public string 诱发沉降原因 { get; set; }

       
        public string 变化规律 { get; set; }

       
        public string 沉降现状 { get; set; }

       
        public string 发展趋势 { get; set; }

       
        public string 主要危害 { get; set; }

        public double? 经济损失 { get; set; }

        public int? 死亡人数 { get; set; }

        public double? 直接损失 { get; set; }

       
        public string 危害对象 { get; set; }

        public int? 威胁人数 { get; set; }

        public double? 威胁财产 { get; set; }

       
        public string 威胁对象 { get; set; }

       
        public string 治理措施 { get; set; }

       
        public string 治理效果 { get; set; }

       
        public string 调查负责人 { get; set; }

       
        public string 填表人 { get; set; }

       
        public string 审核人 { get; set; }

       
        public string 调查单位 { get; set; }

        public int? 填表日期年 { get; set; }

        public int? 填表日期月 { get; set; }

        public int? 填表日期日 { get; set; }


        public bool 遥感点 { get; set; }


        public bool 勘查点 { get; set; }


        public bool 测绘点 { get; set; }


        public bool 防灾预案 { get; set; }


        public bool 照片 { get; set; }

        public bool 录像 { get; set; }

        public int? 威胁房屋户 { get; set; }


        public bool 隐患点 { get; set; }
    }
}

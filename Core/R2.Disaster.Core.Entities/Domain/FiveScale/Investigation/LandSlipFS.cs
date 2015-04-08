
using R2.Disaster.CoreEntities;
using System;
using System.Collections.Generic;

namespace R2.Disaster.CoreEntities.Domain.FiveScale.Investigation
{


    public partial class LandSlipFS:BaseEntity
    {
       
        public string 项目名称 { get; set; }

       
        public string 图幅名 { get; set; }

       
        public string 图幅编号 { get; set; }

       
        public string 统一编号 { get; set; }

       
        public string 名称 { get; set; }

       
        public string 野外编号 { get; set; }

       
        public string 县市编号 { get; set; }

       
        public string 室内编号 { get; set; }

       
        public string 斜坡类型 { get; set; }

       
        public string 崩塌类型 { get; set; }

       
        public string 省 { get; set; }

       
        public string 市 { get; set; }

       
        public string 县 { get; set; }

       
        public string 乡 { get; set; }

       
        public string 村 { get; set; }

       
        public string 组 { get; set; }

       
        public string 地点 { get; set; }

        public int? X坐标 { get; set; }

        public int? Y坐标 { get; set; }

        public float? 坡顶标高 { get; set; }

        public float? 坡脚标高 { get; set; }

       
        public string 经度 { get; set; }

       
        public string 纬度 { get; set; }

       
        public string 地层时代 { get; set; }

       
        public string 地层岩性 { get; set; }

        public int? 地层倾向 { get; set; }

        public int? 地层倾角 { get; set; }

       
        public string 构造部位 { get; set; }

       
        public string 地震烈度 { get; set; }

        public string 微地貌 { get; set; }

        public string 地下水类型 { get; set; }

        public float? 年均降雨量 { get; set; }

        public float? 日最大降雨 { get; set; }

        public float? 时最大降雨 { get; set; }

        public float? 洪水位 { get; set; }

        public float? 枯水位 { get; set; }

        public string 相对河流位置 { get; set; }

       
        public string 土地利用 { get; set; }

        public float? 分布高程 { get; set; }

        public float? 坡高 { get; set; }

        public float? 坡宽 { get; set; }

        public float? 坡长 { get; set; }

        public float? 厚度 { get; set; }

        public double? 规模 { get; set; }

       
        public string 规模等级 { get; set; }

        public float? 坡度 { get; set; }

        public float? 坡向 { get; set; }

       
        public string 岩体结构类型 { get; set; }

        public float? 岩体厚度 { get; set; }

        public float? 岩体裂隙组数 { get; set; }

       
        public string 岩体块度 { get; set; }

        public string 斜坡结构类型 { get; set; }

       
        public string 控制结构面类型1 { get; set; }

        public int? 控制结构面倾向1 { get; set; }

        public int? 控制结构面倾角1 { get; set; }

        public float? 控制结构面长度1 { get; set; }

        public float? 控制结构面间距1 { get; set; }

       
        public string 控制结构面类型2 { get; set; }

        public int? 控制结构面倾向2 { get; set; }

        public int? 控制结构面倾角2 { get; set; }

        public float? 控制结构面长度2 { get; set; }

        public float? 控制结构面间距2 { get; set; }

       
        public string 控制结构面类型3 { get; set; }

        public int? 控制结构面倾向3 { get; set; }

        public int? 控制结构面倾角3 { get; set; }

        public float? 控制结构面长度3 { get; set; }

        public float? 控制结构面间距3 { get; set; }

        public float? 全风化带深度 { get; set; }

        public float? 卸荷裂缝深度 { get; set; }

       
        public string 土体名称 { get; set; }

        public string 土体密实度 { get; set; }

       
        public string 土体稠度 { get; set; }

       
        public string 下伏基岩岩性 { get; set; }

       
        public string 下伏基岩时代 { get; set; }

        public int? 下伏基岩倾向 { get; set; }

        public int? 下伏基岩倾角 { get; set; }

        public int? 下伏基岩埋深 { get; set; }

        public int? 形成时间年 { get; set; }

        public int? 形成时间月 { get; set; }

        public int? 形成时间日 { get; set; }

        public int? 发生崩塌次数 { get; set; }

        public int? 序号1 { get; set; }

        public int? 发生时间年1 { get; set; }

        public int? 发生时间月1 { get; set; }

        public int? 发生时间日1 { get; set; }

        public int? 发生时间时1 { get; set; }

        public int? 发生时间分1 { get; set; }

        public int? 发生时间秒1 { get; set; }

        public double? 规模1 { get; set; }

       
        public string 诱发因素1 { get; set; }

        public int? 死亡人数1 { get; set; }

        public double? 直接损失1 { get; set; }

        public int? 序号2 { get; set; }

        public int? 发生时间年2 { get; set; }

        public int? 发生时间月2 { get; set; }

        public int? 发生时间日2 { get; set; }

        public int? 发生时间时2 { get; set; }

        public int? 发生时间分2 { get; set; }

        public int? 发生时间秒2 { get; set; }

        public double? 规模2 { get; set; }

       
        public string 诱发因素2 { get; set; }

        public int? 死亡人数2 { get; set; }

        public double? 直接损失2 { get; set; }

        public int? 序号3 { get; set; }

        public int? 发生时间年3 { get; set; }

        public int? 发生时间月3 { get; set; }

        public int? 发生时间日3 { get; set; }

        public int? 发生时间时3 { get; set; }

        public int? 发生时间分3 { get; set; }

        public int? 发生时间秒3 { get; set; }

        public double? 规模3 { get; set; }

       
        public string 诱发因素3 { get; set; }

        public int? 死亡人数3 { get; set; }

        public float? 直接损失3 { get; set; }

       
        public string 变形迹象名称1 { get; set; }

       
        public string 变形迹象部位1 { get; set; }

       
        public string 变形迹象特征1 { get; set; }

        public int? 变形迹象初现时间年1 { get; set; }

        public int? 变形迹象初现时间月1 { get; set; }

        public int? 变形迹象初现时间日1 { get; set; }

       
        public string 变形迹象名称2 { get; set; }

       
        public string 变形迹象部位2 { get; set; }

       
        public string 变形迹象特征2 { get; set; }

        public int? 变形迹象初现时间年2 { get; set; }

        public int? 变形迹象初现时间月2 { get; set; }

        public int? 变形迹象初现时间日2 { get; set; }

       
        public string 变形迹象名称3 { get; set; }

       
        public string 变形迹象部位3 { get; set; }

       
        public string 变形迹象特征3 { get; set; }

        public int? 变形迹象初现时间年3 { get; set; }

        public int? 变形迹象初现时间月3 { get; set; }

        public int? 变形迹象初现时间日3 { get; set; }

       
        public string 变形迹象名称4 { get; set; }

       
        public string 变形迹象部位4 { get; set; }

       
        public string 变形迹象特征4 { get; set; }

        public int? 变形迹象初现时间年4 { get; set; }

        public int? 变形迹象初现时间月4 { get; set; }

        public int? 变形迹象初现时间日4 { get; set; }

       
        public string 变形迹象名称5 { get; set; }

       
        public string 变形迹象部位5 { get; set; }

       
        public string 变形迹象特征5 { get; set; }

        public int? 变形迹象初现时间年5 { get; set; }

        public int? 变形迹象初现时间月5 { get; set; }

        public int? 变形迹象初现时间日5 { get; set; }

       
        public string 变形迹象名称6 { get; set; }

       
        public string 变形迹象部位6 { get; set; }

       
        public string 变形迹象特征6 { get; set; }

        public int? 变形迹象初现时间年6 { get; set; }

        public int? 变形迹象初现时间月6 { get; set; }

        public int? 变形迹象初现时间日6 { get; set; }

       
        public string 变形迹象名称7 { get; set; }

       
        public string 变形迹象部位7 { get; set; }

       
        public string 变形迹象特征7 { get; set; }

        public int? 变形迹象初现时间年7 { get; set; }

        public int? 变形迹象初现时间月7 { get; set; }

        public int? 变形迹象初现时间日7 { get; set; }

       
        public string 变形迹象名称8 { get; set; }

       
        public string 变形迹象部位8 { get; set; }

       
        public string 变形迹象特征8 { get; set; }

        public int? 变形迹象初现时间年8 { get; set; }

        public int? 变形迹象初现时间月8 { get; set; }

        public int? 变形迹象初现时间日8 { get; set; }

       
        public string 危岩体可能失稳因素 { get; set; }

       
        public string 危岩体目前稳定程度 { get; set; }

       
        public string 危岩体今后变化趋势 { get; set; }

        public int? 地下水埋深 { get; set; }

       
        public string 地下水露头 { get; set; }

       
        public string 地下水补给类型 { get; set; }

        public float? 堆积体长度 { get; set; }

        public float? 堆积体宽度 { get; set; }

        public float? 堆积体厚度 { get; set; }

        public double? 堆积体体积 { get; set; }

        public float? 堆积体坡度 { get; set; }

        public float? 堆积体坡向 { get; set; }

       
        public string 堆积体坡面形态 { get; set; }

       
        public string 堆积体稳定性 { get; set; }

       
        public string 堆积体可能失稳因素 { get; set; }

       
        public string 堆积体目前稳定性 { get; set; }

       
        public string 堆积体今后变化趋势 { get; set; }

        public int? 死亡人口 { get; set; }

        public int? 毁坏房屋户 { get; set; }

        public int? 毁坏房屋间 { get; set; }

        public float? 毁路 { get; set; }

        public float? 毁渠 { get; set; }

       
        public string 其它危害 { get; set; }

        public double? 直接损失 { get; set; }

        public double? 间接损失 { get; set; }

       
        public string 灾情等级 { get; set; }

       
        public string 危害对象 { get; set; }

       
        public string 诱发灾害类型 { get; set; }

       
        public string 诱发灾害波及范围 { get; set; }

        public double? 诱发灾害损失 { get; set; }

        public int? 威胁人口 { get; set; }

        public double? 威胁财产 { get; set; }

       
        public string 险情等级 { get; set; }

       
        public string 威胁对象 { get; set; }

       
        public string 监测建议 { get; set; }

       
        public string 防治建议 { get; set; }

       
        public string 防治监测 { get; set; }

       
        public string 防治治理 { get; set; }

       
        public string 群测群防 { get; set; }

       
        public string 搬迁避让 { get; set; }

        public bool 隐患点 { get; set; }

        public bool 遥感点 { get; set; }

        public bool 勘查点 { get; set; }

        public bool 测绘点 { get; set; }

        public bool 防灾预案 { get; set; }

        public bool 多媒体 { get; set; }

       
        public string 群测人员 { get; set; }

       
        public string 村长 { get; set; }

       
        public string 电话 { get; set; }

       
        public string 调查负责人 { get; set; }

       
        public string 填表人 { get; set; }

       
        public string 审核人 { get; set; }

       
        public string 调查单位 { get; set; }

        public int? 填表日期年 { get; set; }

        public int? 填表日期月 { get; set; }

        public int? 填表日期日 { get; set; }

        public bool 平面示意图 { get; set; }

        public bool 剖面示意图 { get; set; }

        public bool 栅格素描图 { get; set; }

        public bool 矢量平面图 { get; set; }

        public bool 矢量剖面图 { get; set; }

        public bool 矢量素描图 { get; set; }

        public string 野外记录信息 { get; set; }

       
        public string 崩塌情况 { get; set; }

        public bool 录像 { get; set; }

        public int? 威胁房屋户 { get; set; }
    }
}

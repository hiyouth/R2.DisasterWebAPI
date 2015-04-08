
using R2.Disaster.CoreEntities;
using System;
using System.Collections.Generic;

namespace R2.Disaster.CoreEntities.Domain.FiveScale.Investigation
{


    public partial class LandSlideFS:BaseEntity
    {
       
        public string 项目名称 { get; set; }

       
        public string 图幅名 { get; set; }

       
        public string 图幅编号 { get; set; }

       
        public string 县市编号 { get; set; }

       
        public string 名称 { get; set; }

       
        public string 野外编号 { get; set; }

       
        public string 统一编号 { get; set; }

        public string 室内编号 { get; set; }

       
        public string 滑坡年代 { get; set; }

        public int? 滑坡时间年 { get; set; }

        public int? 滑坡时间月 { get; set; }

        public int? 滑坡时间日 { get; set; }

        public int? 滑坡时间时 { get; set; }

        public int? 滑坡时间分 { get; set; }

        public int? 滑坡时间秒 { get; set; }

       
        public string 滑坡类型 { get; set; }

       
        public string 滑坡性质 { get; set; }

        public int? X坐标 { get; set; }

        public int? Y坐标 { get; set; }

        public float? 冠 { get; set; }

        public float? 趾 { get; set; }

       
        public string 经度 { get; set; }

       
        public string 纬度 { get; set; }

       
        public string 省 { get; set; }

       
        public string 市 { get; set; }

       
        public string 县 { get; set; }

       
        public string 乡 { get; set; }

       
        public string 村 { get; set; }

       
        public string 组 { get; set; }

       
        public string 地点 { get; set; }

       
        public string 地层时代 { get; set; }

       
        public string 地层岩性 { get; set; }

       
        public string 构造部位 { get; set; }

       
        public string 地震烈度 { get; set; }

        public int? 地层倾向 { get; set; }

        public int? 地层倾角 { get; set; }

       
        public string 微地貌 { get; set; }

       
        public string 地下水类型 { get; set; }

        public float? 年均降雨量 { get; set; }

        public float? 日最大降雨量 { get; set; }

        public float? 时最大降雨量 { get; set; }

        public float? 洪水位 { get; set; }

        public float? 枯水位 { get; set; }


        public string 相对河流位置 { get; set; }

        public float? 原始坡高 { get; set; }

        public float? 原始坡度 { get; set; }

       
        public string 原始坡形 { get; set; }

       
        public string 斜坡结构类型 { get; set; }

       
        public string 控滑结构面类型1 { get; set; }

        public int? 控滑结构面倾向1 { get; set; }

        public int? 控滑结构面倾角1 { get; set; }

       
        public string 控滑结构面类型2 { get; set; }

        public int? 控滑结构面倾向2 { get; set; }

        public int? 控滑结构面倾角2 { get; set; }

       
        public string 控滑结构面类型3 { get; set; }

        public int? 控滑结构面倾向3 { get; set; }

        public int? 控滑结构面倾角3 { get; set; }

       
        public string 控滑结构面类型4 { get; set; }

        public int? 控滑结构面倾向4 { get; set; }

        public int? 控滑结构面倾角4 { get; set; }

        public float? 滑坡长度 { get; set; }

        public float? 滑坡宽度 { get; set; }

        public float? 滑坡厚度 { get; set; }

        public float? 滑坡坡度 { get; set; }

        public float? 滑坡坡向 { get; set; }

        public double? 滑坡面积 { get; set; }

        public double? 滑坡体积 { get; set; }

       
        public string 滑坡平面形态 { get; set; }

       
        public string 滑坡剖面形态 { get; set; }

       
        public string 规模等级 { get; set; }

       
        public string 滑体岩性 { get; set; }

        public string 滑体结构 { get; set; }

        public float? 滑体碎石含量 { get; set; }

       
        public string 滑体块度 { get; set; }

       
        public string 滑床岩性 { get; set; }

       
        public string 滑床时代 { get; set; }

        public int? 滑床倾向 { get; set; }

        public int? 滑床倾角 { get; set; }

       
        public string 滑面形态 { get; set; }

        public float? 滑面埋深 { get; set; }

        public int? 滑面倾向 { get; set; }

        public int? 滑面倾角 { get; set; }

        public float? 滑带厚度 { get; set; }

        public string 滑带土名称 { get; set; }

       
        public string 滑带土性状 { get; set; }

        public float? 地下水埋深 { get; set; }

       
        public string 地下水露头 { get; set; }

       
        public string 地下水补给类型 { get; set; }

       
        public string 土地利用 { get; set; }

       
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

       
        public string 变形活动阶段 { get; set; }

       
        public string 地质因素 { get; set; }

       
        public string 自然诱因 { get; set; }

       
        public string 地貌因素 { get; set; }

       
        public string 物理因素 { get; set; }

       
        public string 人为因素 { get; set; }

       
        public string 主导因素 { get; set; }

       
        public string 复活诱发因素 { get; set; }

       
        public string 目前稳定状态 { get; set; }

       
        public string 今后变化趋势 { get; set; }


        public bool 隐患点 { get; set; }

        public float? 毁坏房屋户 { get; set; }

        public float? 毁坏房屋间 { get; set; }

        public int? 死亡人数 { get; set; }

        public float? 毁路 { get; set; }

        public float? 毁渠 { get; set; }

       
        public string 其它危害 { get; set; }

        public double? 直接损失 { get; set; }

        public double? 间接损失 { get; set; }

       
        public string 灾情等级 { get; set; }

       
        public string 危害对象 { get; set; }

       
        public string 诱发灾害类型 { get; set; }

       
        public string 诱发灾害波及范围 { get; set; }

        public double? 诱发灾害造成损失 { get; set; }

        public float? 威胁住户 { get; set; }

        public int? 威胁人数 { get; set; }

        public double? 威胁财产 { get; set; }

       
        public string 险情等级 { get; set; }

       
        public string 威胁对象 { get; set; }

       
        public string 监测建议 { get; set; }

       
        public string 防治建议 { get; set; }

       
        public string 防治监测 { get; set; }

       
        public string 防治治理 { get; set; }

       
        public string 搬迁避让 { get; set; }

       
        public string 群测群防 { get; set; }


        public bool 遥感点 { get; set; }


        public bool 勘查点 { get; set; }

        public bool 测绘点 { get; set; }


        public bool 防灾预案 { get; set; }

       
        public string 群测人员 { get; set; }

       
        public string 村长 { get; set; }

       
        public string 电话 { get; set; }

        public bool 多媒体 { get; set; }


        public bool 录像 { get; set; }


        public bool 平面示意图 { get; set; }


        public bool 剖面示意图 { get; set; }


        public bool 栅格素描图 { get; set; }

        public bool 矢量平面图 { get; set; }

        public bool 矢量剖面图 { get; set; }

        public bool 矢量素描图 { get; set; }

        public string 野外调查记录 { get; set; }

       
        public string 调查负责人 { get; set; }

       
        public string 填表人 { get; set; }

        public string 审核人 { get; set; }

       
        public string 调查单位 { get; set; }

        public int? 填表日期年 { get; set; }

        public int? 填表日期月 { get; set; }

        public int? 填表日期日 { get; set; }

       
        public string 滑坡情况 { get; set; }

        public int? 威胁房屋户 { get; set; }
    }
}

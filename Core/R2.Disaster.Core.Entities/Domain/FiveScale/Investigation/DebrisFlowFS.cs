
using R2.Disaster.CoreEntities;
using System;
using System.Collections.Generic;
namespace R2.Disaster.CoreEntities.Domain.FiveScale.Investigation
{


    public partial class DebrisFlowFS:BaseEntity
    {
       
        public string 项目名称 { get; set; }

       
        public string 图幅名 { get; set; }

       
        public string 图幅编号 { get; set; }

       
        public string 统一编号 { get; set; }

       
        public string 县市编号 { get; set; }

       
        public string 名称 { get; set; }

       
        public string 野外编号 { get; set; }

       
        public string 室内编号 { get; set; }

       
        public string 经度 { get; set; }

       
        public string 纬度 { get; set; }

       
        public string 省 { get; set; }

       
        public string 市 { get; set; }

       
        public string 县 { get; set; }

       
        public string 乡 { get; set; }

       
        public string 村 { get; set; }

       
        public string 组 { get; set; }

       
        public string 地点 { get; set; }

        public float? 最大标高 { get; set; }

        public float? 最小标高 { get; set; }

        public float? X坐标 { get; set; }

        public float? Y坐标 { get; set; }

       
        public string 水系名称 { get; set; }

       
        public string 主河名称 { get; set; }

       
        public string 相对主河位置 { get; set; }

        public float? 沟口至主河道距 { get; set; }

        public float? 流动方向 { get; set; }

       
        public string 水动力类型 { get; set; }

        public float? 沟口巨石A { get; set; }

        public float? 沟口巨石B { get; set; }

        public float? 沟口巨石C { get; set; }

       
        public string 泥砂补给途径 { get; set; }

       
        public string 补给区位置 { get; set; }

        public float? 年最大降雨 { get; set; }

        public float? 年平均降雨 { get; set; }

        public float? 日最大降雨 { get; set; }

        public float? 日平均降雨 { get; set; }

        public float? 时最大降雨 { get; set; }

        public float? 时平均降雨 { get; set; }

        public float? 十分钟最大降雨 { get; set; }

        public float? 十分钟平均降雨 { get; set; }

        public int? 沟口扇形地完整性 { get; set; }

        public float? 沟口扇形地变幅 { get; set; }

       
        public string 沟口扇形地发展趋势 { get; set; }

        public float? 沟口扇形地扇长 { get; set; }

        public float? 沟口扇形地扇宽 { get; set; }

        public float? 沟口扇形地扩散角 { get; set; }

       
        public string 沟口扇形地挤压大河 { get; set; }

       
        public string 地质构造 { get; set; }

       
        public string 地震烈度 { get; set; }

       
        public string 滑坡活动程度 { get; set; }

       
        public string 滑坡规模 { get; set; }

       
        public string 人工弃体活动程度 { get; set; }

       
        public string 人工弃体规模 { get; set; }

       
        public string 自然堆积活动程度 { get; set; }

       
        public string 自然堆积规模 { get; set; }

        public float? 森林 { get; set; }

        public float? 灌丛 { get; set; }

        public float? 草地 { get; set; }

        public float? 缓坡耕地 { get; set; }

        public float? 荒地 { get; set; }

        public float? 陡坡耕地 { get; set; }

        public float? 建筑用地 { get; set; }

       
        public string 其它 { get; set; }

        public float? 其它用地 { get; set; }

       
        public string 防治措施现状 { get; set; }

       
        public string 防治措施类型 { get; set; }

       
        public string 监测措施 { get; set; }

       
        public string 监测措施类型 { get; set; }

       
        public string 危害对象 { get; set; }

        public int? 死亡人数 { get; set; }

        public double? 直接经济损失 { get; set; }

       
        public string 灾情等级 { get; set; }

        public int? 灾害史发生时间年1 { get; set; }

        public int? 灾害史发生时间月1 { get; set; }

        public int? 灾害史发生时间日1 { get; set; }

        public int? 灾害史死亡人口1 { get; set; }

        public int? 灾害史损失牲畜1 { get; set; }

        public int? 灾害史全毁房屋1 { get; set; }

        public int? 灾害史半毁房屋1 { get; set; }

        public float? 灾害史全毁农田1 { get; set; }

        public float? 灾害史半毁农田1 { get; set; }

        public float? 灾害史毁坏道路1 { get; set; }

        public int? 灾害史毁坏桥梁1 { get; set; }

        public double? 灾害史直接损失1 { get; set; }

       
        public string 灾害史灾情等级1 { get; set; }

        public int? 灾害史发生时间年2 { get; set; }

        public int? 灾害史发生时间月2 { get; set; }

        public int? 灾害史发生时间日2 { get; set; }

        public int? 灾害史死亡人口2 { get; set; }

        public int? 灾害史损失牲畜2 { get; set; }

        public int? 灾害史全毁房屋2 { get; set; }

        public int? 灾害史半毁房屋2 { get; set; }

        public float? 灾害史全毁农田2 { get; set; }

        public float? 灾害史半毁农田2 { get; set; }

        public float? 灾害史毁坏道路2 { get; set; }

        public int? 灾害史毁坏桥梁2 { get; set; }

        public double? 灾害史直接损失2 { get; set; }

       
        public string 灾害史灾情等级2 { get; set; }

        public int? 灾害史发生时间年3 { get; set; }

        public int? 灾害史发生时间月3 { get; set; }

        public int? 灾害史发生时间日3 { get; set; }

        public int? 灾害史死亡人口3 { get; set; }

        public int? 灾害史损失牲畜3 { get; set; }

        public int? 灾害史全毁房屋3 { get; set; }

        public int? 灾害史半毁房屋3 { get; set; }

        public float? 灾害史全毁农田3 { get; set; }

        public float? 灾害史半毁农田3 { get; set; }

        public float? 灾害史毁坏道路3 { get; set; }

        public int? 灾害史毁坏桥梁3 { get; set; }

        public double? 灾害史直接损失3 { get; set; }

       
        public string 灾害史灾情等级3 { get; set; }

        public int? 灾害史发生时间年4 { get; set; }

        public int? 灾害史发生时间月4 { get; set; }

        public int? 灾害史发生时间日4 { get; set; }

        public int? 灾害史死亡人口4 { get; set; }

        public int? 灾害史损失牲畜4 { get; set; }

        public int? 灾害史全毁房屋4 { get; set; }

        public int? 灾害史半毁房屋4 { get; set; }

        public float? 灾害史全毁农田4 { get; set; }

        public float? 灾害史半毁农田4 { get; set; }

        public float? 灾害史毁坏道路4 { get; set; }

        public int? 灾害史毁坏桥梁4 { get; set; }

        public double? 灾害史直接损失4 { get; set; }

       
        public string 灾害史灾情等级4 { get; set; }

        public int? 灾害史发生时间年5 { get; set; }

        public int? 灾害史发生时间月5 { get; set; }

        public int? 灾害史发生时间日5 { get; set; }

        public int? 灾害史死亡人口5 { get; set; }

        public int? 灾害史损失牲畜5 { get; set; }

        public int? 灾害史全毁房屋5 { get; set; }

        public int? 灾害史半毁房屋5 { get; set; }

        public float? 灾害史全毁农田5 { get; set; }

        public float? 灾害史半毁农田5 { get; set; }

        public float? 灾害史毁坏道路5 { get; set; }

        public int? 灾害史毁坏桥梁5 { get; set; }

        public double? 灾害史直接损失5 { get; set; }

       
        public string 灾害史灾情等级5 { get; set; }

        public float? 暴发频率 { get; set; }

       
        public string 泥石流类型 { get; set; }

        public double? 泥石流冲出方量 { get; set; }

       
        public string 泥石流规模等级 { get; set; }

        public float? 泥石流泥位 { get; set; }

       
        public string 不良地质现象 { get; set; }

       
        public string 补给段长度比 { get; set; }

       
        public string 沟口扇形地 { get; set; }

       
        public string 主沟纵坡 { get; set; }

       
        public string 新构造影响 { get; set; }

       
        public string 植被覆盖率 { get; set; }

       
        public string 冲淤变幅 { get; set; }

       
        public string 岩性因素 { get; set; }

       
        public string 松散物储量 { get; set; }

       
        public string 山坡坡度 { get; set; }

       
        public string 沟槽横断面 { get; set; }

       
        public string 松散物平均厚 { get; set; }

       
        public string 流域面积 { get; set; }

       
        public string 相对高差 { get; set; }

       
        public string 堵塞程度 { get; set; }

        public int? 评分1 { get; set; }

        public int? 评分2 { get; set; }

        public int? 评分3 { get; set; }

        public int? 评分4 { get; set; }

        public int? 评分5 { get; set; }

        public int? 评分6 { get; set; }

        public int? 评分7 { get; set; }

        public int? 评分8 { get; set; }

        public int? 评分9 { get; set; }

        public int? 评分10 { get; set; }

        public int? 评分11 { get; set; }

        public int? 评分12 { get; set; }

        public int? 评分13 { get; set; }

        public int? 评分14 { get; set; }

        public int? 评分15 { get; set; }

       
        public string 总分 { get; set; }

       
        public string 易发程度 { get; set; }

       
        public string 发展阶段 { get; set; }

       
        public string 威胁危害对象 { get; set; }

        public int? 威胁人口 { get; set; }

        public double? 威胁财产 { get; set; }

       
        public string 险情等级 { get; set; }

       
        public string 监测建议 { get; set; }

       
        public string 防治建议 { get; set; }

       
        public string 防治监测 { get; set; }

       
        public string 防治治理 { get; set; }

       
        public string 搬迁避让 { get; set; }

       
        public string 群测群防 { get; set; }

        public bool 隐患点 { get; set; }

        public bool 遥感点 { get; set; }

        public bool 勘查点 { get; set; }

        public bool 测绘点 { get; set; }

        public bool 防灾预案 { get; set; }

        public bool 多媒体 { get; set; }

        public bool 录像 { get; set; }

       
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

        public bool 示意图 { get; set; }

        public bool 矢量示意图 { get; set; }

        public string 野外记录信息 { get; set; }

       
        public string 泥石流情况 { get; set; }

       
        public string xxcs1 { get; set; }

       
        public string xxcs2 { get; set; }

       
        public string xxcs3 { get; set; }

       
        public string xxcs4 { get; set; }

       
        public string xxcs5 { get; set; }

       
        public string xxcs6 { get; set; }

       
        public string xxcs7 { get; set; }

       
        public string xxcs8 { get; set; }

       
        public string xxcs9 { get; set; }

       
        public string xxcs10 { get; set; }

       
        public string xxcs11 { get; set; }

       
        public string xxcs12 { get; set; }

       
        public string xxcs13 { get; set; }

       
        public string xxcs14 { get; set; }

       
        public string xxcs15 { get; set; }

        public int? 威胁房屋户 { get; set; }

        public float? 补给段长度值 { get; set; }

        public float? 主沟纵坡值 { get; set; }

        public float? 植被覆盖值 { get; set; }

        public float? 冲淤变幅值 { get; set; }

        public float? 松散物储量值 { get; set; }

        public float? 山坡坡度值 { get; set; }

        public float? 松散物平均厚值 { get; set; }

        public float? 流域面积值 { get; set; }

        public float? 相对高差值 { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.CoreEntities.Domain.GeoDisaster.Relocation
{
    /// <summary>
    /// 移民搬迁地面塌陷
    /// </summary>
    public class RelocationLandCollapse:BaseEntity
    {

        #region 具体属性
        //public string 统一编号 { get; set; }
        //public string 名称 { get; set; }
        public string 野外编号 { get; set; }
        public string 室内编号 { get; set; }
        //public int X坐标 { get; set; }
        //public int Y坐标 { get; set; }
        //public double 标高 { get; set; }
        //public Nullable<double> 灾害体积 { get; set; }
        //public double 威胁财产 { get; set; }
        //public int 威胁人口 { get; set; }
        //public string 经度 { get; set; }
        //public string 纬度 { get; set; }
        //public string 地理位置 { get; set; }
        //public int 死亡人口 { get; set; }
        //public string 灾情等级 { get; set; }
        //public string 险情等级 { get; set; }

        public int 单体陷坑坑号1 { get; set; }
        public string 单体陷坑形状1 { get; set; }
        public double 单体陷坑坑口规模1 { get; set; }
        public double 单体陷坑深度1 { get; set; }
        public double 单体陷坑变形面积1 { get; set; }
        public string 单体陷坑规模等级1 { get; set; }
        public string 单体陷坑长轴方向1 { get; set; }
        public double 单体陷坑充水水位深1 { get; set; }
        public double 单体陷坑水位变动1 { get; set; }
        public string 单体陷坑发生时间1 { get; set; }
        public string 单体陷坑发展变化1 { get; set; }
        public int 单体陷坑坑号2 { get; set; }
        public string 单体陷坑形状2 { get; set; }
        public double 单体陷坑坑口规模2 { get; set; }
        public double 单体陷坑深度2 { get; set; }
        public double 单体陷坑变形面积2 { get; set; }
        public string 单体陷坑规模等级2 { get; set; }
        public string 单体陷坑长轴方向2 { get; set; }
        public double 单体陷坑充水水位深2 { get; set; }
        public double 单体陷坑水位变动2 { get; set; }
        public string 单体陷坑发生时间2 { get; set; }
        public string 单体陷坑发展变化2 { get; set; }
        public int 单体陷坑坑号3 { get; set; }
        public string 单体陷坑形状3 { get; set; }
        public double 单体陷坑坑口规模3 { get; set; }
        public double 单体陷坑深度3 { get; set; }
        public double 单体陷坑变形面积3 { get; set; }
        public string 单体陷坑规模等级3 { get; set; }
        public string 单体陷坑长轴方向3 { get; set; }
        public double 单体陷坑充水水位深3 { get; set; }
        public double 单体陷坑水位变动3 { get; set; }
        public string 单体陷坑发生时间3 { get; set; }
        public string 单体陷坑发展变化3 { get; set; }
        public int 陷坑坑数 { get; set; }
        public string 陷坑分布面积 { get; set; }
        public string 排列形式 { get; set; }
        public string 长列方向 { get; set; }
        public double 最小陷坑口径 { get; set; }
        public double 最大陷坑口径 { get; set; }
        public double 最小陷坑深度 { get; set; }
        public double 最大陷坑深度 { get; set; }
        public string 始发时间 { get; set; }
        public string 盛发开始时间 { get; set; }
        public string 盛发截止时间 { get; set; }
        public string 停止时间 { get; set; }
        public string 尚在发展 { get; set; }
        public int 单缝缝号1 { get; set; }
        public string 单缝形态1 { get; set; }
        public string 单缝延伸方向1 { get; set; }
        public int 单缝倾向1 { get; set; }
        public int 单缝倾角1 { get; set; }
        public double 单缝长度1 { get; set; }
        public double 单缝宽度1 { get; set; }
        public double 单缝深度1 { get; set; }
        public string 单缝性质1 { get; set; }
        public int 单缝缝号2 { get; set; }
        public string 单缝形态2 { get; set; }
        public string 单缝延伸方向2 { get; set; }
        public int 单缝倾向2 { get; set; }
        public int 单缝倾角2 { get; set; }
        public double 单缝长度2 { get; set; }
        public double 单缝宽度2 { get; set; }
        public double 单缝深度2 { get; set; }
        public string 单缝性质2 { get; set; }
        public int 单缝缝号3 { get; set; }
        public string 单缝形态3 { get; set; }
        public string 单缝延伸方向3 { get; set; }
        public int 单缝倾向3 { get; set; }
        public int 单缝倾角3 { get; set; }
        public double 单缝长度3 { get; set; }
        public double 单缝宽度3 { get; set; }
        public double 单缝深度3 { get; set; }
        public string 单缝性质3 { get; set; }
        public int 缝数 { get; set; }
        public double 裂缝分布面积 { get; set; }
        public double 裂缝间距 { get; set; }
        public string 裂缝排列形式 { get; set; }
        public int 裂缝倾向 { get; set; }
        public int 裂缝倾角 { get; set; }
        public double 裂缝长max { get; set; }
        public double 裂缝长min { get; set; }
        public double 裂缝宽max { get; set; }
        public double 裂缝宽min { get; set; }
        public double 裂缝深max { get; set; }
        public double 裂缝深min { get; set; }
        public string 塌陷区地貌特征 { get; set; }
        public string 成因类型 { get; set; }
        public string 岩溶塌陷地层时代 { get; set; }
        public string 岩溶塌陷地层岩性 { get; set; }
        public int 岩溶塌陷岩层倾向 { get; set; }
        public int 岩溶塌陷岩层倾角 { get; set; }
        public string 岩溶塌陷断裂情况 { get; set; }
        public string 岩溶塌陷溶洞发育情况 { get; set; }
        public string 岩溶塌陷岩层发育程度 { get; set; }
        public double 岩溶塌陷塌顶溶洞埋深 { get; set; }
        public double 岩溶塌陷地下水位埋深 { get; set; }
        public string 岩溶塌陷诱发动力因素 { get; set; }
        public string 土洞塌陷单层土性 { get; set; }
        public double 土洞塌陷单层土厚 { get; set; }
        public string 土洞塌陷双层上部土性 { get; set; }
        public double 土洞塌陷双层上部土厚 { get; set; }
        public string 土洞塌陷双层下部土性 { get; set; }
        public double 土洞塌陷双层下部土厚 { get; set; }
        public string 土洞塌陷下伏基岩时代 { get; set; }
        public string 土洞塌陷下伏基岩岩性 { get; set; }
        public double 土洞塌陷地下水位埋深 { get; set; }
        public string 土洞塌陷诱发动力因素 { get; set; }
        public string 井位塌陷区方向 { get; set; }
        public double 井位塌陷区距离 { get; set; }
        public double 井位塌陷区抽水降深 { get; set; }
        public double 井位塌陷区日出水量 { get; set; }
        public string 江河水位塌陷区方向 { get; set; }
        public double 江河水位塌陷区距离 { get; set; }
        public double 江河水位塌陷区水位变幅 { get; set; }
        public string 江河水位塌陷区变化类型 { get; set; }
        public string 冒顶塌陷土层时代 { get; set; }
        public string 冒顶塌陷土层土性 { get; set; }
        public double 冒顶塌陷土层厚度 { get; set; }
        public string 冒顶塌陷岩层时代 { get; set; }
        public string 冒顶塌陷岩层岩性 { get; set; }
        public double 冒顶塌陷岩层厚度 { get; set; }
        public double 冒顶塌陷地下水位埋深 { get; set; }
        public string 冒顶塌陷诱发动力因素 { get; set; }
        public double 冒顶塌陷矿层厚度 { get; set; }
        public string 冒顶塌陷开采时间 { get; set; }
        public double 冒顶塌陷开采厚度 { get; set; }
        public double 冒顶塌陷开采深度 { get; set; }
        public string 冒顶塌陷开采方法 { get; set; }
        public double 冒顶塌陷工作面推进速度 { get; set; }
        public double 冒顶塌陷采出量 { get; set; }
        public string 冒顶塌陷顶板管理方法 { get; set; }
        public bool 冒顶塌陷重复采动 { get; set; }
        public string 冒顶塌陷采空区形态 { get; set; }
        public string 冒顶塌陷采空区规模 { get; set; }
        public double 毁坏田地 { get; set; }
        public double 毁坏房屋 { get; set; }
        public string 阻断交通 { get; set; }
        public string 地下水源枯竭 { get; set; }
        public string 地下水井突水 { get; set; }
        public string 掩埋地面物资 { get; set; }

        //public double 直接损失 { get; set; }

        public int 新增陷坑 { get; set; }
        public double 扩大陷区 { get; set; }
        public double 潜在毁田 { get; set; }
        public int 潜在毁房 { get; set; }
        public int 出现新陷区 { get; set; }
        public double 新陷区面积 { get; set; }
        public double 断路 { get; set; }
        public string 其他危害 { get; set; }



        public bool 隐患点 { get; set; }
        public bool 防灾预案 { get; set; }
        public bool 多媒体 { get; set; }
        public string 防治措施 { get; set; }
        public string 防治建议 { get; set; }
        public string 群测人员 { get; set; }
        public string 村长 { get; set; }
        public string 电话 { get; set; }
        public string 调查负责人 { get; set; }
        public string 填表人 { get; set; }
        public string 审核人 { get; set; }
        public string 调查单位 { get; set; }
        public string 填表日期 { get; set; }
        public string 阶步指向 { get; set; }
        public byte[] 平面示意图 { get; set; }
        public byte[] 剖面示意图 { get; set; }
        public string 地面塌陷情况 { get; set; }
        public string 省名 { get; set; }
        public string 县名 { get; set; }
        public string 街道 { get; set; }

        public string 平面示意图路径 { get; set; }
        public string 剖面示意图路径 { get; set; }

        #endregion
    }
}

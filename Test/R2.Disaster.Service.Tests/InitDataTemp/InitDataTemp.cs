using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using R2.Disaster.Data;
using R2.Disaster.Repository;
using R2.Disaster.CoreEntities;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using System.Collections.Generic;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Emergency;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using R2.Disaster.Service.GeoDisaster;

namespace R2.Disaster.Service.Tests
{
    [TestClass]
    public class InitDataTemp
    {
        private IDbContext _db;
        private IRepository<PhyGeoDisaster> _re;
        private IRepository<GBCode> _reGBCode;
        private IPhyGeoDisasterService _service;
        public InitDataTemp()
        {
            
        }

       //  使用 TestInitialize 在运行每个测试前先运行代码
        [TestInitialize()]
        public void MyTestInitialize()
        {
            this._db = new R2DisasterContext();
            this._re = new EFRepository<PhyGeoDisaster>(this._db);
            this._reGBCode = new EFRepository<GBCode>(this._db);
            this._service = new PhyGeoDisasterService(this._re);
        }
        

        //使用 TestCleanup 在运行完每个测试后运行代码
        [TestCleanup()]
        public void MyTestCleanup()
        {
        }


        [TestMethod]
        public void InitRequiredData()
        {
            this.InitGBCodes();
        }

        private void InitGBCodes()
        {
            GBCode gbCode = new GBCode()
            {
                Code = "370101",
                Name = "市辖区"
            };
            this._reGBCode.Insert(gbCode);
            GBCode gbCode1 = new GBCode()
            {
                Code = "370102",
                Name = "历下区"
            };
            this._reGBCode.Insert(gbCode1);
            GBCode gbCode2 = new GBCode()
            {
                Code = "370103",
                Name = "市中区"
            };
            this._reGBCode.Insert(gbCode2);
            GBCode gbCode3 = new GBCode()
            {
                Code = "370104",
                Name = "隗萌区"
            };
            this._reGBCode.Insert(gbCode3);
            GBCode gbCode4 = new GBCode()
            {
                Code = "370105",
                Name = "天桥区"
            };
            this._reGBCode.Insert(gbCode4);
        }

        [TestMethod]
        public void InitSampleData()
        {
            PhyGeoDisaster phy = new PhyGeoDisaster()
            {
                GBCodeId ="370101",
                Location = "西蒋峪村北侧",
                DisasterType = EnumGeoDisasterType.DebrisFlow,
                Name = "西蒋峪村北侧地面塌陷333",
            };
            Comprehensive c = new Comprehensive()
            {
                统一编号 = "370101040001",
                名称 = "西蒋峪村北侧地面塌陷333",
                地理位置= "西蒋峪村北侧",
                GBCodeId = "370101",
                险情等级=" 大型",
                DebrisFlow = new DebrisFlow()
                {
                    室内编号="3333333"
                }
            };

            PhyGeoDisaster phy1 = new PhyGeoDisaster()
            {
                GBCodeId = "370101",
                Location = "西蒋峪村北侧",
                DisasterType = EnumGeoDisasterType.LandFracture,
                Name = "东凤凰村地裂缝33",
                DamageReports = new List<DamageReport>()
                {
                    new DamageReport(){
                        发生时间=DateTime.Now,
                        灾险情地点="安城镇东凤凰村西南",
                    },
                    new DamageReport(){
                        发生时间=DateTime.Now.AddDays(1.5),
                        灾险情地点="安城镇东凤凰村西南",
                    }
                },
                EmergencySurveys = new List<EmergencySurvey>()
                {
                    new EmergencySurvey(){
                        应急调查点="甘井子区南关岭街道大北技校修配厂斜坡"
                    },
                    new EmergencySurvey(){
                        应急调查点="甘井子区南关岭街道大北技校修配厂斜坡"
                    }
                },
                PrePlan = new PrePlan()
                {
                    名称 = "菜园子同益乡政府东斜坡111111",
                }
            };

            Comprehensive c1 = new Comprehensive()
            {
                统一编号 = "370101060001",
                名称 = "东凤凰村地裂缝33",
                地理位置 = "西蒋峪村北侧",
                GBCodeId = "370101",
                灾害类型=EnumGeoDisasterType.LandFracture,

                险情等级 = "大型",
                LandFracture = new LandFracture()
                {
                    //统一编号 = "370101060001",
                    //名称 = "东凤凰村地裂缝33"
                    //地理位置 = "安城镇东凤凰村西南",
                    野外编号 = "dddddddd",
                }
            };

            phy1.Comprehensive = c1;
            phy.Comprehensive = c;

            this._service.New(phy);
            this._service.New(phy1);
            //Comprehensive c2 = this._re.GetById(1);
            //PrePlan p = new PrePlan()
            //{
            ////    Comprehensive = c2,
            //    名称 = "菜园子同益乡政府东斜坡77777777",
            //};
            //IRepository<PrePlan> rePre = new EFRepository<PrePlan>(this._db);
            //rePre.Insert(p);
        }

         [TestMethod]
        public void Test_Sample()
        {
            IDbContext db = new R2DisasterContext();
            IRepository<Category> re = new EFRepository<Category>(db);

            Category c = new Category()
            {
                Name = "Testname",
                Book = new Book()
                {
                    Name="TestBook",
                    Price=333
                }
            };
            re.Insert(c);
        }
    }
}

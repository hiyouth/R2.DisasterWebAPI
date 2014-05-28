using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using R2.Disaster.Service.GeoDisaster.Investigation;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using R2.Disaster.Data;
using R2.Disaster.Repository;
using R2.Disaster.CoreEntities;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;

namespace R2.Disaster.Service.Tests
{
    [TestClass]
    public class InitDataTemp
    {
        private IDbContext _db;
        private IRepository<Comprehensive> _re;
        private IRepository<GBCode> _reGBCode;
        private IComprehensiveService _service;
        public InitDataTemp()
        {
            
        }

       //  使用 TestInitialize 在运行每个测试前先运行代码
        [TestInitialize()]
        public void MyTestInitialize()
        {
            this._db = new R2DisasterContext();
            this._re = new EFRepository<Comprehensive>(this._db);
            this._reGBCode = new EFRepository<GBCode>(this._db);
            this._service = new ComprehensiveService(this._re);
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
            Comprehensive c = new Comprehensive()
            {
                统一编号 = "370101040001",
                名称 = "西蒋峪村北侧地面塌陷333",
                灾害类型 = EnumGeoDisasterType.LandCollapse,
                国标代码 = "370101",
                DebrisFlow = new DebrisFlow()
                {
                    统一编号 = "370101040001",
                    名称 = "西蒋峪村北侧地面塌陷333"
                }
            };
            Comprehensive c1 = new Comprehensive()
            {
                统一编号 = "370101060001",
                名称 = "东凤凰村地裂缝33",
                灾害类型 = EnumGeoDisasterType.LandFracture,
                国标代码 = "370102",
                LandFracture = new LandFracture()
                {
                    统一编号 = "370101060001",
                    名称 = "东凤凰村地裂缝33"
                }
            };
           this._service.New(c);
            this._service.New(c1);
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

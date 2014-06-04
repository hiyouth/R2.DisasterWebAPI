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
    public class ComprehensiveServiceTest
    {
        private IDbContext _db;
        private IRepository<Comprehensive> _re;
        private IComprehensiveService _service;
        public ComprehensiveServiceTest()
        {
            
        }

       //  使用 TestInitialize 在运行每个测试前先运行代码
        [TestInitialize()]
        public void MyTestInitialize()
        {
            this._db = new R2DisasterContext();
            this._re = new EFRepository<Comprehensive>(this._db);
            this._service = new ComprehensiveService(this._re);
        }
        

        //使用 TestCleanup 在运行完每个测试后运行代码
        [TestCleanup()]
        public void MyTestCleanup()
        {
        }
        

        [TestMethod]
        public void Test_QueryByUnifieldId()
        {
            IDbContext db = new R2DisasterContext();
            IRepository<Comprehensive> re = new EFRepository<Comprehensive>(db);
      
            IComprehensiveService service = new ComprehensiveService(re);
            string id = "370101060001";
            Comprehensive c=service.GetByUnifiedID(id);
        }


        [TestMethod]
        public void Test_InsertComperhensive()
        {

           // Comprehensive c = new Comprehensive()
           // {
           //     统一编号 = "370101040001",
           //     名称 = "西蒋峪村北侧地面塌陷333",
           //     灾害类型 = "塌陷",
           //     国标代码 = "370101",
           //     DebrisFlow = new DebrisFlow()
           //     {
           //         统一编号 = "370101040001",
           //         名称 = "西蒋峪村北侧地面塌陷333"
           //     }
           // };
           // Comprehensive c1 = new Comprehensive()
           // {
           //     统一编号 = "370101040004",
           //     名称 = "西蒋峪村北侧地面塌陷77777",
           //     灾害类型 = "塌陷",
           //     国标代码 = "370101",
           //     LandSubsidence = new LandSubsidence()
           //     {
           //         统一编号 = "370101040001",
           //         名称 = "西蒋峪村北侧地面塌陷333"
           //     }
           // };
           //this._service.New(c);
           // this._service.New(c1);
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

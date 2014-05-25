using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using R2.Disaster.Service.DisasterInvestigation;
using R2.Disaster.CoreEntities.Domain.Investigation;
using R2.Disaster.Data;
using R2.Disaster.Repository;
using R2.Disaster.CoreEntities;

namespace R2.Disaster.Service.Tests
{
    [TestClass]
    public class GHComprehensiveServiceTest
    {
        private IDbContext _db;
        private IRepository<GHComprehensive> _re;
        private IGHComprehensiveService _service;
        public GHComprehensiveServiceTest()
        {
            
        }

       //  使用 TestInitialize 在运行每个测试前先运行代码
        [TestInitialize()]
        public void MyTestInitialize()
        {
            this._db = new R2DisasterContext();
            this._re = new EFRepository<GHComprehensive>(this._db);
            this._service = new GHComprehensiveService(this._re);
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
            IRepository<GHComprehensive> re = new EFRepository<GHComprehensive>(db);
      
            IGHComprehensiveService service = new GHComprehensiveService(re);
            string id="";
            GHComprehensive c=service.GetByUnifiedID(id);
        }

        [TestMethod]
        public void Test_InsertComperhensive()
        {

            GHComprehensive c = new GHComprehensive()
            {
                统一编号 = "370101040001",
                名称 = "西蒋峪村北侧地面塌陷333",
                灾害类型 = "塌陷",
                国际代码 = "370101",
                GHDebrisFlow = new GHDebrisFlow()
                {
                    统一编号 = "370101040001",
                    名称 = "西蒋峪村北侧地面塌陷333"
                }
            };
            GHComprehensive c1 = new GHComprehensive()
            {
                统一编号 = "370101040004",
                名称 = "西蒋峪村北侧地面塌陷77777",
                灾害类型 = "塌陷",
                国际代码 = "370101",
                GHLandSubsidence = new GHLandSubsidence()
                {
                    统一编号 = "370101040001",
                    名称 = "西蒋峪村北侧地面塌陷333"
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

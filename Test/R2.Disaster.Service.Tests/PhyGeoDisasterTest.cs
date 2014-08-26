using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using R2.Disaster.Data;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.Repository;
using R2.Disaster.Service.GeoDisaster.Investigation;
using R2.Disaster.Service.GeoDisaster;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using System.Linq;
using R2.Disaster.CoreEntities;

namespace R2.Disaster.Service.Tests
{
    /// <summary>
    /// PhyGeoDisasterTest 的摘要说明
    /// </summary>
    [TestClass]
    public class PhyGeoDisasterTest
    {
        private IDbContext _db;
        private IRepository<PhyGeoDisaster> _re;
        private IPhyGeoDisasterService _service;
        private IRepository<Book> _reBook;
        public PhyGeoDisasterTest()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        [TestInitialize()]
        public void MyTestInitialize()
        {
            this._db = new R2DisasterContext();
            this._re = new EFRepository<PhyGeoDisaster>(this._db);
            this._reBook = new EFRepository<Book>(this._db);
            this._service = new PhyGeoDisasterService(this._re);
        }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Test_Insert()
        {

            List<Comprehensive> lists = new List<Comprehensive>();

            Comprehensive c = new Comprehensive()
            {
                统一编号 = "370101040001",
                名称 = "西蒋峪村北侧地面塌陷333",
                灾害类型 = EnumGeoDisasterType.DebrisFlow,
                GBCodeId = "370101",
                地理位置 = "西蒋峪村北侧地面塌陷333",
                DebrisFlow = new DebrisFlow()
                {
                    野外编号 = "dsadfasdfasfd",
                    //   统一编号 = "370101040001",
                }
            };
            lists.Add(c);
            PhyGeoDisaster phy = new PhyGeoDisaster()
            {
                Comprehensives = lists
            };
            this._service.New(phy);
        }
        [TestMethod]
        public void GetByCustomizeId()
        {
            //var queryResult = (from a in this._re.Table
            //                   where a.CustomizeId == "1"
            //                   select a).FirstOrDefault();            
            var query = from b in this._reBook.Table
                        where b.Name == "ddddd"
                        select b;
            var book = query.FirstOrDefault<Book>();
        }
    }
}

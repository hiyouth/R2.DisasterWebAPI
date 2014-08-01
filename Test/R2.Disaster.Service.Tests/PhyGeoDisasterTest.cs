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
            this._service = new PhyGeoDisasterService(this._re);
        }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestUpdateNavigatorPropertySubValue()
        {
            //PhyGeoDisaster p=this._service.GetById(2);
            //string temp = p.PrePlan.名称+"abcedfg";
            //p.PrePlan.名称 = temp;
            //this._service.Update(p);

            //PhyGeoDisaster pfinal = this._service.GetById(2);
            //Assert.AreEqual(temp, pfinal.PrePlan.名称);
        }

        [TestMethod]
        public void TestUpdateNavigatorComplexObject()
        {
            //PhyGeoDisaster p = this._service.GetById(1);
            //Assert.IsNull(p.PrePlan);
            //PrePlan newlyPreplan = new PrePlan()
            //{
            //    Id = p.Id,
            //    名称="That is a test name for testing",
            //    地理位置="测试地理位置",
            //};
            //p.PrePlan = newlyPreplan;
            //this._service.Update(p);
            //PhyGeoDisaster p1 = this._service.GetById(1);
            //Assert.IsNotNull(p1);
            //Assert.IsNotNull(p1.PrePlan);
            //Assert.AreEqual(p1.PrePlan.地理位置, "测试地理位置");
            //p1.PrePlan = null;
            //this._service.Update(p1);
            //PhyGeoDisaster p2 = this._service.GetById(1);
            //Assert.IsNotNull(p2);
            //Assert.IsNull(p2.PrePlan);
        }
    }
}

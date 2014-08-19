using Microsoft.VisualStudio.TestTools.UnitTesting;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using R2.Disaster.Data;
using R2.Disaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.WebAPI.Controllers;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.Service.GeoDisaster;
using R2.Disaster.WebAPI.Controllers.GeoDisaster;
using R2.Disaster.WebAPI.Model;
using AutoMapper;
using R2.Disaster.Service.GeoDisaster.Investigation;
using R2.Disaster.WebAPI.Controllers.GeoDisaster.Investigation;

namespace R2.Disaster.WebAPI.Tests
{
    [TestClass]
    public class PhyDisasterControllerTest
    {
        private IDbContext _db;
        private IRepository<PhyGeoDisaster> _re;
        //private IRepository<GBCode> _reGBCode;
        private IPhyGeoDisasterService _service;
        private PhyGeoDisasterController _controller;

        public PhyDisasterControllerTest()
        {
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            this._db = new R2DisasterContext();
            this._re = new EFRepository<PhyGeoDisaster>(this._db);
            //this._reGBCode = new EFRepository<GBCode>(this._db);
            this._service = new PhyGeoDisasterService(this._re);
            this._controller = new PhyGeoDisasterController(this._service);
        }

        [TestMethod]
        public void TestUpdateAttached()
        {
            List<Comprehensive> lists1 = new List<Comprehensive>();
            
            Comprehensive c1 = new Comprehensive()
            {
                Id=1,
                统一编号 = "370101040001",
                名称 = "西蒋峪村北侧地面塌陷00000000",
                灾害类型 = EnumGeoDisasterType.DebrisFlow,
                GBCodeId = "370101",
                地理位置 = "西蒋峪村北侧地面塌陷333",
                DebrisFlow = new DebrisFlow()
                {
                    Id = 1,
                    野外编号 = "ccccccccc",
                    //   统一编号 = "370101040001",
                },
                PhyGeoDisasterId =1
            };
            lists1.Add(c1);
            PhyGeoDisaster phy1 = new PhyGeoDisaster()
            {
                Id=1,
                Comprehensives = lists1
            };
            this._service.UpdateRelationAttached(phy1);
        }

        [TestMethod]
        //[ExpectedException(typeof(Exception))]
        public void TestNewPhySet()
        {
            //IDbContext db = new R2DisasterContext();
            //IRepository<Comprehensive> re = new EFRepository<Comprehensive>(db);
            //IComprehensiveService s = new ComprehensiveService(re);
            //InvestigationController c = new InvestigationController(s);
            //string a=null;
            //c.GetCompleteByUId(a);
            List<Comprehensive> lists1 = new List<Comprehensive>();
            List<Comprehensive> lists2 = new List<Comprehensive>();


            Comprehensive c1 = new Comprehensive()
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

            Comprehensive c2 = new Comprehensive()
            {
                统一编号 = "370101040002",
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

            lists1.Add(c1);
            lists2.Add(c2);
            PhyGeoDisaster phy1 = new PhyGeoDisaster()
            {
                Comprehensives = lists1
            };
            PhyGeoDisaster phy2 = new PhyGeoDisaster()
            {
                Comprehensives = lists2
            };

            List<Object> ids=this._controller.NewSet(new List<PhyGeoDisaster>()
            {
                phy1,phy2
            });
            Assert.IsNotNull(ids);
            Assert.AreNotEqual(0, ids.Count);
            Assert.AreNotEqual(null, ids[0]);
        }


    }
}

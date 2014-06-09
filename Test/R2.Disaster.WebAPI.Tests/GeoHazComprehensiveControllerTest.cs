﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

namespace R2.Disaster.WebAPI.Tests
{
    [TestClass]
    public class GeoHazComprehensiveControllerTest
    {
        private IDbContext _db;
        private IRepository<Comprehensive> _re;
        private IRepository<GBCode> _reGBCode;
        private IComprehensiveService _service;

        public GeoHazComprehensiveControllerTest()
        {
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            this._db = new R2DisasterContext();
            this._re = new EFRepository<Comprehensive>(this._db);
            this._reGBCode = new EFRepository<GBCode>(this._db);
            this._service = new ComprehensiveService(this._re);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestGetByUIdCanNotBeNull()
        {
            IDbContext db = new R2DisasterContext();
            IRepository<Comprehensive> re = new EFRepository<Comprehensive>(db);
            IComprehensiveService s = new ComprehensiveService(re);
            GeoDisasterController c = new GeoDisasterController(s);
            string a=null;
            c.GetByUIdCompletely(a);
        }

          [TestMethod]
        public void TestAutoMapper()
        {
            ComprehensiveModel model = new ComprehensiveModel()
            {
                地理位置="测试地理位置",
                灾害类型=EnumGeoDisasterType.DebrisFlow,
                GBCodeId ="370103"
            };
            Mapper.CreateMap<ComprehensiveModel, Comprehensive>();
            Comprehensive c = Mapper.Map<ComprehensiveModel, Comprehensive>(model);
            Assert.AreEqual("测试地理位置", c.地理位置);
            Assert.AreEqual(EnumGeoDisasterType.DebrisFlow, c.灾害类型);
            Assert.AreEqual("370103", c.GBCodeId);
        }

          [TestMethod]
          public void TestAutoMapper2()
          {
              ComprehensiveModel model = new ComprehensiveModel()
              {
                  地理位置 = "测试地理位置",
                  灾害类型 = EnumGeoDisasterType.DebrisFlow,
                  GBCodeId = "370103"
              };
              Mapper.CreateMap<ComprehensiveModel, Comprehensive>();
              Comprehensive c = Mapper.Map<ComprehensiveModel, Comprehensive>(model);
              Assert.AreSame("测试地理位置", c.地理位置);
              //Assert.AreSame(EnumGeoDisasterType.DebrisFlow, c.灾害类型);
              Assert.AreSame("370103", c.GBCodeId);
          }
    }
}

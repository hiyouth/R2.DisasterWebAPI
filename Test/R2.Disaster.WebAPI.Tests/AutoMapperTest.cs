using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using R2.Disaster.WebAPI.Model;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using AutoMapper;
using R2.Disaster.Data;
using R2.Disaster.Repository;
using R2.Disaster.Service.GeoDisaster;
using R2.Disaster.Service.GeoDisaster.Investigation;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using R2.Disaster.WebAPI.Model.Investigation;

namespace R2.Disaster.WebAPI.Tests
{
    [TestClass]
    public class AutoMapperTest
    {
         private IDbContext _db;
        private IRepository<DebrisFlow> _re;
        private IRepository<GBCode> _reGBCode;
        private IDebrisFlowService _service;

        public AutoMapperTest()
        {
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            this._db = new R2DisasterContext();
            this._re = new EFRepository<DebrisFlow>(this._db);
            this._reGBCode = new EFRepository<GBCode>(this._db);
            this._service = new DebrisFlowService(this._re);
        }
        [TestMethod]
        public void TestAutoMapperPlainCopy()
        {
            //ComprehensiveModel model = new ComprehensiveModel()
            //{
            //    名称 = "测试地理位置",
            //    灾害类型 = EnumGeoDisasterType.DebrisFlow,
            //    GBCodeId = "370103"
            //};
            //Mapper.CreateMap<ComprehensiveModel, Comprehensive>();
            //Comprehensive c = Mapper.Map<ComprehensiveModel, Comprehensive>(model);
            //Assert.AreEqual("测试地理位置", c.地理位置);
            //Assert.AreEqual(EnumGeoDisasterType.DebrisFlow, c.灾害类型);
            //Assert.AreEqual("370103", c.GBCodeId);
        }

        [TestMethod]
        public void TestAutoMapper2()
        {
            //ComprehensiveModel model = new ComprehensiveModel()
            //{
            //    地理位置 = "测试地理位置",
            //    灾害类型 = EnumGeoDisasterType.DebrisFlow,
            //    GBCodeId = "370103"
            //};
            //Mapper.CreateMap<ComprehensiveModel, Comprehensive>();
            //Comprehensive c = Mapper.Map<ComprehensiveModel, Comprehensive>(model);
            //Assert.AreSame("测试地理位置", c.地理位置);
            ////Assert.AreSame(EnumGeoDisasterType.DebrisFlow, c.灾害类型);
            //Assert.AreSame("370103", c.GBCodeId);
        }

        [TestMethod]
        public void TestComplexAutoMapper()
        {
            DebrisFlow d=this._service.GetById(1);
            
            
            var comprehensiveModel = new ComprehensiveModel();
            Mapper.CreateMap<Comprehensive, ComprehensiveModel>();
            Mapper.CreateMap<DebrisFlow, DebrisFlowModel>()
                .ForMember("ComprehensiveModel", o => o.UseValue(d.Comprehensive));
            DebrisFlowModel m = Mapper.Map<DebrisFlow, DebrisFlowModel>
                (d);
        }
    }
}

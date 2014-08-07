using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Monitor;
using System.Collections.Generic;
using System.Linq;
using R2.Disaster.Service.Monitor;
using R2.Domain.Model.Monitor;
using AutoMapper;

namespace R2.Disaster.Service.Tests.Monitor
{
    [TestClass]
    public class RainfallServiceTest
    {
        private List<Rainfall> _rainfalls;
        [TestInitialize()]
        public void MyTestInitialize()
        {
            this.InitTestData();
            //this._db = new R2DisasterContext();
            //this._re = new EFRepository<DebrisFlow>(this._db);
            //this._reGBCode = new EFRepository<GBCode>(this._db);
            //this._service = new DebrisFlowService(this._re);
            //this._serviceCpl = new ComprehensiveService(new EFRepository<Comprehensive>(this._db));
        }

        private void InitTestData()
        {
            Rainfall rainfall1 = new Rainfall()
            {
                Value = 1,
                RainfallStation = new RainfallStation()
                {
                    StationId = "D1010",
                    StationName = "A"
                },
                CollectTime = new DateTime(2014,6,29,17,10,0)
            };
            Rainfall rainfall2 = new Rainfall()
            {
                Value = 1.01,
                RainfallStation = new RainfallStation()
                {
                    StationId = "D2020",
                    StationName = "B"
                },
                 CollectTime = new DateTime(2014,7,1,17,10,0)
            };
            Rainfall rainfall3 = new Rainfall()
            {
                Value = 1.01,
                RainfallStation = new RainfallStation()
                {
                    StationId = "D2020",
                    StationName = "B"
                },
                 CollectTime = new DateTime(2014,6,30,17,10,0)
            };
            List<Rainfall> rainfalls = new List<Rainfall> { rainfall1, rainfall2, rainfall3 };
            this._rainfalls = rainfalls;
        }

        [TestMethod]
        public void TestRainfallSumGroup()
        {
            Mapper.CreateMap<IQueryable<Rainfall>, SumRainfall>()
           .ForMember(s => s.SumValue, opt => opt.MapFrom(a => a.Sum(r => r.Value)))
           .ForMember(s => s.RainfallStation, opt => opt.MapFrom(g => g.FirstOrDefault().RainfallStation));
            //   var map=Mapper.FindTypeMapFor<IQueryable<Rainfall>, SumRainfall>();
            // Mapper.DynamicMap(true, SumRainfall);
            List<SumRainfall> sumrainfalls = RainfallService.GetGroupFromSources<Rainfall, SumRainfall>
                (this._rainfalls.AsQueryable(), r => r.RainfallStation.Id).ToList();
            Assert.AreEqual(2, sumrainfalls.Count);
            Assert.AreEqual(1, sumrainfalls[0].SumValue);
            Assert.AreEqual(2.02, sumrainfalls[1].SumValue);
            Assert.IsNotNull(sumrainfalls[0].RainfallStation);
            Assert.IsNotNull(sumrainfalls[1].RainfallStation);
            Assert.AreEqual("D1010", sumrainfalls[0].RainfallStation.Id);
        }

        [TestMethod]
        public void TestRainfallStationIdGroup()
        {
            Mapper.CreateMap<Rainfall, RainfallTimeAndValue>();
            Mapper.CreateMap<IQueryable<Rainfall>, RainfallGroupedByStation>()
                .ForMember(r => r.RainfallStation, opt => opt.MapFrom(g => g.FirstOrDefault().RainfallStation))
                .ForMember(r => r.RainfallTimeAndValues, opt => opt.MapFrom(g => g));
            List<RainfallGroupedByStation> rainfallGroups = RainfallService.GetGroupFromSources<Rainfall,
                RainfallGroupedByStation>(this._rainfalls.AsQueryable(), r => r.RainfallStation.Id).ToList();
            Assert.AreEqual(2, rainfallGroups.Count);
            Assert.AreEqual("D2020", rainfallGroups[1].RainfallStation.Id);
            Assert.AreEqual(new DateTime(2014, 7, 1, 17, 10, 0), rainfallGroups[1].RainfallTimeAndValues[0].CollectTime);
            Assert.AreEqual(1.01, rainfallGroups[1].RainfallTimeAndValues[1].Value);
        }

        [TestCleanup]
        public void MyTestCleanUp()
        {
            this._rainfalls = null;
        }
    }
}

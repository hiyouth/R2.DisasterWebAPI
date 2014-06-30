using Microsoft.VisualStudio.TestTools.UnitTesting;
using R2.Disaster.WebAPI.Model;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using AutoMapper;
using R2.Disaster.Data;
using R2.Disaster.Repository;
using R2.Disaster.Service.GeoDisaster.Investigation;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using R2.Disaster.WebAPI.Model.Investigation;
using System.Collections.Generic;
using System.Linq;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Monitor;
using R2.Domain.Model.Monitor;
using R2.Disaster.Service.Monitor;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace R2.Disaster.WebAPI.Tests
{
    [TestClass]
    public class AutoMapperTest
    {
         private IDbContext _db;
        private IRepository<DebrisFlow> _re;
        private IRepository<GBCode> _reGBCode;
        private IDebrisFlowService _service;
        private IComprehensiveService _serviceCpl;

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
            this._serviceCpl = new ComprehensiveService(new EFRepository<Comprehensive>(this._db));
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
            
            
            var comprehensiveModel = new ComprehensiveSimplify();
            Mapper.CreateMap<Comprehensive, ComprehensiveSimplify>();
            Mapper.CreateMap<DebrisFlow, DebrisFlowModel>()
                .ForMember("ComprehensiveModel", o => o.MapFrom(e => e.Comprehensive));
            DebrisFlowModel m = Mapper.Map<DebrisFlow, DebrisFlowModel>
                (d);
        }

        [TestMethod]
        public void TestComprehensiveToComprehensiveModel()
        {
            Comprehensive c= this._serviceCpl.Get(1);

            Mapper.CreateMap<Comprehensive, ComprehensiveSimplify>();
             ComprehensiveSimplify model = Mapper.Map<ComprehensiveSimplify>(c);
          //   model = Mapper.Map(c.PhyGeoDisaster, model);
        }

        [TestMethod]
        public void TestSample()
        {
            Comprehensive cmp = new Comprehensive()
            {
                Id = 1,
                名称 = "1111",
                //PhyGeoDisaster = new PhyGeoDisaster()
                //{
                //    Location="dddddd"
                //}
            };
            Mapper.CreateMap<Comprehensive, ComprehensiveSimplify>();
            ComprehensiveSimplify model = Mapper.Map<ComprehensiveSimplify>(cmp);
            Assert.AreEqual("1111", model.名称);
            Assert.AreEqual("dddddd", model.地理位置);
        }

        [TestMethod]
        public void TestAutoMapperGroupLinq()
        {
            Rainfall rainfall1 = new Rainfall()
            {
                Value = 1,
                RainfallStation = new RainfallStation()
                {
                    Id = "D1010",
                    StationName = "A"
                }
            };
            Rainfall rainfall2 = new Rainfall()
            {
                Value = 1.01,
                RainfallStation = new RainfallStation()
                {
                    Id = "D2020",
                    StationName = "B"
                }
            };
            Rainfall rainfall3 = new Rainfall()
            {
                Value = 1.01,
                RainfallStation = new RainfallStation()
                {
                    Id = "D2020",
                    StationName = "B"
                }
            };
            List<Rainfall> rainfalls = new List<Rainfall> { rainfall1,rainfall2,rainfall3};
            Mapper.CreateMap<IQueryable<Rainfall>, SumRainfall>()
           .ForMember(s => s.SumValue, opt => opt.MapFrom(a => a.Sum(r => r.Value)));
            List<SumRainfall> sumrainfalls = RainfallService.GetSumFromRainfalls(DateTime.Now,DateTime.Now,
                rainfalls.AsQueryable()).ToList();
            Assert.AreEqual(2,sumrainfalls.Count);
            Assert.AreEqual(1, sumrainfalls[0].SumValue);
            Assert.AreEqual(2.02, sumrainfalls[1].SumValue);
        }

        [TestMethod]
        public void TestAutoMapperFlattingSample()
        {
            var customer = new Customer
            {
                Name = "George Costanza"
            };
            var order = new Order
            {
                Customer = customer
            };
            var bosco = new Product
            {
                Name = "Bosco",
                Price = 4.99m
            };
            order.AddOrderLineItem(bosco, 15);

            // Configure AutoMapper
           // Mapper.Initialize(cfg=>cfg.SourceMemberNamingConvention=
           
            Mapper.CreateMap<Order, OrderDto>();
            Mapper.AssertConfigurationIsValid();

            // Perform mapping

            OrderDto dto = Mapper.Map<Order, OrderDto>(order);

            Assert.AreEqual("George Costanza", dto.Name);
            Assert.AreEqual(74.85m, dto.Total);

        }
    }

    #region TestClass
    public class Order
    {
        private readonly IList<OrderLineItem> _orderLineItems = new List<OrderLineItem>();

        public Customer Customer { get; set; }

        public OrderLineItem[] GetOrderLineItems()
        {
            return _orderLineItems.ToArray();
        }

        public void AddOrderLineItem(Product product, int quantity)
        {
            _orderLineItems.Add(new OrderLineItem(product, quantity));
        }

        public decimal GetTotal()
        {
            return _orderLineItems.Sum(li => li.GetTotal());
        }
    }

    public class Product
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
    }

    public class OrderLineItem
    {
        public OrderLineItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        public decimal GetTotal()
        {
            return Quantity * Product.Price;
        }
    }

    public class Customer
    {
        public string Name { get; set; }
    }

    public class OrderDto
    {
        public string Name { get; set; }
        public decimal Total { get; set; }
    }


    #endregion
}

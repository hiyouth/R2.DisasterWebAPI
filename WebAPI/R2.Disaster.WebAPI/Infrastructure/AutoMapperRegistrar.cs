using AutoMapper;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Monitor;
using R2.Disaster.WebAPI.Model;
using R2.Disaster.WebAPI.Model.Investigation;
using R2.Domain.Model.Monitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R2.Disaster.WebAPI.Infrastructure
{
    public class AutoMapperRegistrar
    {
        public void Register()
        {
            //Mapper.CreateMap<PhyGeoDisaster, ComprehensiveSimplify>();
            Mapper.CreateMap<Comprehensive, ComprehensiveSimplify>();
            Mapper.CreateMap<ComprehensiveSimplify, Comprehensive>();
            Mapper.CreateMap<PhyGeoDisaster, PhyGeoDisasterSimplify>();

            //用于配置一组Rainfall通过StationId分组后向SumRainfall投影
            Mapper.CreateMap<IQueryable<Rainfall>, SumRainfall>()
           .ForMember(s => s.SumValue, opt => opt.MapFrom(a => a.Sum(r => r.Value)))
           .ForMember(s => s.RainfallStation, opt => opt.MapFrom(g => g.FirstOrDefault().RainfallStation));

            //配置一组Rainfall通过StationId分组后向RainfallGroupedByStation类型投影
            Mapper.CreateMap<Rainfall, RainfallTimeAndValue>();
            Mapper.CreateMap<IQueryable<Rainfall>, RainfallGroupedByStation>()
                .ForMember(r => r.RainfallStation, opt => opt.MapFrom(g => g.FirstOrDefault().RainfallStation))
                .ForMember(r => r.RainfallTimeAndValues, opt => opt.MapFrom(g => g));

            //配置泥石流到泥石流实体的投影
            //Mapper.CreateMap<DebrisFlow, DebrisFlowModel>()
            //    .ForMember(d => d.ComprehensiveSimplify, opt => opt.MapFrom(d => d.Comprehensive));
        }
    }
}
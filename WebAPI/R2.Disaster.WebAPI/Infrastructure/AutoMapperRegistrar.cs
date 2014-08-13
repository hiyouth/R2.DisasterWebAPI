using AutoMapper;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Emergency;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Monitor;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.PotentialThreats;
using R2.Disaster.WebAPI.Infrastructure.AutoMapperResolvers;
using R2.Disaster.WebAPI.Model;
using R2.Disaster.WebAPI.Model.Investigation;
using R2.Disaster.WebAPI.ServiceModel.GeoDisaster;
using R2.Domain.Model.Monitor;
using System;
using System.Collections;
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

            //Mapper.CreateMap<Comprehensive,bool>().
            Mapper.CreateMap<PhyGeoDisaster, PhyAttributeIndicator>()
                .ForMember(dest => dest.HasInvestigation,
                opt => opt.ResolveUsing<AttributeExitedResolver<PhyGeoDisaster, Comprehensive>>().ConstructedBy(() => new AttributeExitedResolver<PhyGeoDisaster, Comprehensive>("Comprehensives")))
                .ForMember(dest => dest.HasAvoidRiskCards,
                opt => opt.ResolveUsing<AttributeExitedResolver<PhyGeoDisaster, AvoidRiskCard>>().ConstructedBy(() => new AttributeExitedResolver<PhyGeoDisaster, AvoidRiskCard>("AvoidRiskCards")))
                .ForMember(dest => dest.HasDamageReports,
                opt => opt.ResolveUsing<AttributeExitedResolver<PhyGeoDisaster, DamageReport>>().ConstructedBy(() => new AttributeExitedResolver<PhyGeoDisaster, DamageReport>("DamageReports")))
                    .ForMember(dest => dest.HasEmergencySurveys,
                opt => opt.ResolveUsing<AttributeExitedResolver<PhyGeoDisaster, EmergencySurvey>>().ConstructedBy(() => new AttributeExitedResolver<PhyGeoDisaster, EmergencySurvey>("EmergencySurveys")))
                    .ForMember(dest => dest.HasMassPatrols,
                opt => opt.ResolveUsing<AttributeExitedResolver<PhyGeoDisaster, MassPatrol>>().ConstructedBy(() => new AttributeExitedResolver<PhyGeoDisaster, MassPatrol>("MassPatrols")))
                     .ForMember(dest => dest.HasMassPres,
                opt => opt.ResolveUsing<AttributeExitedResolver<PhyGeoDisaster, MassPre>>().ConstructedBy(() => new AttributeExitedResolver<PhyGeoDisaster, MassPre>("MassPres")))
                   .ForMember(dest => dest.HasPrePlans,
                opt => opt.ResolveUsing<AttributeExitedResolver<PhyGeoDisaster, PrePlan>>().ConstructedBy(() => new AttributeExitedResolver<PhyGeoDisaster, PrePlan>("PrePlans")))
                   .ForMember(dest => dest.HasThreats,
                opt => opt.ResolveUsing<AttributeExitedResolver<PhyGeoDisaster, Threat>>().ConstructedBy(() => new AttributeExitedResolver<PhyGeoDisaster, Threat>("Threats")))
                 .ForMember(dest => dest.HasWorkingGuideCards,
                opt => opt.ResolveUsing<AttributeExitedResolver<PhyGeoDisaster, WorkingGuideCard>>().ConstructedBy(() => new AttributeExitedResolver<PhyGeoDisaster, WorkingGuideCard>("WorkingGuideCards")));
              
                //.ForMember(dest => dest.HasMassPres,
                //    opt => opt.ResolveUsing < AttributeExitedResolver<ICollection<MassPre>>>());
               
            //Mapper.CreateMap<Foo, Bar>()
            //    .ForMember("baz", opt => opt.Condition(src => (src.b >= 0)));
            //配置泥石流到泥石流实体的投影
            //Mapper.CreateMap<DebrisFlow, DebrisFlowModel>()
            //    .ForMember(d => d.ComprehensiveSimplify, opt => opt.MapFrom(d => d.Comprehensive));
        }
    }

    class Foo
    {
        public int baz;
    }

    class Bar
    {
        public uint baz;
    }
}
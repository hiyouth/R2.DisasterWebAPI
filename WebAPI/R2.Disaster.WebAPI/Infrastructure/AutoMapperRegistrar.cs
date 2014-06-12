using AutoMapper;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using R2.Disaster.WebAPI.Model;
using R2.Disaster.WebAPI.Model.Investigation;
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
        }
    }
}
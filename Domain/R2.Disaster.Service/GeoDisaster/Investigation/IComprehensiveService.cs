﻿using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace R2.Disaster.Service.GeoDisaster.Investigation
{
    public interface IComprehensiveService:ICanExecuteExpress<Comprehensive>
    {
        Comprehensive GetByUnifiedID(string uid);
        void New(Comprehensive ghc);
        IQueryable<Comprehensive> GetSimilarByUnifiedId(string uid);
        IQueryable<Comprehensive> GetByName(string name);
        Comprehensive GetById(int id);
        IQueryable<Comprehensive> GetByContions(List<string> gbCodes,
            List<string> situationLevs, List<string> dangerousLevs, List<EnumGeoDisasterType> types);
        IQueryable<Comprehensive> GetByKeyWord(string keyWord);
        IQueryable<Comprehensive> GetByRect(double x1, double x2, double y1, double y2);
        IQueryable<Comprehensive> GetByCircle(double x, double y, double radious);
    }
}

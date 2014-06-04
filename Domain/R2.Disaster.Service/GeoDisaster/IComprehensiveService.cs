using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace R2.Disaster.Service.GeoDisaster
{
    public interface IComprehensiveService
    {
        Comprehensive GetByUnifiedID(string uid);
        void New(Comprehensive ghc);
        IQueryable<Comprehensive> GetSimilarByUnifiedId(string uid);
        IQueryable<Comprehensive> GetByName(string name);
    }
}

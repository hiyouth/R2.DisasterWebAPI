using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace R2.Disaster.Service.GeoDisaster.Investigation
{
    public interface IComprehensiveService
    {
        Comprehensive GetByUnifiedID(string uid);
        void New(Comprehensive ghc);
    }
}

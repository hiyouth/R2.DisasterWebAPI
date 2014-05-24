using R2.Disaster.CoreEntities.Domain.DisasterInvestigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace R2.Disaster.Service.DisasterInvestigation
{
    public interface IGHComprehensiveService
    {
        GHComprehensive GetByUnifiedID(string uid);
        void New(GHComprehensive ghc);
    }
}

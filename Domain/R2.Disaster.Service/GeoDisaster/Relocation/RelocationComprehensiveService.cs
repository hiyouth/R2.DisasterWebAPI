using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Relocation;
using R2.Disaster.Repository;

namespace R2.Disaster.Service.GeoDisaster.Relocation
{
    public class RelocationComprehensiveService:PhyRelationEntityService<RelocationComprehensive>
        ,IRelocationComprehensiveService
    {
        private IRepository<RelocationComprehensive> _repositoryRelocation;

        public RelocationComprehensiveService(IRepository<RelocationComprehensive> repository)
            : base(repository)
        {
            this._repositoryRelocation = repository;
        }
    }
}

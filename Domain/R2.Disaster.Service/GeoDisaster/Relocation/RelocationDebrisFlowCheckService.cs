using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Relocation;
using R2.Disaster.Repository;

namespace R2.Disaster.Service.GeoDisaster.Relocation
{
    public class RelocationDebrisFlowCheckService : PhyRelationEntityService<RelocationDebrisFlowCheck>
        ,IRelocationDebrisFlowCheckService
    {
        private IRepository<RelocationDebrisFlowCheck> _repositoryDebris;

        public RelocationDebrisFlowCheckService(IRepository<RelocationDebrisFlowCheck> repositoryDebris)
            : base(repositoryDebris)
        {
            this._repositoryDebris = repositoryDebris;
        }
    }
}

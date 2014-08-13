using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Relocation;
using R2.Disaster.Repository;

namespace R2.Disaster.Service.GeoDisaster.Relocation
{
    public class RelocationLandCollapseCheckService : PhyRelationEntityService<RelocationLandCollapseCheck>
        , IRelocationLandCollapseCheckService
    {
        private IRepository<RelocationLandCollapseCheck> _repositoryLandCollapse;

        public RelocationLandCollapseCheckService(IRepository<RelocationLandCollapseCheck> repositoryLandCollapse)
            : base(repositoryLandCollapse)
        {
            this._repositoryLandCollapse = repositoryLandCollapse;
        }
    }
}

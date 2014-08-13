using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Relocation;
using R2.Disaster.Repository;

namespace R2.Disaster.Service.GeoDisaster.Relocation
{
    public class RelocationSlopeCheckService : PhyRelationEntityService<RelocationSlopeCheck>
        , IRelocationSlopeCheckService
    {
        private IRepository<RelocationSlopeCheck> _repositorySlope;


        public RelocationSlopeCheckService(IRepository<RelocationSlopeCheck> repositorySlope)
            : base(repositorySlope)
        {
            this._repositorySlope = repositorySlope;
        }
    }
}

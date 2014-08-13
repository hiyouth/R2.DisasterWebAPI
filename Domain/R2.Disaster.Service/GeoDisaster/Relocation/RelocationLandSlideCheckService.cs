using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Relocation;
using R2.Disaster.Repository;

namespace R2.Disaster.Service.GeoDisaster.Relocation
{
    public class RelocationLandSlideCheckService : PhyRelationEntityService<RelocationLandSlideCheck>
        , IRelocationLandSlideCheckService
    {
        private IRepository<RelocationLandSlideCheck> _repositoryLandSlide;

        public RelocationLandSlideCheckService(IRepository<RelocationLandSlideCheck> repositoryLandSlide)
            : base(repositoryLandSlide)
        {
            this._repositoryLandSlide = repositoryLandSlide;
        }
    }
}

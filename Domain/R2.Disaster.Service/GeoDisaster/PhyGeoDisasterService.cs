using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.GeoDisaster
{
    public class PhyGeoDisasterService:DomainServiceBase<PhyGeoDisaster>,IPhyGeoDisasterService
    {
        private IRepository<PhyGeoDisaster> _repositoryPhy;
        public PhyGeoDisasterService(IRepository<PhyGeoDisaster> repositoryPhy)
            :base(repositoryPhy)
        {
            this._repositoryPhy = repositoryPhy;
        }

        public void New(PhyGeoDisaster phy)
        {
            this._repositoryPhy.Insert(phy);
        }
    }
}

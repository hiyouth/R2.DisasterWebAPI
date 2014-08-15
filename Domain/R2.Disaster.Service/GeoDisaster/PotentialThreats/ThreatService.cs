using R2.Disaster.CoreEntities.Domain.GeoDisaster.PotentialThreats;
using R2.Disaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.GeoDisaster.PotentialThreats
{
    public class ThreatService:PhyRelationEntityService<Threat>,IThreatService
    {
        public ThreatService(IRepository<Threat> repositoryThreat)
            :base(repositoryThreat)
        {

        }

        public int ChangeActiveStatus(int id, bool isActive)
        {
            throw new NotImplementedException();
        }

        public int ChangeActiveStatusByPhyId(int phyId, bool isActive)
        {
            throw new NotImplementedException();
        }
    }
}

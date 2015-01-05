using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using R2.Disaster.Repository;

namespace R2.Disaster.Service.GeoDisaster.MassPres
{
    public class AvoidRiskCardService : PhyRelationEntityService<AvoidRiskCard>, IAvoidRiskCardService
    {

        private IRepository<AvoidRiskCard> _repository;
        public AvoidRiskCardService(IRepository<AvoidRiskCard> repository)
            : base(repository)
        {
            this._repository = repository;
        }

        public IQueryable<AvoidRiskCard> GetByUId(string uid)
        {
            var query = from c in this._repository.Table
                        where c.统一编号 == uid
                        select c;
            return query;
        }
    }
}

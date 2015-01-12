using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using R2.Disaster.Repository;

namespace R2.Disaster.Service.GeoDisaster.MassPres
{
    public class WorkingGuideCardFSService : PhyRelationEntityService<WorkingGuideCardFS>, IWorkingGuideCardFSService
    {
        private IRepository<WorkingGuideCardFS> _repository;
        public WorkingGuideCardFSService(IRepository<WorkingGuideCardFS> repository)
            : base(repository)
        {
            this._repository = repository;
        }

        public IQueryable<WorkingGuideCardFS> GetByUid(string uid)
        {
            var query = from c in this._repository.Table
                        where c.统一编号 == uid
                        select c;
            return query;
        }
    }
}

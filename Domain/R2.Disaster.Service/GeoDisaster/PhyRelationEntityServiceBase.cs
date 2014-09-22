using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.GeoDisaster
{
    public class PhyRelationEntityService<T>:EntityServiceBase<T>
        where T:PhyRelationEntity
    {
        public PhyRelationEntityService(IRepository<T> repository)
            :base(repository)
        {
           
        }
        public IQueryable<T> GetByPhyId(int id)
        {
            return this._repository.Table.Where(t => t.PhyGeoDisasterId == id);
        }

        public IQueryable<T> GetByPhyIds(int[] ids)
        {
            return this._repository.Table.Where(t => ids.Contains(t.PhyGeoDisasterId));
        }
    }
}

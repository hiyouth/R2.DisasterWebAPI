using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using R2.Disaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.GeoDisaster.Investigation
{
    public class DebrisFlowService : EntityServiceBase<DebrisFlow>,IDebrisFlowService
    {
        private IRepository<DebrisFlow> _repositoryDebrisFlow;
        public DebrisFlowService(IRepository<DebrisFlow> repositoryDebrisFlow)
            :base(repositoryDebrisFlow)
        {
            this._repositoryDebrisFlow = repositoryDebrisFlow;
        }


        //public DebrisFlow GetById(int id)
        //{
        //    DebrisFlow debrisFlow=this._repositoryDebrisFlow.GetById(id);
        //    return debrisFlow;
        //}
    }
}

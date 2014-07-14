using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.GeoDisaster.Investigation
{
    public interface IDebrisFlowService : IEntityServiceBase<DebrisFlow>, ICanExecuteExpress<DebrisFlow>
    {
        //DebrisFlow GetById(int id);
    }
}

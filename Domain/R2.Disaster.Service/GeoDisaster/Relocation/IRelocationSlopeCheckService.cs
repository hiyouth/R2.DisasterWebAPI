using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Relocation;

namespace R2.Disaster.Service.GeoDisaster.Relocation
{
    public interface IRelocationSlopeCheckService:IPhyRelationEntityService<RelocationSlopeCheck>
        ,ICanExecuteExpress<RelocationSlopeCheck>
    {
    }
}

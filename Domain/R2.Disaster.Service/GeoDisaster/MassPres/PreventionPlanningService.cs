using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using R2.Disaster.Repository;

namespace R2.Disaster.Service.GeoDisaster.MassPres
{
    public class PreventionPlanningService:EntityServiceBase<PreventionPlanning>
        ,IPreventionPlanningService
    {

        private IRepository<PreventionPlanning> _repositoryPlanning;

        public PreventionPlanningService(IRepository<PreventionPlanning> repositoryPlanning)
            :base(repositoryPlanning)
        {
            this._repositoryPlanning = repositoryPlanning;
        }
    }
}

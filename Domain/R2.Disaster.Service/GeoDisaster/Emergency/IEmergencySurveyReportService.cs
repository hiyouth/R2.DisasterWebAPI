using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Emergency;

namespace R2.Disaster.Service.GeoDisaster.Emergency
{
    public interface IEmergencySurveyReportService:IPhyRelationEntityService<EmergencySurveyReport>
        , ICanExecuteExpress<EmergencySurveyReport>
    {

    }
}

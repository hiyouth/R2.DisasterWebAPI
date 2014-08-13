using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Emergency;
using R2.Disaster.Repository;

namespace R2.Disaster.Service.GeoDisaster.Emergency
{
    public class EmergencySurveyReportService : PhyRelationEntityService<EmergencySurveyReport>, IEmergencySurveyReportService
    {

        private IRepository<EmergencySurveyReport> _repositoryEmergencyReport;

        public EmergencySurveyReportService(IRepository<EmergencySurveyReport> repositoryEmergencyReport)
            : base(repositoryEmergencyReport)
        {
            this._repositoryEmergencyReport = repositoryEmergencyReport;
        }
    }
}

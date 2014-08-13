using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.MineRecovery;
using R2.Disaster.Repository;

namespace R2.Disaster.Service.MineRecovery
{
    public class MineEnvironmentSurveyService:EntityServiceBase<MineEnvironmentSurvey>,IMineEnvironmentSurveyService
    {
        private IRepository<MineEnvironmentSurvey> _repositoryMineEnvironmentSurvey;
        public MineEnvironmentSurveyService(IRepository<MineEnvironmentSurvey> repositoryMineEnvironmentSurvey)
            : base(repositoryMineEnvironmentSurvey)
        {
            this._repositoryMineEnvironmentSurvey = repositoryMineEnvironmentSurvey;
        }
    }
}

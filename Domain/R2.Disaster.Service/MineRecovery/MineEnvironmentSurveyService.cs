using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.MineRecovery;
using R2.Disaster.Repository;
using System.Linq.Expressions;
using R2.Helper.Linq;

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

        public MineEnvironmentSurvey GetByUnifiedId(string uid)
        {
            return this._repositoryMineEnvironmentSurvey.Table.Where(this.GetExpressionByUnifiedId(uid))
               .FirstOrDefault();
        }

        #region 表达式树
        public Expression<Func<MineEnvironmentSurvey, Boolean>> GetExpressionByUnifiedId(string uid)
        {
            var eps = DynamicLinqExpressions.True<MineEnvironmentSurvey>();
            if (!String.IsNullOrEmpty(uid))
            {
                eps = eps.And(m => m.统一编号 == uid);
            }
            return eps;
        }
        #endregion
    }
}

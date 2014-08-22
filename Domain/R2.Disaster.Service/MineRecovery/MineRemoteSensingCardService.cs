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
    public class MineRemoteSensingCardService:EntityServiceBase<MineRemoteSensingCard>,IMineRemoteSensingCardService
    {

        private IRepository<MineRemoteSensingCard> _repositoryMineCard;

        public MineRemoteSensingCardService(IRepository<MineRemoteSensingCard> repositoryMineCard)
            : base(repositoryMineCard)
        {
            this._repositoryMineCard = repositoryMineCard;
        }

        public MineRemoteSensingCard GetByUnifiedId(string uid)
        {
            IQueryable<MineRemoteSensingCard> query = this.ExecuteConditions(this.GetExpressionByUnifiedId(uid));
            return query.FirstOrDefault();
        }

        #region 表达式树
        public Expression<Func<MineRemoteSensingCard, Boolean>> GetExpressionByUnifiedId(string uid)
        {
            var eps = DynamicLinqExpressions.True<MineRemoteSensingCard>();
            if (!String.IsNullOrEmpty(uid))
            {
                eps = eps.And(m => m.编号 == uid);
            }
            return eps;
        }
        #endregion
    }
}

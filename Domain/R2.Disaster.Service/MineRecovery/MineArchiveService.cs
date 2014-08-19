using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.MineRecovery;
using R2.Disaster.Repository;
using R2.Helper.Linq;
using System.Linq.Expressions;

namespace R2.Disaster.Service.MineRecovery
{
    public class MineArchiveService:EntityServiceBase<MineArchive>,IMineArchiveService
    {

        private IRepository<MineArchive> _repositoryMineArchive;

        public MineArchiveService(IRepository<MineArchive> repositoryMineArchive)
            : base(repositoryMineArchive)
        {
            this._repositoryMineArchive = repositoryMineArchive;
        }

        public IQueryable<MineArchive> GetByConditions(string gbCode, string mineSize, string productStatus, string keyWord)
        {
            var eps = DynamicLinqExpressions.True<MineArchive>();
            eps = eps.And(this.GetExpressionByGBCode(gbCode))
                .And(this.GetExpressionByMineSize(mineSize))
                .And(this.GetExpressionByProductStatus(productStatus))
                .And(this.GetExpressionByKeyWord(keyWord));
            IQueryable<MineArchive> query = this.ExecuteConditions(eps);
            return query;
        }

        public MineArchive GetByUnifiedId(string uid)
        {
            return this._repositoryMineArchive.Table.Where(this.GetExpressionByUnifiedId(uid))
                .FirstOrDefault();
        }

        #region 表达式树
        public Expression<Func<MineArchive, Boolean>> GetExpressionByUnifiedId(string uid)
        {
            var eps = DynamicLinqExpressions.True<MineArchive>();
            if (!String.IsNullOrEmpty(uid))
            {
                eps = eps.And(m => m.编号==uid);
            }
            return eps;
        }

        public Expression<Func<MineArchive, Boolean>> GetExpressionByGBCode(string gbCode)
        {
            var eps = DynamicLinqExpressions.True<MineArchive>();
            if (!String.IsNullOrEmpty(gbCode))
            {
                eps = eps.And(m => m.编号.Contains(gbCode));
            }
            return eps;
        }

        public Expression<Func<MineArchive, Boolean>> GetExpressionByMineSize(string mineSize)
        {
            var eps = DynamicLinqExpressions.True<MineArchive>();
            if (!String.IsNullOrEmpty(mineSize))
            {
                eps = eps.And(m => m.矿山规模 == mineSize);
            }
            return eps;
        }

        public Expression<Func<MineArchive, Boolean>> GetExpressionByProductStatus(string productStatus)
        {
            var eps = DynamicLinqExpressions.True<MineArchive>();
            if (!String.IsNullOrEmpty(productStatus))
            {
                eps = eps.And(m => m.生产现状 == productStatus);
            }
            return eps;
        }

        public Expression<Func<MineArchive, Boolean>> GetExpressionByName(string name)
        {
            var eps = DynamicLinqExpressions.True<MineArchive>();
            if (!String.IsNullOrEmpty(name))
            {
                eps = eps.And(m => m.矿山名称 == name);
            }
            return eps;
        }

        public Expression<Func<MineArchive, Boolean>> GetExpressionByKeyWord(string keyWord)
        {
            var eps = DynamicLinqExpressions.False<MineArchive>();
            if (!String.IsNullOrEmpty(keyWord))
            {
                eps = eps.Or(this.GetExpressionByUnifiedId(keyWord))
                    .Or(this.GetExpressionByName(keyWord));
            }
            else
                eps = DynamicLinqExpressions.True<MineArchive>();
            return eps;
        }
        #endregion
    }
}

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

        public IQueryable<MineArchive> GetByConditions(string gbCode, string mineSize, 
            string productStatus, string keyWord,string exploitSolution)
        {
            var eps = DynamicLinqExpressions.True<MineArchive>();
            eps = eps.And(this.GetExpressionByGBCode(gbCode))
                .And(this.GetExpressionByMineSize(mineSize))
                .And(this.GetExpressionByProductStatus(productStatus))
                .And(this.GetExpressionByKeyWord(keyWord))
                .And(this.GetExpressionByExploitSolution(exploitSolution));
            IQueryable<MineArchive> query = this.ExecuteConditions(eps);
            return query;
        }

        public MineArchive GetByUnifiedId(string uid)
        {
            IQueryable<MineArchive> query = this.ExecuteConditions(this.GetExpressionByUnifiedId(uid));
            return query.FirstOrDefault();
        }

        #region 表达式树
        /// <summary>
        ///  统一编号条件
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public Expression<Func<MineArchive, Boolean>> GetExpressionByUnifiedId(string uid)
        {
            var eps = DynamicLinqExpressions.True<MineArchive>();
            if (!String.IsNullOrEmpty(uid))
            {
                eps = eps.And(m => m.编号==uid);
            }
            return eps;
        }

        /// <summary>
        /// 开采方式条件
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        public Expression<Func<MineArchive, Boolean>> GetExpressionByExploitSolution(string solution)
        {
            var eps = DynamicLinqExpressions.True<MineArchive>();
            if (!String.IsNullOrEmpty(solution))
            {
                eps = eps.And(m => m.开采方式 == solution);
            }
            return eps;
        }

        /// <summary>
        /// 所属区域条件
        /// </summary>
        /// <param name="gbCode"></param>
        /// <returns></returns>
        public Expression<Func<MineArchive, Boolean>> GetExpressionByGBCode(string gbCode)
        {
            var eps = DynamicLinqExpressions.True<MineArchive>();
            if (!String.IsNullOrEmpty(gbCode))
            {
                eps = eps.And(m => m.编号.Contains(gbCode));
            }
            return eps;
        }

        /// <summary>
        /// 矿山规模条件
        /// </summary>
        /// <param name="mineSize"></param>
        /// <returns></returns>
        public Expression<Func<MineArchive, Boolean>> GetExpressionByMineSize(string mineSize)
        {
            var eps = DynamicLinqExpressions.True<MineArchive>();
            if (!String.IsNullOrEmpty(mineSize))
            {
                eps = eps.And(m => m.矿山规模 == mineSize);
            }
            return eps;
        }

        /// <summary>
        /// 生产现状条件
        /// </summary>
        /// <param name="productStatus"></param>
        /// <returns></returns>
        public Expression<Func<MineArchive, Boolean>> GetExpressionByProductStatus(string productStatus)
        {
            var eps = DynamicLinqExpressions.True<MineArchive>();
            if (!String.IsNullOrEmpty(productStatus))
            {
                eps = eps.And(m => m.生产现状 == productStatus);
            }
            return eps;
        }

        /// <summary>
        /// 矿山名称条件
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Expression<Func<MineArchive, Boolean>> GetExpressionByName(string name)
        {
            var eps = DynamicLinqExpressions.True<MineArchive>();
            if (!String.IsNullOrEmpty(name))
            {
                eps = eps.And(m => m.矿山名称 == name);
            }
            return eps;
        }

        /// <summary>
        /// 关键字条件（关键字将查询统一编号和矿山名称）
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
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

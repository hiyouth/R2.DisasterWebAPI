using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using R2.Disaster.Repository;
using R2.Helper.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.GeoDisaster.MassPres
{
    public class PrePlanService:DomainServiceBase<PrePlan>,IPrePlanService
    {
        private IRepository<PrePlan> _repoistoryPrePlan;
        public PrePlanService(IRepository<PrePlan> repositoryPrePlan)
            : base(repositoryPrePlan)
        {
            this._repoistoryPrePlan = repositoryPrePlan;
        }

        public PrePlan GetById(int id)
        {
            PrePlan prePlan=this._repoistoryPrePlan.GetById(id);
            return prePlan;
        }


        public PrePlan GetByPhyId(int id)
        {
            var q = from p in this._repoistoryPrePlan.Table
                    where p.Id == id
                    select p;
            return q.FirstOrDefault();
        }

        public IQueryable<PrePlan> GetByUId(string uid)
        {
            var q = from p in this._repoistoryPrePlan.Table
                    where p.统一编号 == uid
                    select p;
            return q;
        }

        public IQueryable<PrePlan> GetByKeyWord(string keyWord)
        {
            var eps = DynamicLinqExpressions.False<PrePlan>();
            eps = eps.Or(this.GetExpressionByUnifiedId(keyWord))
                .Or(this.GetExpressionByName(keyWord))
                .Or(this.GetExpressionByLocation(keyWord));
            IQueryable<PrePlan> preplans = this.ExecuteConditions(eps);
            return preplans;
        }

        #region 表达式树
        /// <summary>
        /// 名称查询表达式树
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Expression<Func<PrePlan, Boolean>> GetExpressionByName(string name)
        {
            var eps = DynamicLinqExpressions.True<PrePlan>();
            if (!String.IsNullOrEmpty(name))
            {
                eps = eps.And(c => c.名称.Contains(name));
            }
            return eps;
        }

        public Expression<Func<PrePlan, Boolean>> GetExpressionByUnifiedId(string uid)
        {
            var eps = DynamicLinqExpressions.True<PrePlan>();
            if (!String.IsNullOrEmpty(uid))
            {
                eps = eps.And(c => c.统一编号.Contains(uid));
            }
            return eps;
        }

        public Expression<Func<PrePlan, Boolean>> GetExpressionByLocation(string keyword)
        {
            var eps = DynamicLinqExpressions.True<PrePlan>();
            if (!String.IsNullOrEmpty(keyword))
            {
                eps = eps.And(c => c.地理位置.Contains(keyword));
            }
            return eps;
        }
        #endregion
    }
}

using Corner.Core;
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
    public class PrePlanFSService:PhyRelationEntityService<PrePlanFS>,IPrePlanFSService,ICanExecuteExpress<PrePlanFS>
    {
        private readonly IRepository<PrePlanFS> _repoistoryPrePlan;
        public PrePlanFSService(IRepository<PrePlanFS> repositoryPrePlan)
            : base(repositoryPrePlan)
        {
            this._repoistoryPrePlan = repositoryPrePlan;
        }

        public PrePlanFS Get(object id)
        {
            PrePlanFS prePlan=this._repoistoryPrePlan.GetById(id);
            return prePlan;
        }


        public PrePlanFS GetByPhyId(String  id)
        {
            var q = from p in this._repoistoryPrePlan.Table
                    where p.Id == id
                    select p;
            return q.FirstOrDefault();
        }

        public IQueryable<PrePlanFS> GetByUId(string uid)
        {
            var q = from p in this._repoistoryPrePlan.Table
                    where p.统一编号 == uid
                    select p;
            return q;
        }

        public IQueryable<PrePlanFS> GetByKeyWord(string keyWord)
        {
            var eps = DynamicLinqExpressions.False<PrePlanFS>();
            eps = eps.Or(this.GetExpressionByUnifiedId(keyWord))
                .Or(this.GetExpressionByName(keyWord));
            IQueryable<PrePlanFS> preplans = this.ExecuteConditions(eps);
            return preplans;
        }

        #region 表达式树
        /// <summary>
        /// 名称查询表达式树
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Expression<Func<PrePlanFS, Boolean>> GetExpressionByName(string name)
        {
            var eps = DynamicLinqExpressions.True<PrePlanFS>();
            if (!String.IsNullOrEmpty(name))
            {
                eps = eps.And(c => c.名称.Contains(name));
            }
            return eps;
        }

        public Expression<Func<PrePlanFS, Boolean>> GetExpressionByUnifiedId(string uid)
        {
            var eps = DynamicLinqExpressions.True<PrePlanFS>();
            if (!String.IsNullOrEmpty(uid))
            {
                eps = eps.And(c => c.统一编号.Contains(uid));
            }
            return eps;
        }

        //public Expression<Func<PrePlanFS, Boolean>> GetExpressionByLocation(string keyword)
        //{
        //    var eps = DynamicLinqExpressions.True<PrePlanFS>();
        //    if (!String.IsNullOrEmpty(keyword))
        //    {
        //        eps = eps.And(c => c.地理位置.Contains(keyword));
        //    }
        //    return eps;
        //}
        #endregion
    }
}

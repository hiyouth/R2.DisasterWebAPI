using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using R2.Disaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    where p.PhyGeoDisaster.Id == id
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
            return null;
        }

        #region 表达式树
        #endregion
    }
}

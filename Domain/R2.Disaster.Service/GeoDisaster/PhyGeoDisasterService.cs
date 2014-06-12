using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using R2.Disaster.Repository;
using R2.Helper.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.GeoDisaster
{
    public class PhyGeoDisasterService:DomainServiceBase<PhyGeoDisaster>,IPhyGeoDisasterService
    {
        private IRepository<PhyGeoDisaster> _repositoryPhy;
        public PhyGeoDisasterService(IRepository<PhyGeoDisaster> repositoryPhy)
            :base(repositoryPhy)
        {
            this._repositoryPhy = repositoryPhy;
        }

        public void New(PhyGeoDisaster phy)
        {
            this._repositoryPhy.Insert(phy);
        }


        public PhyGeoDisaster GetById(int id)
        {
            PhyGeoDisaster phyGeoDisaster = this._repositoryPhy.GetById(id);
            return phyGeoDisaster;
        }

        public IQueryable<PhyGeoDisaster> GetByConditions( string gbcode, EnumGeoDisasterType type)
        {
            var eps = DynamicLinqExpressions.True<PhyGeoDisaster>();
            eps = eps.And(this.GetExpressionByGBCode(gbcode))
                    .And(this.GetExpressionByDisasterType(type));
            IQueryable<PhyGeoDisaster> phys = this.ExecuteConditions(eps);
            return phys;
        }

        public IQueryable<PhyGeoDisaster> GetByKeyWord(string keyWord)
        {
            var eps = DynamicLinqExpressions.False<PhyGeoDisaster>();
            eps = eps
                .Or(this.GetExpressionByName(keyWord))
                .Or(this.GetExpressionByLocation(keyWord));
            IQueryable<PhyGeoDisaster> phys = this.ExecuteConditions(eps);
            return phys;
        }

        #region 表达式树
        public Expression<Func<PhyGeoDisaster, Boolean>> GetExpressionByLocation(string keyword)
        {
            var eps = DynamicLinqExpressions.True<PhyGeoDisaster>();
            if (!String.IsNullOrEmpty(keyword))
            {
                eps = eps.And(p => p.Location.Contains(keyword));
            }
            return eps;
        }

        public Expression<Func<PhyGeoDisaster, Boolean>> GetExpressionByGBCode(string gbcode)
        {
            var eps = DynamicLinqExpressions.True<PhyGeoDisaster>();
            if (!String.IsNullOrEmpty(gbcode))
            {
                eps = eps.And(p => p.GBCodeId.Contains(gbcode));
            }
            return eps;
        }

        public Expression<Func<PhyGeoDisaster, Boolean>> GetExpressionByDisasterType(
            EnumGeoDisasterType? type)
        {
            var eps = DynamicLinqExpressions.True<PhyGeoDisaster>();
            if (type != null)
            {
                eps = eps.And(p => p.DisasterType == type);
            }
            return eps;
        }

        public Expression<Func<PhyGeoDisaster, Boolean>> GetExpressionByName(string name)
        {
            var eps = DynamicLinqExpressions.True<PhyGeoDisaster>();
            if (!String.IsNullOrEmpty(name))
            {
                eps = eps.And(p => p.Name.Contains(name));
            }
            return eps;
        }
        #endregion
    }
}

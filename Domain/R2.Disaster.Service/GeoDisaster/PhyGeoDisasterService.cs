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

        public IQueryable<PhyGeoDisaster> GetByConditions( List<string> gbcodes, 
            List<EnumGeoDisasterType?> type)
        {
            var eps = DynamicLinqExpressions.True<PhyGeoDisaster>();
            eps = eps.And(this.GetExpressionByGBCode(gbcodes))
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
        //    Expression<Func<PhyGeoDisaster,Boolean>> condtion = p=>p.Location.Contains(keyword);
        ////    LinqEntityHelper.GetExpressionForSingle<PhyGeoDisaster, EnumGeoDisasterType>(null, condtion);
        //    return LinqEntityHelper.GetExpressionForSingle<PhyGeoDisaster, String>(keyword, condtion);
        }

        public Expression<Func<PhyGeoDisaster, Boolean>> GetExpressionByGBCode(List<string> gbcodes)
        {
            //如果为null，表示忽略此条件
            var eps = DynamicLinqExpressions.True<PhyGeoDisaster>();
            if (gbcodes != null&&gbcodes.Count!=0)
            {
                //如果不为null，则初始条件为False，多个gbcodes间为“OR”关系，有一个满足则，此条件成立
                eps = DynamicLinqExpressions.False<PhyGeoDisaster>();
                foreach (var regionCode in gbcodes)
                {
                    if (!String.IsNullOrEmpty(regionCode))
                    {
                        eps = eps.Or(p => p.GBCodeId == regionCode);
                    }
                }
            }
            return eps;
        }

        public Expression<Func<PhyGeoDisaster, Boolean>> GetExpressionByDisasterType(
            List<EnumGeoDisasterType?> types)
        {
            var eps = DynamicLinqExpressions.True<PhyGeoDisaster>();
            if (types != null && types.Count != 0)
            {
                //如果不为null，则初始条件为False，多个gbcodes间为“OR”关系，有一个满足则，此条件成立
                eps = DynamicLinqExpressions.False<PhyGeoDisaster>();
                foreach (var type in types)
                {
                   eps = eps.Or(p => p.DisasterType == type);
                }
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


        public IQueryable<PhyGeoDisaster> GetByConditions(string gbCode, EnumGeoDisasterType? type)
        {
            List<String> gbCodes = null;
            if (!String.IsNullOrEmpty(gbCode))
            {
                gbCodes = new List<string>()
                {
                    gbCode
                };
            }
            List<EnumGeoDisasterType?> types = null;
            if (type!=null)
            {
                types = new List<EnumGeoDisasterType?>()
                {
                    type
                };
            }
            IQueryable<PhyGeoDisaster> phys = this.GetByConditions(gbCodes, types);
            return phys;
        }


        public void Update(PhyGeoDisaster phy)
        {
            this._repositoryPhy.Update(phy);
        }
    }
}

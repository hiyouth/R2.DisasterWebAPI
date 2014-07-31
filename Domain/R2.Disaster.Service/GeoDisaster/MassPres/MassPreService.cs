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
    public class MassPreService:EntityServiceBase<MassPre>,IMassPreService
    {
        private IRepository<MassPre> _repositoryMassPre;
        public MassPreService(IRepository<MassPre> repoistoryMassPre)
            :base(repoistoryMassPre)
        {
            this._repositoryMassPre = repoistoryMassPre;
        }

        public IQueryable<MassPre> GetByUid(string uid)
        {
            var q = from m in this._repository.Table
                    where m.统一编号.Contains(uid)
                    select m;
            return q;
        }

        public IQueryable<MassPre> GetByKeyWord(string keyWord)
        {
            var eps = DynamicLinqExpressions.False<MassPre>();
            var epsName = LinqEntityHelper.GetExpressionForSingle<MassPre, String>
                (keyWord, m => m.名称.Contains(keyWord));
            var epsUid = LinqEntityHelper.GetExpressionForSingle<MassPre, String>
            (keyWord, m => m.统一编号.Contains(keyWord));
            eps = eps.Or(epsName).Or(epsUid);
            return this.ExecuteConditions(eps);
        }

        #region 表达式树
        /// <summary>
        /// 名称查询表达式树
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Expression<Func<MassPre, Boolean>> GetExpressionByName(string name)
        {
            var eps = DynamicLinqExpressions.True<MassPre>();
            if (!String.IsNullOrEmpty(name))
            {
                eps = eps.And(c => c.名称.Contains(name));
            }
            return eps;
        }

        public Expression<Func<MassPre, Boolean>> GetExpressionByUnifiedId(string uid)
        {
            var eps = DynamicLinqExpressions.True<MassPre>();
            if (!String.IsNullOrEmpty(uid))
            {
                eps = eps.And(c => c.统一编号.Contains(uid));
            }
            return eps;
        }

        //public Expression<Func<MassPre, Boolean>> GetExpressionByLocation(string keyword)
        //{
        //    var eps = DynamicLinqExpressions.True<MassPre>();
        //    if (!String.IsNullOrEmpty(keyword))
        //    {
        //        eps = eps.And(c => c.地理位置.Contains(keyword));
        //    }
        //    return eps;
        //}
        #endregion
    }
}

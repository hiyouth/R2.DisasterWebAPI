using R2.Disaster.CoreEntities.Domain.GeoHazard.Investigation;
using R2.Disaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using R2.Helper.Linq;

namespace R2.Disaster.Service.GeoHazard.Investigation
{
    /// <summary>
    /// 地质灾害调查表类实体服务
    /// </summary>
    public class GHComprehensiveService:IGHComprehensiveService
    {
        private IRepository<GHComprehensive> _comprehensiveRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="comprehensiveRepository"></param>
        public GHComprehensiveService(IRepository<GHComprehensive> comprehensiveRepository)
        {
            this._comprehensiveRepository = comprehensiveRepository;
        }

        /// <summary>
        /// 通过统一编号精准查询
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public GHComprehensive GetByUnifiedID(string uid)
        {
            var q = from c in this._comprehensiveRepository.Table
                    where c.统一编号 == uid
                    select c;
            return q.FirstOrDefault();
        }

        /// <summary>
        /// 通过统一编号模糊查询
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public IQueryable<GHComprehensive> GetSimilarByUnifiedId(string uid)
        {
            var q = from c in this._comprehensiveRepository.Table
                    where c.统一编号.Contains(uid)
                    select c;
            return q;
        }

        /// <summary>
        /// 通过灾害点名称来查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IQueryable<GHComprehensive> GetByName(string name)
        {
            var q= from c in this._comprehensiveRepository.Table
                   where c.名称.Contains(name)
                   select c;
            return q;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="ghc"></param>
        public void New(GHComprehensive ghc)
        {
            this._comprehensiveRepository.Insert(ghc);
        }

        #region 表达式树
        /// <summary>
        /// 统一编号查询表达式树
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public Expression<Func<GHComprehensive, Boolean>> GetByUnifiedIdExpression(string uid)
        {
            var eps = DynamicLinqExpressions.True<GHComprehensive>();
            if(!String.IsNullOrEmpty(uid))
            {
                eps = eps.And(c => c.统一编号.Contains(uid));
            }
            return eps;
        }

        /// <summary>
        /// 名称查询表达式树
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Expression<Func<GHComprehensive, Boolean>> GetByNameExpression(string name)
        {
            var eps = DynamicLinqExpressions.True<GHComprehensive>();
            if (!String.IsNullOrEmpty(name))
            {
                eps = eps.And(c => c.名称.Contains(name));
            }
            return eps;
        }
        #endregion

    }
}

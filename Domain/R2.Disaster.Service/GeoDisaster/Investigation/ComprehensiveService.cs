using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using R2.Disaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using R2.Helper.Linq;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Helper.GIS;

namespace R2.Disaster.Service.GeoDisaster.Investigation
{
    /// <summary>
    /// 地质灾害调查表类实体服务
    /// </summary>
    public class ComprehensiveService:DomainServiceBase<Comprehensive>,IComprehensiveService
    {
        private IRepository<Comprehensive> _comprehensiveRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="comprehensiveRepository"></param>
        public ComprehensiveService(IRepository<Comprehensive> comprehensiveRepository)
            :base(comprehensiveRepository)
        {
            this._comprehensiveRepository = comprehensiveRepository;
        }

        /// <summary>
        /// 通过统一编号精准查询
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public Comprehensive GetByUnifiedID(string uid)
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
        public IQueryable<Comprehensive> GetSimilarByUnifiedId(string uid)
        {
            var q = from c in this._comprehensiveRepository.Table
                    where c.统一编号.Contains(uid)
                    select c;
            return q;
        }

        /// <summary>
        /// 通过灾害点名称查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IQueryable<Comprehensive> GetByName(string name)
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
        public void New(Comprehensive ghc)
        {
            this._comprehensiveRepository.Insert(ghc);
        }

        #region 表达式树
        /// <summary>
        /// 统一编号查询表达式树
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public Expression<Func<Comprehensive, Boolean>> GetExpressionByUnifiedId(string uid)
        {
            var eps = DynamicLinqExpressions.True<Comprehensive>();
            if(!String.IsNullOrEmpty(uid))
            {
                eps = eps.And(c => c.统一编号.Contains(uid));
            }
            return eps;
        }

        public Expression<Func<Comprehensive, Boolean>> GetExpressionByLocation(string keyword)
        {
            var eps = DynamicLinqExpressions.True<Comprehensive>();
            if (!String.IsNullOrEmpty(keyword))
            {
                eps = eps.And(c => c.地理位置.Contains(keyword));
            }
            return eps;
        }

        public Expression<Func<Comprehensive, Boolean>> GetExpressionByGBCode(string gbcode)
        {
            var eps = DynamicLinqExpressions.True<Comprehensive>();
            if (!String.IsNullOrEmpty(gbcode))
            {
                eps = eps.And(c => c.GBCodeId.Contains(gbcode));
            }
            return eps;
        }

        public Expression<Func<Comprehensive, Boolean>> GetExpressionByDangerousLev(string dangerLev)
        {
            var eps = DynamicLinqExpressions.True<Comprehensive>();
            if (!String.IsNullOrEmpty(dangerLev))
            {
                eps = eps.And(c => c.险情等级.Contains(dangerLev));
            }
            return eps;
        }

        public Expression<Func<Comprehensive, Boolean>> GetExpressionBySituationLev(string situationLev)
        {
            var eps = DynamicLinqExpressions.True<Comprehensive>();
            if (!String.IsNullOrEmpty(situationLev))
            {
                eps = eps.And(c => c.灾情等级.Contains(situationLev));
            }
            return eps;
        }

        public Expression<Func<Comprehensive, Boolean>> GetExpressionByDisasterType(
            EnumGeoDisasterType? type)
        {
            var eps = DynamicLinqExpressions.True<Comprehensive>();
            if (type!=null)
            {
                eps = eps.And(c => c.灾害类型 == type);
            }
            return eps;
        }

        /// <summary>
        /// 名称查询表达式树
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Expression<Func<Comprehensive, Boolean>> GetExpressionByName(string name)
        {
            var eps = DynamicLinqExpressions.True<Comprehensive>();
            if (!String.IsNullOrEmpty(name))
            {
                eps = eps.And(c => c.名称.Contains(name));
            }
            return eps;
        }

        public Expression<Func<Comprehensive, Boolean>> GetExpressionByRect(
            double x1, double x2, double y1, double y2)
        {
            var eps = DynamicLinqExpressions.True<Comprehensive>();
            eps = eps.And(a =>
                                      LonLatHelper.ConvertToDegreeStyleFromString(a.经度) > y1 &&
                                      LonLatHelper.ConvertToDegreeStyleFromString(a.经度) < y2 &&
                                      LonLatHelper.ConvertToDegreeStyleFromString(a.纬度) > x1 &&
                                      LonLatHelper.ConvertToDegreeStyleFromString(a.纬度) < x2);
            return eps;
        }

        public Expression<Func<Comprehensive, Boolean>> GetExpressionByCircle(double x, double y, double radius)
        {
            var eps = DynamicLinqExpressions.True<Comprehensive>();
            eps = eps.And(a =>
                                        LonLatHelper.DistanceBetTwoPoints(
                                                x, y,
                                                LonLatHelper.ConvertToDegreeStyleFromString(a.经度),
                                                LonLatHelper.ConvertToDegreeStyleFromString(a.纬度)
                                                )
                                        <= radius);
            return eps;
        }
        #endregion



        public Comprehensive GetById(int id)
        {
            var q = from c in this._comprehensiveRepository.Table
                    where c.Id == id
                    select c;
            return q.FirstOrDefault();
        }

        public IQueryable<Comprehensive> GetByRect(
              double x1, double x2, double y1, double y2)
        {
            var eps = this.GetExpressionByRect(x1, x2, y1, y2);
            IQueryable<Comprehensive> comprehensives = this.ExecuteConditions(eps);
            return comprehensives;
        }

        public IQueryable<Comprehensive> GetByCircle(double x, double y, double radius)
        {
            var eps = this.GetExpressionByCircle(x,y,radius);
            IQueryable<Comprehensive> comprehensives = this.ExecuteConditions(eps);
            return comprehensives;
        }

        public IQueryable<Comprehensive> GetByKeyWord(string keyWord)
        {
            var eps = DynamicLinqExpressions.False<Comprehensive>();
            eps = eps.Or(this.GetExpressionByUnifiedId(keyWord))
                .Or(this.GetExpressionByName(keyWord))
                .Or(this.GetExpressionByLocation(keyWord));
            IQueryable<Comprehensive> comprehensives = this.ExecuteConditions(eps);
            return comprehensives;
        }

        
        public IQueryable<Comprehensive> GetByContions(string gbCode, 
            string situationLev, string dangerousLev, EnumGeoDisasterType? type)
        {
            var eps = DynamicLinqExpressions.True<Comprehensive>();
            eps = eps.And(this.GetExpressionByGBCode(gbCode))
                .And(this.GetExpressionBySituationLev(situationLev))
                .And(this.GetExpressionByDisasterType(type))
                .And(this.GetExpressionByDangerousLev(dangerousLev));
            IQueryable<Comprehensive> comprehensives = this.ExecuteConditions(eps);
            return comprehensives;
        }
    }
}

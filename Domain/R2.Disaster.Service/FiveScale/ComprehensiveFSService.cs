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
using Corner.Core;

namespace R2.Disaster.Service.GeoDisaster.Investigation
{
    /// <summary>
    /// 地质灾害调查表类实体服务
    /// </summary>
    public class ComprehensiveFSService : PhyRelationEntityService<ComprehensiveFS>, IComprehensiveFSService
    {
        private IRepository<ComprehensiveFS> _comprehensiveFSRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="comprehensiveRepository"></param>
        public ComprehensiveFSService(IRepository<ComprehensiveFS> comprehensiveFSRepository)
            : base(comprehensiveFSRepository)
        {
            this._comprehensiveFSRepository = comprehensiveFSRepository;
        }

        /// <summary>
        /// 通过统一编号精准查询
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public ComprehensiveFS GetByUnifiedID(string uid)
        {
            var q = from c in this._comprehensiveFSRepository.Table
                    where c.统一编号 == uid
                    select c;
            return q.FirstOrDefault();
        }

        /// <summary>
        /// 通过统一编号模糊查询
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public IQueryable<ComprehensiveFS> GetByUnifiedId(string uid)
        {
            var q = from c in this._comprehensiveFSRepository.Table
                    where c.统一编号.Contains(uid)
                    select c;
            return q;
        }

        /// <summary>
        /// 通过灾害点名称查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IQueryable<ComprehensiveFS> GetByName(string name)
        {
            var q = from c in this._comprehensiveFSRepository.Table
                    where c.名称.Contains(name)
                    select c;
            return q;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="ghc"></param>
        public void New(ComprehensiveFS ghc)
        {
            this._comprehensiveFSRepository.Insert(ghc);
        }

        #region 表达式树
        /// <summary>
        /// 统一编号查询表达式树
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public Expression<Func<ComprehensiveFS, Boolean>> GetExpressionByUnifiedId(string uid)
        {
            var eps = DynamicLinqExpressions.True<ComprehensiveFS>();
            if (!String.IsNullOrEmpty(uid))
            {
                eps = eps.And(c => c.统一编号.Contains(uid));
            }
            return eps;
        }

        public Expression<Func<ComprehensiveFS, Boolean>> GetExpressionByLocation(string keyword)
        {
            var eps = DynamicLinqExpressions.True<ComprehensiveFS>();
            if (!String.IsNullOrEmpty(keyword))
            {
                eps = eps.And(c => c.地理位置.Contains(keyword));
            }
            return eps;
        }

        public Expression<Func<ComprehensiveFS, Boolean>> GetExpressionByGBCode(List<string> gbcodes)
        {
            //如果为null，表示忽略此条件
            var eps = DynamicLinqExpressions.True<ComprehensiveFS>();
            if (gbcodes != null && gbcodes.Count != 0)
            {
                //如果不为null，则初始条件为False，多个gbcodes间为“OR”关系，有一个满足则，此条件成立
                eps = DynamicLinqExpressions.False<ComprehensiveFS>();
                foreach (var regionCode in gbcodes)
                {
                    if (!String.IsNullOrEmpty(regionCode))
                    {
                        string tempGbCode = regionCode;
                        eps = eps.Or(p => p.GBCodeId.StartsWith(tempGbCode));
                    }
                }
            }
            return eps;
        }

        public Expression<Func<ComprehensiveFS, Boolean>> GetExpressionByDangerousLev(
            List<String> dangerLevs)
        {
            var eps = DynamicLinqExpressions.True<ComprehensiveFS>();
            if (dangerLevs != null && dangerLevs.Count != 0)
            {
                //如果不为null，则初始条件为False，多个dangerLevs间为“OR”关系，有一个满足则，此条件成立
                eps = DynamicLinqExpressions.False<ComprehensiveFS>();
                foreach (var lev in dangerLevs)
                {
                    eps = eps.Or(p => p.险情等级 == lev);
                }
            }
            return eps;
        }

        public Expression<Func<ComprehensiveFS, Boolean>> GetExpressionBySituationLev(List<string>
            situationLevs)
        {
            var eps = DynamicLinqExpressions.True<ComprehensiveFS>();
            if (situationLevs != null && situationLevs.Count != 0)
            {
                //如果不为null，则初始条件为False，多个situationLevs间为“OR”关系，有一个满足则，此条件成立
                eps = DynamicLinqExpressions.False<ComprehensiveFS>();
                foreach (var lev in situationLevs)
                {
                    eps = eps.Or(p => p.灾情等级 == lev);
                }
            }
            return eps;
        }

        public Expression<Func<ComprehensiveFS, Boolean>> GetExpressionByDisasterType(
            List<EnumGeoDisasterType?> types)
        {
            var eps = DynamicLinqExpressions.True<ComprehensiveFS>();
            if (types != null && types.Count != 0)
            {
                //如果不为null，则初始条件为False，多个Types间为“OR”关系，有一个满足则，此条件成立
                eps = DynamicLinqExpressions.False<ComprehensiveFS>();
                foreach (var type in types)
                {
                    if (type != null)
                    {
                        eps = eps.Or(p => p.灾害类型 == type);
                    }
                }
            }
            return eps;
        }

        /// <summary>
        /// 名称查询表达式树
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Expression<Func<ComprehensiveFS, Boolean>> GetExpressionByName(string name)
        {
            var eps = DynamicLinqExpressions.True<ComprehensiveFS>();
            if (!String.IsNullOrEmpty(name))
            {
                eps = eps.And(c => c.名称.Contains(name));
            }
            return eps;
        }

        public Expression<Func<ComprehensiveFS, Boolean>> GetExpressionByRect(
            double x1, double x2, double y1, double y2)
        {
            //var eps = DynamicLinqExpressions.True<Comprehensive>();
            //eps = eps.And(a =>
            //                          LonLatHelper.ConvertToDegreeStyleFromString(a.经度) > y1 &&
            //                          LonLatHelper.ConvertToDegreeStyleFromString(a.经度) < y2 &&
            //                          LonLatHelper.ConvertToDegreeStyleFromString(a.纬度) > x1 &&
            //                          LonLatHelper.ConvertToDegreeStyleFromString(a.纬度) < x2);
            //return eps;
            var eps = DynamicLinqExpressions.True<ComprehensiveFS>();
            eps = eps.And(
                 c => LonLatHelper.GetLonLatIsInRect(
                     x1, x2, y1, y2
                   , c.经度
                   , c.纬度
                   )
            );
            return eps;
        }

        public Expression<Func<ComprehensiveFS, Boolean>> GetExpressionByCircle(double x, double y, double radius)
        {
            var eps = DynamicLinqExpressions.True<ComprehensiveFS>();
            eps = eps.And(a =>
                                        LonLatHelper.DistanceBetTwoPoints(
                                                x, y,
                                                 a.经度,
                                                a.纬度
                                                )
                                        <= radius);
            return eps;
        }
        #endregion



        //public Comprehensive Get(object id)
        //{
        //    var q = from c in this._comprehensiveRepository.Table
        //            where c.Id == Int32.Parse(id.ToString())
        //            select c;
        //    return q.FirstOrDefault();
        //}

        public IQueryable<ComprehensiveFS> GetByRect(
              double x1, double x2, double y1, double y2)
        {
            var eps = this.GetExpressionByRect(x1, x2, y1, y2);
            IQueryable<ComprehensiveFS> comprehensives = this.ExecuteConditions(eps);
            return comprehensives;
        }

        public IQueryable<ComprehensiveFS> GetByCircle(double x, double y, double radius)
        {
            var eps = this.GetExpressionByCircle(x, y, radius);
            IQueryable<ComprehensiveFS> comprehensives = this.ExecuteConditions(eps);
            return comprehensives;
        }

        public IQueryable<ComprehensiveFS> GetByKeyWord(string keyWord)
        {
            var eps = DynamicLinqExpressions.False<ComprehensiveFS>();
            eps = eps.Or(this.GetExpressionByUnifiedId(keyWord))
                .Or(this.GetExpressionByName(keyWord))
                .Or(this.GetExpressionByLocation(keyWord));
            IQueryable<ComprehensiveFS> comprehensives = this.ExecuteConditions(eps);
            return comprehensives;
        }


        public IQueryable<ComprehensiveFS> GetByConditions(List<string> gbCodes,
            List<string> situationLevs, List<string> dangerousLevs, List<EnumGeoDisasterType?> types)
        {
            var eps = DynamicLinqExpressions.True<ComprehensiveFS>();
            eps = eps.And(this.GetExpressionByGBCode(gbCodes))
                .And(this.GetExpressionBySituationLev(situationLevs))
                .And(this.GetExpressionByDisasterType(types))
                .And(this.GetExpressionByDangerousLev(dangerousLevs));
            IQueryable<ComprehensiveFS> comprehensives = this.ExecuteConditions(eps);
            return comprehensives;
        }


        public IQueryable<ComprehensiveFS> GetByConditions(string gbCode,
            string situationLev, string dangerous, EnumGeoDisasterType? type)
        {
            List<String> gbCodes = null;
            if (!String.IsNullOrEmpty(gbCode))
            {
                gbCodes = new List<string>()
                {
                    gbCode
                };
            }

            List<String> situationLevs = null;
            if (!String.IsNullOrEmpty(situationLev))
            {
                situationLevs = new List<string>()
                {
                    situationLev
                };
            }

            List<String> dangerousLevs = null;
            if (!String.IsNullOrEmpty(dangerous))
            {
                dangerousLevs = new List<string>()
                {
                    dangerous
                };
            }

            List<EnumGeoDisasterType?> types = null;
            if (type != null)
            {
                types = new List<EnumGeoDisasterType?>();
                types.Add(type);
            }

            return this.GetByConditions(gbCodes, situationLevs, dangerousLevs, types);
        }


        public ComprehensiveFS GetByPhyId(int id)
        {
            //Comprehensive地质调查表被配置为同主表PhyGeodisaster一对一关系，
            //且Comprehensive实体的主键也是其外键，即Comprehensive的主键/外键是一个键
            //且其等于PhyGeoDisaster表的主键
            return this.Get(id);
        }
    }
}

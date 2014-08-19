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
    public class ComprehensiveService :PhyRelationEntityService<Comprehensive>, IComprehensiveService
    {
        private IRepository<Comprehensive> _comprehensiveRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="comprehensiveRepository"></param>
        public ComprehensiveService(IRepository<Comprehensive> comprehensiveRepository)
            : base(comprehensiveRepository)
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
        public IQueryable<Comprehensive> GetByUnifiedId(string uid)
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
            var q = from c in this._comprehensiveRepository.Table
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
            if (!String.IsNullOrEmpty(uid))
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

        public Expression<Func<Comprehensive, Boolean>> GetExpressionByGBCode(List<string> gbcodes)
        {
            //如果为null，表示忽略此条件
            var eps = DynamicLinqExpressions.True<Comprehensive>();
            if (gbcodes != null && gbcodes.Count != 0)
            {
                //如果不为null，则初始条件为False，多个gbcodes间为“OR”关系，有一个满足则，此条件成立
                eps = DynamicLinqExpressions.False<Comprehensive>();
                foreach (var regionCode in gbcodes)
                {
                    if (!String.IsNullOrEmpty(regionCode))
                    {
                        string tempGbCode = regionCode;
                        eps = eps.Or(p => p.GBCodeId == tempGbCode);
                    }
                }
            }
            return eps;
        }

        public Expression<Func<Comprehensive, Boolean>> GetExpressionByDangerousLev(
            List<String> dangerLevs)
        {
            var eps = DynamicLinqExpressions.True<Comprehensive>();
            if (dangerLevs != null && dangerLevs.Count != 0)
            {
                //如果不为null，则初始条件为False，多个dangerLevs间为“OR”关系，有一个满足则，此条件成立
                eps = DynamicLinqExpressions.False<Comprehensive>();
                foreach (var lev in dangerLevs)
                {
                    eps = eps.Or(p => p.险情等级 == lev);
                }
            }
            return eps;
        }

        public Expression<Func<Comprehensive, Boolean>> GetExpressionBySituationLev(List<string>
            situationLevs)
        {
            var eps = DynamicLinqExpressions.True<Comprehensive>();
            if (situationLevs != null && situationLevs.Count != 0)
            {
                //如果不为null，则初始条件为False，多个situationLevs间为“OR”关系，有一个满足则，此条件成立
                eps = DynamicLinqExpressions.False<Comprehensive>();
                foreach (var lev in situationLevs)
                {
                    eps = eps.Or(p => p.灾情等级 == lev);
                }
            }
            return eps;
        }

        public Expression<Func<Comprehensive, Boolean>> GetExpressionByDisasterType(
            List<EnumGeoDisasterType?> types)
        {
            var eps = DynamicLinqExpressions.True<Comprehensive>();
            if (types != null && types.Count != 0)
            {
                //如果不为null，则初始条件为False，多个Types间为“OR”关系，有一个满足则，此条件成立
                eps = DynamicLinqExpressions.False<Comprehensive>();
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
            //var eps = DynamicLinqExpressions.True<Comprehensive>();
            //eps = eps.And(a =>
            //                          LonLatHelper.ConvertToDegreeStyleFromString(a.经度) > y1 &&
            //                          LonLatHelper.ConvertToDegreeStyleFromString(a.经度) < y2 &&
            //                          LonLatHelper.ConvertToDegreeStyleFromString(a.纬度) > x1 &&
            //                          LonLatHelper.ConvertToDegreeStyleFromString(a.纬度) < x2);
            //return eps;
            var eps = DynamicLinqExpressions.True<Comprehensive>();
            eps = eps.And(
                 c => LonLatHelper.GetLonLatIsInRect(
                     x1, x2, y1, y2
                   , c.经度
                   , c.纬度
                   )
            );
            return eps;
        }

        public Expression<Func<Comprehensive, Boolean>> GetExpressionByCircle(double x, double y, double radius)
        {
            var eps = DynamicLinqExpressions.True<Comprehensive>();
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

        public IQueryable<Comprehensive> GetByRect(
              double x1, double x2, double y1, double y2)
        {
            var eps = this.GetExpressionByRect(x1, x2, y1, y2);
            IQueryable<Comprehensive> comprehensives = this.ExecuteConditions(eps);
            return comprehensives;
        }

        public IQueryable<Comprehensive> GetByCircle(double x, double y, double radius)
        {
            var eps = this.GetExpressionByCircle(x, y, radius);
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


        public IQueryable<Comprehensive> GetByConditions(List<string> gbCodes,
            List<string> situationLevs, List<string> dangerousLevs, List<EnumGeoDisasterType?> types)
        {
            var eps = DynamicLinqExpressions.True<Comprehensive>();
            eps = eps.And(this.GetExpressionByGBCode(gbCodes))
                .And(this.GetExpressionBySituationLev(situationLevs))
                .And(this.GetExpressionByDisasterType(types))
                .And(this.GetExpressionByDangerousLev(dangerousLevs));
            IQueryable<Comprehensive> comprehensives = this.ExecuteConditions(eps);
            return comprehensives;
        }


        public IQueryable<Comprehensive> GetByConditions(string gbCode,
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


        public Comprehensive GetByPhyId(int id)
        {
            //Comprehensive地质调查表被配置为同主表PhyGeodisaster一对一关系，
            //且Comprehensive实体的主键也是其外键，即Comprehensive的主键/外键是一个键
            //且其等于PhyGeoDisaster表的主键
            return this.Get(id);
        }
    }
}

using AutoMapper;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Monitor;
using R2.Disaster.Repository.Monitor;
using R2.Domain.Model.Monitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace R2.Disaster.Service.Monitor
{
    public class RainfallService:EntityServiceBase<Rainfall>,IRainfallService
    {
        public RainfallService(RainfallRepoistory rainfallRepoisotry)
            :base(rainfallRepoisotry)
        {

        }
        public IQueryable<SumRainfall> GetSumByStationIds(
            DateTime stime, DateTime etime, List<string> stationIds = null)
        {
           // if(stationIds
            Expression<Func<Rainfall,Boolean>> selector = r=>stationIds.Contains(r.RainfallStation.StationId)
                && (r.CollectTime<=etime&&r.CollectTime>=stime);
            IQueryable<Rainfall> rainfalls = this.ExecuteConditions(selector);
            return RainfallService.GetGroupFromSources<Rainfall, SumRainfall>(rainfalls, r => r.RainfallStation.Id);
        }

        public IQueryable<SumRainfall> GetSumByStationIds(Expression<Func<Rainfall,Boolean>> condition)
        {
            // if(stationIds
            IQueryable<Rainfall> rainfalls = this.ExecuteConditions(condition);
            return RainfallService.GetGroupFromSources<Rainfall, SumRainfall>(rainfalls, r => r.RainfallStation.Id);
        }

        /// <summary>
        /// 按关键字分组并计算每个分组的雨量和，把数据库查询部分的代码分离出来有助于编写单元测试
        /// 执行次函数前，需要配置源类型到目标类型的AutoMapper映射关系
        /// </summary>
        /// <typeparam name="T">数据源类型</typeparam>
        /// <typeparam name="U">分组后的新类型（目标类型）</typeparam>
        /// <param name="rainfalls">被分组的原始数据源</param>
        /// <param name="grouper">分组关键字</param>
        /// <returns></returns>
        public static IQueryable<U> GetGroupFromSources<T,U>(IQueryable<T> sources
            ,Func<T,object> grouper)
        {
           // Mapper.CreateMap<IQueryable<Rainfall>, SumRainfall>()
           //.ForMember(s => s.SumValue, opt => opt.MapFrom(a => a.Sum(r => r.Value)))
           //.ForMember(s => s.StartTime, opt => opt.UseValue(stime))
           //.ForMember(s => s.EndTime, opt => opt.UseValue(etime));
            var q = from r in sources
                    group r by grouper.Invoke(r) into g
                    select Mapper.Map<U>(g.AsQueryable());
            return q;
        }

        public IQueryable<Rainfall> GetByCondition(Expression<Func<Rainfall, bool>> condition)
        {
            return this.ExecuteConditions(condition);
        }

        public IQueryable<RainfallGroupedByStation> GetStaionIdGroupByCondition(
            Expression<Func<Rainfall, bool>> condition)
        {
            IQueryable<Rainfall> rainfalls = this.ExecuteConditions(condition);
         
            return RainfallService.GetGroupFromSources<Rainfall, RainfallGroupedByStation>(
                rainfalls, r => r.RainfallStation.Id);
        }
    }
}

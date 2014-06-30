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
        public IQueryable<SumRainfall> GetSumByStationIds(DateTime stime, DateTime etime, List<string> stationIds = null)
        {
           // if(stationIds
            Expression<Func<Rainfall,Boolean>> selector = r=>stationIds.Contains(r.RallfallStationId)
                && (r.CollectTime<=etime&&r.CollectTime>=stime);
            IQueryable<Rainfall> rainfalls = this.ExecuteConditions(selector);
            return RainfallService.GetSumFromRainfalls(stime, etime, rainfalls);
        }

        /// <summary>
        /// 按StationId分组并计算每个分组的雨量和，把数据库查询部分的代码分离出来有助于编写单元测试
        /// </summary>
        /// <param name="stime"></param>
        /// <param name="etime"></param>
        /// <param name="rainfalls"></param>
        /// <returns></returns>
        public static IQueryable<SumRainfall> GetSumFromRainfalls(DateTime stime,DateTime etime,
            IQueryable<Rainfall> rainfalls)
        {
            Mapper.CreateMap<IQueryable<Rainfall>, SumRainfall>()
           .ForMember(s => s.SumValue, opt => opt.MapFrom(a => a.Sum(r => r.Value)))
           .ForMember(s => s.StartTime, opt => opt.UseValue(stime))
           .ForMember(s => s.EndTime, opt => opt.UseValue(etime));
            var q = from r in rainfalls
                    group r by r.RainfallStation.Id into g
                    select Mapper.Map<SumRainfall>(g.AsQueryable());
            return q;
        }

        public IQueryable<Rainfall> GetByStationIds(DateTime stime, List<string> stationIds = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RainfallGroupedByStation> GetByStationIds(DateTime stime, DateTime etime, List<string> stationIds = null)
        {
            throw new NotImplementedException();
        }
    }
}

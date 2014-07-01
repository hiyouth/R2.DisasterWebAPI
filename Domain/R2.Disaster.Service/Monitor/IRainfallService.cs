using R2.Disaster.CoreEntities.Domain.GeoDisaster.Monitor;
using R2.Domain.Model.Monitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.Monitor
{
    public interface IRainfallService : IEntityServiceBase<Rainfall>
    {
        //IQueryable<SumRainfall> GetByTimePeriod(DateTime stime,DateTime etime);
        /// <summary>
        /// 查询指定站点编号的一段时间内的累积雨量，stationIds=null时表示不指定站点编号而查询所有
        /// </summary>
        /// <param name="stime"></param>
        /// <param name="etime"></param>
        /// <param name="stationIds"></param>
        /// <returns></returns>
        IQueryable<SumRainfall> GetSumByStationIds(DateTime stime, DateTime etime, List<string> stationIds=null);

        IQueryable<SumRainfall> GetSumByStationIds(Expression<Func<Rainfall, Boolean>> condition);

        /// <summary>
        /// 根据指定的筛选条件，查询某时间点的雨量值
        /// </summary>
        /// <param name="stime"></param>
        /// <param name="stationIds"></param>
        /// <returns></returns>
        IQueryable<Rainfall> GetByCondition(Expression<Func<Rainfall, Boolean>> condition);

        /// <summary>
        /// 根据指定的筛选条件，查询某段时间内的雨量值（按StationId分组）
        /// </summary>
        /// <param name="stime"></param>
        /// <param name="etime"></param>
        /// <param name="stationIds"></param>
        /// <returns></returns>
        IQueryable<RainfallGroupedByStation> GetStaionIdGroupByCondition(
            Expression<Func<Rainfall, Boolean>> condition);
    }
}

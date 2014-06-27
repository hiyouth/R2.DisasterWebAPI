using R2.Disaster.CoreEntities.Domain.GeoDisaster.Monitor;
using R2.Disaster.Service.Monitor;
using R2.Domain.Model.Monitor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace R2.Disaster.WebAPI.Controllers.Monitor
{
    /// <summary>
    /// 雨量站点服务
    /// </summary>
    public class RainfallController : EntityControllerBase<Rainfall,long>
    {
        private IRainfallService _rainfallStationService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rainfallStationService"></param>
        public RainfallController(IRainfallService rainfallService)
            : base(rainfallService)
        {
            this._rainfallStationService = rainfallService;
        }


        /// <summary>
        /// 根据站点编号查询一段时间累积雨量
        /// </summary>
        /// <param name="stime">起始时间</param>
        /// <param name="etime">终止时间</param>
        /// <param name="stationIds">一组站点Id，“，”分隔</param>
        /// <returns></returns>
        IList<SumRainfall> GetSumByStationIds(DateTime stime,DateTime etime,string stationIds=null)
        {
            if (stime==null || etime==null)
                throw new Exception("输入的时间段值有误");
            List<String> stationIdList=null;
            if(stationIds!=null)
            {
                string[] ids = stationIds.Split(',');
                stationIdList = ids.ToList();
            }
            IQueryable<SumRainfall> rains =
                this._rainfallStationService.GetSumByStationIds(stime, etime, stationIdList);
            return rains.ToList();
        }

        /// <summary>
        /// 根据站点编号，查询一个时间点上的
        /// </summary>
        /// <param name="timing"></param>
        /// <param name="stationIds"></param>
        /// <returns></returns>
        IList<Rainfall> GetByStationIdsWithTiming(DateTime timing, string stationIds = null)
        {
            if (timing == null)
                throw new Exception("不存在这样的时间点参数");
            List<String> stationIdList = null;
            if (stationIds != null)
            {
                string[] ids = stationIds.Split(',');
            }
            IQueryable<Rainfall> rains =
                this._rainfallStationService.GetByStationIds(timing, stationIdList);
            return rains.ToList();
        }

        /// <summary>
        /// 根据雨量站点，查询一段时间内每个时间点的雨量值，并且按照雨量站点分类返回
        /// </summary>
        /// <param name="stime"></param>
        /// <param name="etime"></param>
        /// <param name="stationIds"></param>
        /// <returns></returns>
        IList<RainfallGroupedByStation> GetByStationIdsWithTimeline(
            DateTime stime, DateTime etime, string stationIds = null)
        {
            if (stime == null || etime == null)
                throw new Exception("输入的时间段值有误");
            List<String> stationIdList = null;
            if (stationIds != null)
            {
                string[] ids = stationIds.Split(',');
                stationIdList = ids.ToList();
            }
            IQueryable<RainfallGroupedByStation> rains =
                this._rainfallStationService.GetByStationIds(stime, etime, stationIdList);
            return rains.ToList();
        }
    }
}

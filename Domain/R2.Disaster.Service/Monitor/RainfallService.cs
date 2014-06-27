using R2.Disaster.CoreEntities.Domain.GeoDisaster.Monitor;
using R2.Disaster.Repository.Monitor;
using R2.Domain.Model.Monitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
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

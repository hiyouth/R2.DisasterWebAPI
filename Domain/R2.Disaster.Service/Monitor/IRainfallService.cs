using R2.Disaster.CoreEntities.Domain.GeoDisaster.Monitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.Monitor
{
    public interface IRainfallService : IEntityServiceBase<Rainfall>
    {
        IQueryable<Rainfall> GetByTimePeriod(DateTime stime,DateTime etime);
        IQueryable<Rainfall> GetByStationId(DateTime stime, DateTime etime, string stationId);
       // IQueryable
    }
}

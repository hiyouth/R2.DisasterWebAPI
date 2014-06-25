using R2.Disaster.CoreEntities.Domain.GeoDisaster.Monitor;
using R2.Disaster.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.Monitor
{
    public interface IRainfallStationService:IEntityServiceBase<RainfallStation>
    {
         IQueryable<RainfallStation> GetByName(string name);
         IQueryable<RainfallStation> GetByGBCode(String gbcodeId);
         IQueryable<RainfallStation> GetByRect(double x1, double x2, double y1, double y2);
         IQueryable<RainfallStation> GetByCircle(double x, double y, double radius);
    }
}

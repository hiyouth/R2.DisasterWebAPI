using R2.Disaster.CoreEntities.Domain.GeoDisaster.Monitor;
using R2.Disaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.Monitor
{
    public class RainfallStationService:EntityServiceBase<RainfallStation>,IRainfallStationService
    {
        public RainfallStationService(IRepository<RainfallStation> repositoryRainfallStation)
            :base(repositoryRainfallStation)
        {

        }
        public IQueryable<RainfallStation> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RainfallStation> GetByGBCode(string gbcodeId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RainfallStation> GetByRect(double x1, double x2, double y1, double y2)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RainfallStation> GetByCircle(double x, double y, double radious)
        {
            throw new NotImplementedException();
        }
    }
}

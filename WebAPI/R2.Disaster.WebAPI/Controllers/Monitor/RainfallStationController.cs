using R2.Disaster.CoreEntities.Domain.GeoDisaster.Monitor;
using R2.Disaster.Service.Monitor;
using System;
using System.Collections.Generic;

namespace R2.Disaster.WebAPI.Controllers.Monitor
{
    public class RainfallStationController : EntityControllerBase<RainfallStation,String>
    {
        private IRainfallStationService _rainfallStationService;
        public RainfallStationController(IRainfallStationService rainfallStationService)
            :base(rainfallStationService)
        {
            this._rainfallStationService = rainfallStationService;
        }

        IList<RainfallStation> GetByName(string name)
        {
            return null;
        }

        IList<RainfallStation> GetByGBCode(string code)
        {
            return null;
        }

        IList<RainfallStation> GetByCircle(double x, double y, double radius)
        {
            return null;
        }

        IList<RainfallStation> GetByRect(double x1, double x2, double y1, double y2)
        {
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.CoreEntities.Domain.GeoDisaster.Monitor
{
    public class Rainfall
    {
        public long Id { get; set; }
        public String StationId { get; set; }
        public DateTime CollectTime { get; set; }
        public double RainfallValue { get; set; }
        public virtual RainfallStation RainfallStation { get; set; }
        public int RainfallStationId { get; set; }
    }
}

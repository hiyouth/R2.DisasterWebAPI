using R2.Disaster.CoreEntities.Domain.GeoDisaster.Monitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Domain.Model.Monitor
{
    public class RainfallGroupedByStation
    {
        public RainfallStation RainfallStation { get; set; }
        public List<RainfallTimeAndValue> RainfallTimeAndValues { get; set; }
    }
}

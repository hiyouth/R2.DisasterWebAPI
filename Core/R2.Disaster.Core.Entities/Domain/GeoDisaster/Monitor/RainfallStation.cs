using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.CoreEntities.Domain.GeoDisaster.Monitor
{
    public class RainfallStation
    {
        public String Id { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public double Lon { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double Lat { get; set; }

        public string StationName { get; set; }

        public string Address { get; set; }

        /// <summary>
        /// 所属省名
        /// </summary>
        public string Provinc { get; set; }

        /// <summary>
        /// 所属市名
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 所属县名
        /// </summary>
        public string County { get; set; }
    }
}

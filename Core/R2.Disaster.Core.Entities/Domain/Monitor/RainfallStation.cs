using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.CoreEntities.Domain.GeoDisaster.Monitor
{
    public class RainfallStation
    {
        /// <summary>
        /// 雨量站编号
        /// </summary>
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

        public virtual GBCode GBCode { get; set; }
        public int GBCodeId { get; set; }
    }
}

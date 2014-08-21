using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.WebAPI.ServiceModel
{
    public class EntityPagingModel
    {
        public IList<Object> EntityList { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalCount { get; set; }
    }
}

using R2.Disaster.CoreEntities;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Monitor;
using R2.Disaster.Data;
using R2.Disaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Repository.Monitor
{
    public interface IRainfallRepository : IRepository<Rainfall>
    {
    }
}

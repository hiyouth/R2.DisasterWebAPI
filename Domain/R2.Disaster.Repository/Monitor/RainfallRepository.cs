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
    public class RainfallRepoistory:EFRepository<Rainfall>,IRainfallRepository
    {
        public RainfallRepoistory(IDbContext db)
            : base(db)
        {
            
        }
    }
}

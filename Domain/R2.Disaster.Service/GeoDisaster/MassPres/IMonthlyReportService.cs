using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;

namespace R2.Disaster.Service.GeoDisaster.MassPres
{
    public interface IMonthlyReportService : IPhyRelationEntityService<MonthlyReport>
        ,ICanExecuteExpress<MonthlyReport>
    {

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using R2.Disaster.Repository;

namespace R2.Disaster.Service.GeoDisaster.MassPres
{
    public class MonthlyReportService:PhyRelationEntityService<MonthlyReport>,IMonthlyReportService
    {
        private IRepository<MonthlyReport> _repositoryMonthlyReport;

        public MonthlyReportService(IRepository<MonthlyReport> repoistoryMonthlyReport)
            :base(repoistoryMonthlyReport)
        {
            this._repositoryMonthlyReport = repoistoryMonthlyReport;
        }
    }
}

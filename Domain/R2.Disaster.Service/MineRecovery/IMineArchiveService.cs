using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.MineRecovery;

namespace R2.Disaster.Service.MineRecovery
{
    public interface IMineArchiveService:IEntityServiceBase<MineArchive>,ICanExecuteExpress<MineArchive>
    {
        IQueryable<MineArchive> GetByConditions(string gbCode, string mineSize, string productStatus,
            string keyWord,string exploitSolution);

        MineArchive GetByUnifiedId(string uid);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.MineRecovery;
using R2.Disaster.Repository;

namespace R2.Disaster.Service.MineRecovery
{
    public class MineArchiveService:EntityServiceBase<MineArchive>,IMineArchiveService
    {

        private IRepository<MineArchive> _repositoryMineArchive;

        public MineArchiveService(IRepository<MineArchive> repositoryMineArchive)
            : base(repositoryMineArchive)
        {
            this._repositoryMineArchive = repositoryMineArchive;
        }
    }
}

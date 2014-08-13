using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.MineRecovery;
using R2.Disaster.Repository;

namespace R2.Disaster.Service.MineRecovery
{
    public class MineRemoteSensingCardService:EntityServiceBase<MineRemoteSensingCard>,IMineRemoteSensingCardService
    {

        private IRepository<MineRemoteSensingCard> _repositoryMineCard;

        public MineRemoteSensingCardService(IRepository<MineRemoteSensingCard> repositoryMineCard)
            : base(repositoryMineCard)
        {
            this._repositoryMineCard = repositoryMineCard;
        }
    }
}

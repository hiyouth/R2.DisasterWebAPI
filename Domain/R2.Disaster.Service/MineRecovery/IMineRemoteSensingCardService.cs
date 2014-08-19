﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.MineRecovery;

namespace R2.Disaster.Service.MineRecovery
{
    public interface IMineRemoteSensingCardService:IEntityServiceBase<MineRemoteSensingCard>,
        ICanExecuteExpress<MineRemoteSensingCard>
    {
        MineRemoteSensingCard GetByUnifiedId(string uid);
    }
}

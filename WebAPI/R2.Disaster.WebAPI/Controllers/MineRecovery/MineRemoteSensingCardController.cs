using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using R2.Disaster.CoreEntities.Domain.MineRecovery;
using R2.Disaster.Service.MineRecovery;

namespace R2.Disaster.WebAPI.Controllers.MineRecovery
{
    /// <summary>
    /// 矿山复绿遥感解译卡
    /// </summary>
    public class MineRemoteSensingCardController : EntityControllerBase<MineRemoteSensingCard>
    {

        private IMineRemoteSensingCardService _remoteCardService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="remoteCardService"></param>
        public MineRemoteSensingCardController(IMineRemoteSensingCardService remoteCardService)
            : base(remoteCardService)
        {
            this._remoteCardService = remoteCardService;
        }

        public MineRemoteSensingCard GetByUId(string uid)
        {
            if (String.IsNullOrEmpty(uid))
            {
                throw new Exception("传入的参数不能为空值");
            }
            return this._remoteCardService.GetByUnifiedId(uid);
        }
    }
}
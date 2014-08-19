using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using R2.Disaster.CoreEntities.Domain.MineRecovery;
using R2.Disaster.Service.MineRecovery;

namespace R2.Disaster.WebAPI.Controllers.MineRecovery
{
    /// <summary>
    /// 矿山复绿环境调查表
    /// </summary>
    public class MineEnvironmentSurveyController:EntityControllerBase<MineEnvironmentSurvey>
    {

        private IMineEnvironmentSurveyService _mineEnvironmentService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mintEnvironmentService"></param>
        public MineEnvironmentSurveyController(IMineEnvironmentSurveyService mintEnvironmentService)
            : base(mintEnvironmentService)
        {
            this._mineEnvironmentService = mintEnvironmentService;
        }

        public MineEnvironmentSurvey GetByUId(string uid)
        {
            if (String.IsNullOrEmpty(uid))
            {
                throw new Exception("传入的参数不能为空值");
            }
            return this._mineEnvironmentService.GetByUnifiedId(uid);
        }
    }
}
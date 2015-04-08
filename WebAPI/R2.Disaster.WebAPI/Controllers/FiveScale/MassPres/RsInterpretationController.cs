using R2.Disaster.CoreEntities.Domain.FiveScale.MassPres;
using R2.Disaster.Service.GeoDisaster.MassPres;

namespace R2.Disaster.WebAPI.Controllers.GeoDisaster.MassPres
{
    public class RsInterpretationController : PhyRelationEntityController<RsInterpretation>
    {
        private IRsInterpretationService _rsInterpretationService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rsInterpretationService"></param>
        public RsInterpretationController(IRsInterpretationService rsInterpretationService)
            : base(rsInterpretationService)
        {
            this._rsInterpretationService = rsInterpretationService;
        }


    }
}

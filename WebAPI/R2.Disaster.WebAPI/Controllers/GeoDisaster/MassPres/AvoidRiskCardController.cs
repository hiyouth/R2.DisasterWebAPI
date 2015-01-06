using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using R2.Disaster.Service.GeoDisaster;
using R2.Disaster.Service.GeoDisaster.MassPres;

namespace R2.Disaster.WebAPI.Controllers.GeoDisaster.MassPres
{
    public class AvoidRiskCardController : PhyRelationEntityController<AvoidRiskCard>
    {
        private IAvoidRiskCardService _cardService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cardService"></param>
        public AvoidRiskCardController(IAvoidRiskCardService cardService)
            : base(cardService)
        {
            this._cardService = cardService;
        }


        /// <summary>
        /// 根据统一编号查询避灾明白卡
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public IList<AvoidRiskCard> GetByUid(string uid)
        {
            if (String.IsNullOrEmpty(uid))
                throw new Exception("避灾明白卡的统一编号不能是“ ”或者Null");
            List<AvoidRiskCard> cards = this._cardService.GetByUId(uid).ToList();
            return cards;
        }
    }
}

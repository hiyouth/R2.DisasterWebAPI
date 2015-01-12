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
    public class WorkingGuideCardFSController : PhyRelationEntityController<WorkingGuideCardFS>
    {
        private IWorkingGuideCardFSService _cardService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cardService"></param>
        public WorkingGuideCardFSController(IWorkingGuideCardFSService cardService)
            : base(cardService)
        {
            this._cardService = cardService;
        }


        /// <summary>
        /// 根据统一编号查询工作明白卡
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public IList<WorkingGuideCardFS> GetByUid(string uid)
        {
            if (string.IsNullOrEmpty(uid))
                throw new Exception(@"工作明白卡的统一编号不能是“ ”或者Null");
            List<WorkingGuideCardFS> cards = this._cardService.GetByUid(uid).ToList();
            return cards;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;

namespace R2.Disaster.Service.GeoDisaster.MassPres
{
    public interface IWorkingGuideCardService : IPhyRelationEntityService<WorkingGuideCard>, ICanExecuteExpress<WorkingGuideCard>
    {

        /// <summary>
        /// 通过统一编号查询工作明白卡
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        IQueryable<WorkingGuideCard> GetByUid(string uid);
    }
}

using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.GeoDisaster.MassPres
{
    public interface IMassPreService:IPhyRelationEntityService<MassPre>
    {
        IQueryable<MassPre >GetByUid(string uid);

        /// <summary>
        /// 关键字将检索名称和统一编号两个属性
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        IQueryable<MassPre> GetByKeyWord(string keyWord);

        //IQueryable<MassPre> GetByGBCode(string gbcode);
    }
}

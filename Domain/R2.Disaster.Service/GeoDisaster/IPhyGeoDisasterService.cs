using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.GeoDisaster
{
    public interface IPhyGeoDisasterService:IEntityServiceBase<PhyGeoDisaster>
    {
        PhyGeoDisaster GetById(int id);
        IQueryable<PhyGeoDisaster> GetByIds(int[] ids);
        /// <summary>
        /// 根据条件，返回符合条件的集合
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IQueryable<PhyGeoDisaster> ExecuteConditions(Expression<Func<PhyGeoDisaster , bool>> condition);

        PhyGeoDisaster GetByCustomizeId(string cusomizeId);

        IQueryable<PhyGeoDisaster> GetByConditions(List<string> gbcodeIds, List<EnumGeoDisasterType?> types);
        IQueryable<PhyGeoDisaster> GetByConditions(string gbCode, EnumGeoDisasterType? type);
        IQueryable<PhyGeoDisaster> GetByKeyWord(string keyword);
    }
}

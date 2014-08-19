using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.GeoDisaster
{
    public interface IPhyRelationEntityService<T>:IEntityServiceBase<T>
        where T : PhyRelationEntity
    {
        /// <summary>
        /// 根据物理点Id获取相关实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IQueryable<T> GetByPhyId(int id);
    }
}

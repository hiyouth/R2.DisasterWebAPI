using R2.Disaster.CoreEntities.Domain.GeoDisaster.PotentialThreats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.GeoDisaster.PotentialThreats
{
    /// <summary>
    /// 隐患点相关信息，江西地灾设定属性，其他项目可忽略
    /// </summary>
    public interface IThreatService :IPhyRelationEntityService<Threat>,ICanExecuteExpress<Threat>
    {
        /// <summary>
        /// 更改隐患点的隐患状态
        /// </summary>
        /// <param name="id">隐患点主键Id</param>
        /// <param name="isActive">激活还是消除隐患点</param>
        /// <returns>被更改状态的隐患实体的物理点主键号</returns>
        int ChangeActiveStatus(int id,bool isActive);

        /// <summary>
        /// 更改隐患点的隐患状态
        /// </summary>
        /// <param name="phyId">隐患点物理Id</param>
        /// <param name="isActive">激活还是消除隐患点</param>
        /// <returns>被更改状态的隐患实体的主键号</returns>
        int ChangeActiveStatusByPhyId(int phyId, bool isActive);
    }
}

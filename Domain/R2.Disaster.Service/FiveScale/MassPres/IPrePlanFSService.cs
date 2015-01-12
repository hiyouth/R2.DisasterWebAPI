using Corner.Core;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.GeoDisaster.MassPres
{
    public interface IPrePlanFSService:IPhyRelationEntityService<PrePlanFS>,ICanExecuteExpress<PrePlanFS>
    {
        ///// <summary>
        ///// 通过主键编号查询预案信息
        ///// </summary>
        ///// <param name="id">防灾预案实体编号</param>
        ///// <returns></returns>
        //PrePlan Get(int id);

        /// <summary>
        /// 通过防灾预案所属的物理点Id查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PrePlanFS GetByPhyId(int id);

        /// <summary>
        /// 通过统一编号，模糊查询防灾预案
        /// </summary>
        /// <param name="uid">统一编号标示</param>
        /// <returns></returns>
        IQueryable<PrePlanFS> GetByUId(string uid);

        /// <summary>
        /// 通过关键字检索防灾预案信息，
        /// 将检索以下属性：名称、地理位置以及统一编号
        /// </summary>
        /// <param name="keyWord">关键字</param>
        /// <returns></returns>
        IQueryable<PrePlanFS> GetByKeyWord(string keyWord);
    }
}

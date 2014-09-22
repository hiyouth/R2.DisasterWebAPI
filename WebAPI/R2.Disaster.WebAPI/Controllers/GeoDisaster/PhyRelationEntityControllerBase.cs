using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.Service.GeoDisaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace R2.Disaster.WebAPI.Controllers.GeoDisaster
{
    public class PhyRelationEntityController<T>:EntityControllerBase<T>
        where T:PhyRelationEntity
    {
        private IPhyRelationEntityService<T> _phyRelationService;
        public PhyRelationEntityController(IPhyRelationEntityService<T> phyRelationService )
            :base(phyRelationService)
        {
            this._phyRelationService = phyRelationService;
        }

        /// <summary>
        /// 通过物理点主键编号查询
        /// <param name="id">物理点主键编号</param>
        /// </summary>
        /// <returns></returns>
        public IList<T> GetByPhyId([FromUri] int id)
        {
            IQueryable<T> query = this._phyRelationService.GetByPhyId(id);
            List<T> list = query.ToList();
            return list;
        }

        /// <summary>
        /// 通过一组物理点逐渐编号进行实体查询
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IList<T> GetByPhyIds([FromUri] string ids)
        {
            if (String.IsNullOrEmpty(ids))
                throw new Exception("参数非法");
            String[] phyIds = ids.Split(',');
            // TODO:RRDL
            int[] phyIdsInt = Array.ConvertAll<String, int>(phyIds, id => Convert.ToInt32(id));
            IQueryable<T> query = this._phyRelationService.GetByPhyIds(phyIdsInt);
            List<T> list = query.ToList();
            return list;
        }
    }
}
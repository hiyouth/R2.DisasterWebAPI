using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Relocation;
using R2.Disaster.Repository;

namespace R2.Disaster.Service.GeoDisaster.Relocation
{
    public class RelocationComprehensiveService : PhyRelationEntityService<RelocationComprehensive>
        , IRelocationComprehensiveService
    {
        private IRepository<RelocationComprehensive> _repositoryRelocation;

        public RelocationComprehensiveService(IRepository<RelocationComprehensive> repository)
            : base(repository)
        {
            this._repositoryRelocation = repository;
        }


        /// <summary>
        /// 根据统一编号查询移民搬迁信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public IQueryable<RelocationComprehensive> GetByUnifiedId(string uid)
        {
            return this._repositoryRelocation.Table.Where(a => a.统一编号 == uid)
                .Select(x => x);
        }
    }
}

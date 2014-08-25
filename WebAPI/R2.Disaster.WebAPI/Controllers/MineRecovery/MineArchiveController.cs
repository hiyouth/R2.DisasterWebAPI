using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using R2.Disaster.CoreEntities.Domain.MineRecovery;
using R2.Disaster.Service.MineRecovery;
using R2.Disaster.WebFramework.Mvc.Filters;

namespace R2.Disaster.WebAPI.Controllers.MineRecovery
{
    /// <summary>
    /// 矿山复绿基础档案表
    /// </summary>
    [PagingFilter]
    public class MineArchiveController:EntityControllerBase<MineArchive>
    {

        private IMineArchiveService _mineArchiveService;

        public MineArchiveController(IMineArchiveService mineArchiveService)
            : base(mineArchiveService)
        {
            this._mineArchiveService = mineArchiveService;
        }

        public MineArchive GetByUId(string uid)
        {
            if (String.IsNullOrEmpty(uid))
            {
                throw new Exception("传入的参数不能为空值");
            }
            return this._mineArchiveService.GetByUnifiedId(uid);
        }

        public IQueryable<MineArchive> GetByConditions(string gbCode = null, string mineSize = null,
            string productStatus = null, string keyWord = null,string exploitSolution=null,int ps=10,
            int pn=1)
        {
            IQueryable<MineArchive> query = this._mineArchiveService.GetByConditions(
                gbCode, mineSize, productStatus, keyWord,exploitSolution);
            //IList<MineArchive> list = query.ToList();
            return query;
        }
    }
}
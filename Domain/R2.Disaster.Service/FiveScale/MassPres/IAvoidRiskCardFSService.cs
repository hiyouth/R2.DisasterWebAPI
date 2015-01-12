﻿using System.Security.Cryptography.X509Certificates;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corner.Core;

namespace R2.Disaster.Service.GeoDisaster.MassPres
{
    public interface IAvoidRiskCardFSService : IPhyRelationEntityService<AvoidRiskCardFS>, ICanExecuteExpress<AvoidRiskCardFS>
    {


        /// <summary>
        /// 通过统一编号查询避灾明白卡
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        IQueryable<AvoidRiskCardFS> GetByUId(string uid);
    }
}

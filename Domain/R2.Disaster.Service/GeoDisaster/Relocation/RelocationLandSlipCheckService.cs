﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Relocation;
using R2.Disaster.Repository;

namespace R2.Disaster.Service.GeoDisaster.Relocation
{
    public class RelocationLandSlipCheckService : PhyRelationEntityService<RelocationLandSlipCheck>
        , IRelocationLandSlipCheckService
    {
        private IRepository<RelocationLandSlipCheck> _repositoryLandSlip;

        public RelocationLandSlipCheckService(IRepository<RelocationLandSlipCheck> repositoryLandSlip)
            : base(repositoryLandSlip)
        {
            this._repositoryLandSlip = repositoryLandSlip;
        }
    }
}

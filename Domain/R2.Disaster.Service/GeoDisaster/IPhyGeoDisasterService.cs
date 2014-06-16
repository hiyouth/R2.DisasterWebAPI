﻿using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.GeoDisaster
{
    public interface IPhyGeoDisasterService
    {
        void New(PhyGeoDisaster phy);
        void Update(PhyGeoDisaster phy);
        PhyGeoDisaster GetById(int id);
        IQueryable<PhyGeoDisaster> GetByConditions(List<string> gbcodeIds, List<EnumGeoDisasterType?> types);
        IQueryable<PhyGeoDisaster> GetByConditions(string gbCode, EnumGeoDisasterType? type);
        IQueryable<PhyGeoDisaster> GetByKeyWord(string keyword);
    }
}

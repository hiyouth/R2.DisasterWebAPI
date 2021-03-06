﻿
using R2.Disaster.CoreEntities.Domain.FiveScale.Investigation;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace R2.Disaster.Service.GeoDisaster.Investigation
{
    public interface IComprehensiveFSService:ICanExecuteExpress<ComprehensiveFS>
        ,IPhyRelationEntityService<ComprehensiveFS>
    {
        ComprehensiveFS GetByUnifiedID(string uid);

        /// <summary>
        /// 通过物理灾害点编号获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ComprehensiveFS GetByPhyId(int id);
        void New(ComprehensiveFS ghc);
        IQueryable<ComprehensiveFS> GetByUnifiedId(string uid);
        IQueryable<ComprehensiveFS> GetByName(string name);

        IQueryable<ComprehensiveFS> GetByConditions(List<string> gbCodes,
            List<string> situationLevs, List<string> dangerousLevs, List<EnumGeoDisasterType?> types);

        IQueryable<ComprehensiveFS> GetByConditions(String gbCode, String situationLev, String dangerous,
            EnumGeoDisasterType? type);

        IQueryable<ComprehensiveFS> GetByKeyWord(string keyWord);
        IQueryable<ComprehensiveFS> GetByRect(double x1, double x2, double y1, double y2);
        IQueryable<ComprehensiveFS> GetByCircle(double x, double y, double radious);

    }
}

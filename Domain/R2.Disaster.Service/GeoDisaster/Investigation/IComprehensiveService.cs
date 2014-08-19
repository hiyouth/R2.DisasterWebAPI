using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace R2.Disaster.Service.GeoDisaster.Investigation
{
    public interface IComprehensiveService:ICanExecuteExpress<Comprehensive>
        ,IPhyRelationEntityService<Comprehensive>
    {
        Comprehensive GetByUnifiedID(string uid);

        /// <summary>
        /// 通过物理灾害点编号获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Comprehensive GetByPhyId(int id);
        void New(Comprehensive ghc);
        IQueryable<Comprehensive> GetByUnifiedId(string uid);
        IQueryable<Comprehensive> GetByName(string name);
       
        IQueryable<Comprehensive> GetByConditions(List<string> gbCodes,
            List<string> situationLevs, List<string> dangerousLevs, List<EnumGeoDisasterType?> types);

        IQueryable<Comprehensive> GetByConditions(String gbCode,String situationLev,String dangerous,
            EnumGeoDisasterType? type);

        IQueryable<Comprehensive> GetByKeyWord(string keyWord);
        IQueryable<Comprehensive> GetByRect(double x1, double x2, double y1, double y2);
        IQueryable<Comprehensive> GetByCircle(double x, double y, double radious);

    }
}

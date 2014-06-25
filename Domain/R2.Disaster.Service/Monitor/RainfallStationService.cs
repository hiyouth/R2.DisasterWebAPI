using R2.Disaster.CoreEntities.Domain.GeoDisaster.Monitor;
using R2.Disaster.Repository;
using R2.Helper.GIS;
using R2.Helper.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.Monitor
{
    public class RainfallStationService:EntityServiceBase<RainfallStation>,IRainfallStationService
    {
        public RainfallStationService(IRepository<RainfallStation> repositoryRainfallStation)
            :base(repositoryRainfallStation)
        {

        }

        public IQueryable<RainfallStation> GetByName(string name)
        {
            var q = from r in this._repository.Table
                    where r.StationName.Contains(name)
                    select r;
            return q;
        }

        public IQueryable<RainfallStation> GetByGBCode(string gbcodeId)
        {
            var q = from r in this._repository.Table
                    where r.GBCodeId.Contains(gbcodeId)
                    select r;
            return q;
        }

        public IQueryable<RainfallStation> GetByRect(double x1, double x2, double y1, double y2)
        {
            var func = LonLatHelper.GetExpressionLonLatInRect(x1, x2, y1, y2);
            var q = from r in this._repository.Table
                    where LonLatHelper.GetLonLatIsInRect(x1,x2,y1,y2,r.Lon,r.Lat)
                    select r;
            return q;
        }

        public IQueryable<RainfallStation> GetByCircle(double x, double y, double radius)
        {
            var q = from r in this._repository.Table
                    where LonLatHelper.GetLonLatIsInCircle(x, y, radius, r.Lon, r.Lat)
                    select r;
            return q;
        }

        #region 表达式树
        //public Expression<Func<RainfallStation, Boolean>> GetExpressionByName(string name)
        //{
            
        //}
        //public Expression<Func<RainfallStation, Boolean>>  GetExpressionByRect
        //    (double x1,double x2,double y1,double y2)
        //{
        //    LinqEntityHelper.GetExpressionForSingle<RainfallStation,String>(
        //}
        #endregion
    }
}

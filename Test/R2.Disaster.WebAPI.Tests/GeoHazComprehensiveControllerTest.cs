using Microsoft.VisualStudio.TestTools.UnitTesting;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using R2.Disaster.Data;
using R2.Disaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.WebAPI.Controllers;
using R2.Disaster.WebAPI.Controllers.DisasterInvestigation;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.Service.GeoDisaster;

namespace R2.Disaster.WebAPI.Tests
{
    [TestClass]
    public class GeoHazComprehensiveControllerTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetByUIdCanNotBeNull()
        {
            IDbContext db = new R2DisasterContext();
            IRepository<Comprehensive> re = new EFRepository<Comprehensive>(db);
            IComprehensiveService s = new ComprehensiveService(re);
            GeoDisasterController c = new GeoDisasterController(s);
            string a=null;
            c.GetByUId(a);
        }
    }
}

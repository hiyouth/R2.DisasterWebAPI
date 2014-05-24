using Microsoft.VisualStudio.TestTools.UnitTesting;
using R2.Disaster.CoreEntities.Domain.DisasterInvestigation;
using R2.Disaster.Data;
using R2.Disaster.Repository;
using R2.Disaster.Service.DisasterInvestigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.WebAPI.Controllers;
using R2.Disaster.WebAPI.Controllers.DisasterInvestigation;

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
            IRepository<GHComprehensive> re = new EFRepository<GHComprehensive>(db);
            IGHComprehensiveService s = new GHComprehensiveService(re);
            GeoHazardsController c = new GeoHazardsController(s);
            string a=null;
            c.GetByUId(a);
        }
    }
}

using Newtonsoft.Json;
using R2.Disaster.CoreEntities;
using R2.Disaster.CoreEntities.Domain.GeoHazard.Investigation;
using R2.Disaster.Service.GeoHazard.Investigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace R2.Disaster.WebAPI.Controllers.DisasterInvestigation
{
    public class GeoHazardsController:ApiController
    {
        private IGHComprehensiveService _cpsService;
        public GeoHazardsController(IGHComprehensiveService cpsService)
        {
            this._cpsService = cpsService;
        }

        public GeoHazardsController()
        {

        }

        //public List<GHComprehensive> GetAll()
        //{
        //    return null;
        //}

        [HttpGet]
        public Book GetBook(string uid)
        {
            Book book = new Book()
            {
                Id = 3,
                Name = "333",
                Price = 5,
                Category = new Category()
                {
                    Id=8,
                   Name="32323" 
                }
            };
            return book;
        }

        [HttpGet]
        public GHComprehensive GetByUId(string uid)
        {
            if (String.IsNullOrEmpty(uid))
                throw new Exception("灾害点的统一编号不能为Null或者空字符串");
            GHComprehensive g=_cpsService.GetByUnifiedID(uid);
           
            //JsonSerializerSettings a = new JsonSerializerSettings();
            //a.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //string s = JsonConvert.SerializeObject(g, a);
            return g;
        }

        public void New(GHComprehensive ghc)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace R2.Disaster.WebAPI.Controllers.GeoDisaster
{
    public class PhyGeoDisasterController : ApiController
    {
        // GET api/phygeodisaster
        public IEnumerable<string> GetByLocation()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/phygeodisaster/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/phygeodisaster
        public void Post([FromBody]string value)
        {
        }

        // PUT api/phygeodisaster/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/phygeodisaster/5
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace R2.Disaster.WebAPI.Controllers.GeoDisaster.Investigation
{
    public class DebrisFlowController : ApiController
    {
        // GET api/debrisflow
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/debrisflow/5
        public string GetBy(int id)
        {
            return "value";
        }

        // POST api/debrisflow
        public void Post([FromBody]string value)
        {
        }

        // PUT api/debrisflow/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/debrisflow/5
        public void Delete(int id)
        {
        }
    }
}

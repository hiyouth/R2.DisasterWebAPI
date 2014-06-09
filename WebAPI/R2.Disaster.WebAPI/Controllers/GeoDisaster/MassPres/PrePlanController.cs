using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace R2.Disaster.WebAPI.Controllers.GeoDisaster.MassPres
{
    public class PrePlanController : ApiController
    {
        // GET api/preplan
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/preplan/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/preplan
        public void Post([FromBody]string value)
        {
        }

        // PUT api/preplan/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/preplan/5
        public void Delete(int id)
        {
        }
    }
}

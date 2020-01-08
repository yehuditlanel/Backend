using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication.Controllers
{
    public class TravelController : ApiController
    {
        // GET: api/Travel
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Travel/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Travel
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Travel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Travel/5
        public void Delete(int id)
        {
        }
    }
}

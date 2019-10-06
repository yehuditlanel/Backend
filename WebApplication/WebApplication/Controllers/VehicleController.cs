using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using common;
using bll;
namespace WebApplication.Controllers
{
    public class VehicleController : ApiController
    {
        // GET: api/Vehicle
        public List<common.Details_of_vehicles> Get()
        {
            return Management_of_vehicles.viewVehicles();
        }

        // GET: api/Vehicle/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Vehicle
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Vehicle/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Vehicle/5
        public void Delete(int id)
        {
        }
    }
}

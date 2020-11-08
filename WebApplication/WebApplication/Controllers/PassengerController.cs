using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using bll;
using common;
namespace WebApplication.Controllers
{
    public class PassengerController : ApiController
    {
        // GET: api/Passenger
        public List<Station> Get()
        {
            return ManagmentOfPassenger.GetPassengers();
        }

        // GET: api/Passenger/5
        public List<Station> Get(int trackCode)
        {
            return ManagmentOfPassenger.GetPassengers(trackCode);
        }

        // POST: api/Passenger
        public void Post([FromBody]Station detailsOfPassenger)
        {
            ManagmentOfPassenger.AddPassenger(detailsOfPassenger);
        }

        // PUT: api/Passenger/5
        public void Put([FromBody]Station detailsOfPassenger)
        {
            ManagmentOfPassenger.UpdatePassenger(detailsOfPassenger);
        }

        // DELETE: api/Passenger/5
        public void Delete(string id)
        {
            ManagmentOfPassenger.RemovePassenger(id);
        }
    }
}

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
    public class TravelController : ApiController
    {
        // GET: api/Travel
        public List<common.DetailsOfTravel> Get()
        {
            return ManagmentOfTravel.GetTravels();
        }

        // GET: api/Travel/5
        public List<common.DetailsOfTravel> Get(int groupCode)
        {
            return ManagmentOfTravel.GetTravels(groupCode);
        }

        // POST: api/Travel
        public void Post([FromBody]DetailsOfTravel detailsOfTravel)
        {
            ManagmentOfTravel.AddTravel(detailsOfTravel);
        }

        // PUT: api/Travel/5
        public void Put([FromBody]DetailsOfTravel detailsOfTravel)
        {
            //maybe need to update the tracks...
            ManagmentOfTravel.UpdateTravel(detailsOfTravel);
        }

        // DELETE: api/Travel/5
        public void Delete(string id)
        {
            //need to delete also all the tracks...
            ManagmentOfTravel.RemoveTravel(id);
        }
    }
}

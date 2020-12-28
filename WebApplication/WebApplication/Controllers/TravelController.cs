using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using bll;
using common;
using Newtonsoft.Json;

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
        public int Post()
        {
            var httpRequest = HttpContext.Current.Request;
            var file = httpRequest.Files["file"];
            var data = httpRequest.Form["data"];
            DetailsOfTravel detailsOfTravel =
                JsonConvert.DeserializeObject<DetailsOfTravel>(
                    httpRequest.Form["data"]
                    );
           return ManagmentOfTravel.AddTravel(detailsOfTravel,file.InputStream);
        }
        //public int Post([FromBody]DetailsOfAddTravel detailsOfAddTravel)
        //{
        //    ManagmentOfTravel.AddTravel(detailsOfAddTravel);
        //    return 1;
        //}
        // PUT: api/Travel/5
        public void Put([FromBody]DetailsOfTravel detailsOfTravel)
        {
            //maybe need to update the tracks...
            ManagmentOfTravel.UpdateTravel(detailsOfTravel);
        }

        // DELETE: api/Travel/5
        public void Delete(int id)
        {
            //need to delete also all the tracks...
            ManagmentOfTravel.RemoveTravel(id);
        }
    }
}

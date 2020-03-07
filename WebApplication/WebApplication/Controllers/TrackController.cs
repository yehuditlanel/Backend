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
    [RoutePrefix("api/Track")]
    public class TrackController : ApiController
    {
        // GET: api/Track
        public List<common.DetailsOfTrack> Get()
        {
            return ManagmentOTrack.GetTracks();
        }

        // GET: api/Track/5
        public List<common.DetailsOfTrack> Get(int travelCode)
        {
           return ManagmentOTrack.GetTracks(travelCode);
        }
        [Route("GetTrackByDriverId")]
        [HttpGet]
        public List<DetailsOfTrack> GetTrackByDriverId(int userId)
        {
            return ManagmentOTrack.GetTrackByDriverId(userId);
        }
        // POST: api/Track
        public void Post([FromBody]DetailsOfTrack detailsOfTrack)
        {
            ManagmentOTrack.AddTrack(detailsOfTrack);
        }

        // PUT: api/Track/5
        public void Put([FromBody]DetailsOfTrack detailsOfTrack)
        {
            ManagmentOTrack.UpdateTrack(detailsOfTrack);
        }

        // DELETE: api/Track/5
        public void Delete(string id)
        {
            ManagmentOTrack.RemoveTrack(id);
        }
    }
}

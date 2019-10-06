using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public List<common.DetailsOfUser> Get()
        {
            List<common.DetailsOfUser> usersList = new List<common.DetailsOfUser>();
            usersList =
                bll.ManagmentOfUser.listOfUser();
            return usersList;
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}

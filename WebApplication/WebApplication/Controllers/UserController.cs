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
    public class UserController : ApiController
    {
        // GET: api/User
        public List<DetailsOfUser> Get()
        {
            return ManagmentOfUser.GetUsers();
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]DetailsOfUser detailsOfUser)
        {
            ManagmentOfUser.addUser(detailsOfUser);
        }

        // PUT: api/User/5
        public void Put([FromBody]DetailsOfUser detailsOfUser)
        {
            ManagmentOfUser.UpdateUser(detailsOfUser);
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            ManagmentOfUser.RemoveUser(id);
        }
    }
}

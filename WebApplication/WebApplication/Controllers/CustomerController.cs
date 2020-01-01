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
    public class CustomerController : ApiController
    {
       
        // GET: api/Customer
        public List<common.DetailsOfCustomer> Get()
        {
            return ManagmentOfCustomer.GetCustomers();
        }

        // GET: api/Customer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        public void Post([FromBody]DetailsOfCustomer detailsOfCustomer)
        {
            ManagmentOfCustomer.addCustomer(detailsOfCustomer);
        }

        // PUT: api/Customer/5
        public void Put([FromBody]DetailsOfCustomer detailsOfCustomer)
        {
            ManagmentOfCustomer.UpdateCustomer(detailsOfCustomer);
        }

        // DELETE: api/Customer/5
        public void Delete(string id)
        {
            ManagmentOfCustomer.RemoveCustomer(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
namespace dal
{
    public class ManagementOfCustomer
    {
        public static ManagementOfCustomer management_of_customer;
        static ManagementOfCustomer()
        {
            management_of_customer = new dal.ManagementOfCustomer();
        }
        public void addCustomer(DetailsOfCustomer detailsOfCustomer)
        {
            //the function ConvertCustomerToDal with this in ()
            //Customers detailsOfCustomerDal = detailsOfCustomer.ConvertCustomerToDal();
            DataBaseEntities db = new DataBaseEntities();
            db.Customers.Add(detailsOfCustomer.ConvertCustomerToDal());
            db.SaveChanges();
        }
        public List<DetailsOfCustomer> listOfCustomer()
        {
            List<Customers> listDetailsOfCustomers;
            using (var DbContext = new DataBaseEntities())
            {
                listDetailsOfCustomers=DbContext.Customers.ToList();
            }
            return listDetailsOfCustomers.Select(c => Mapper.Convert_customer_to_common(c)).ToList();
        }
    }
}

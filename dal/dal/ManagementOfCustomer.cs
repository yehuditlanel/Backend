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
        public void AddCustomer(DetailsOfCustomer detailsOfCustomer)
        {
            DataBaseEntities db = new DataBaseEntities();
            db.Customers.Add(detailsOfCustomer.ConvertCustomerToDal());
            db.SaveChanges();
        }
        public List<DetailsOfCustomer> GetCustomers()
        {
            List<Customers> customers;
            using (var DbContext = new DataBaseEntities())
            {
                customers = DbContext.Customers.ToList();
            }
            return customers.Select(c => Mapper.ConvertCustomerToCommon(c)).ToList();
        }
        public void RemoveCustomer(int id)
        {
            string i = id.ToString();
            using (var db = new DataBaseEntities())
            {
                Customers c= db.Customers.Find(i);
                if (c != null)
                {
                    db.Customers.Remove(c);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateCustomer(DetailsOfCustomer detailsOfCustomer)
        {
            Customers customers = Mapper.ConvertCustomerToDal(detailsOfCustomer);
            using(var db=new DataBaseEntities())
            {
                db.Entry<Customers>(db.Set<Customers>().Find(customers.Group_s_code)).CurrentValues.SetValues(customers);
                db.SaveChanges();
            }
        }
    }
}

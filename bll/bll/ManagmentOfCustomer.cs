using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal;
using common;
namespace bll
{
    public static class ManagmentOfCustomer
    {
        public static List<DetailsOfCustomer> GetCustomers()
        {
            return ManagementOfCustomer.management_of_customer.GetCustomers();
        }
        public static void addCustomer(DetailsOfCustomer details_of_customer)
        {
            ManagementOfCustomer.management_of_customer.AddCustomer(details_of_customer);
        }
        public static void RemoveCustomer(string id)
        {
            ManagementOfCustomer.management_of_customer.RemoveCustomer(id);
        }
        public static void UpdateCustomer(DetailsOfCustomer detailsOfCustomer)
        {
            ManagementOfCustomer.management_of_customer.UpdateCustomer(detailsOfCustomer);
        }
    }
}

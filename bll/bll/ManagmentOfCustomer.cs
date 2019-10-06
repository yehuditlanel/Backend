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
        public static List<DetailsOfCustomer> listOfCustomer()
        {
            return ManagementOfCustomer.management_of_customer.listOfCustomer();
        }
        public static void addCustomer(DetailsOfCustomer details_of_customer)
        {
            ManagementOfCustomer.management_of_customer.addCustomer(details_of_customer);
        }
    }
}

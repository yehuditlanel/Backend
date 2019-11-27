using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
using dal;
namespace bll
{
    public class ManagmentOfUser
    {
        public static List<DetailsOfUser> GetUsers()
        {
            return ManagementOfUser.management_of_user.GetUsers();
            //dal.Users users = new dal.Users();
            //List<DetailsOfUser> listDetailsOfUser =
            //    dal.ManagementOfUser.management_of_user.listOfUser();
            //return listDetailsOfUser;
        }
        public static void addUser(DetailsOfUser detailsOfUser)
        {
            ManagementOfUser.management_of_user.AddUser(detailsOfUser);
            //dal.ManagementOfCustomer management_of_customer = new dal.ManagementOfCustomer();
            //management_of_customer.AddCustomer(details_of_customer);
        }
        public static void RemoveUser(int id)
        {
            ManagementOfUser.management_of_user.RemoveUser(id);
        }
        public static void UpdateUser(DetailsOfUser detailsOfUser)
        {
            ManagementOfUser.management_of_user.UpdateUser(detailsOfUser);
        }
    }
}

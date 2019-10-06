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
        public static List<DetailsOfUser> listOfUser()
        {
            dal.Users users = new dal.Users();
            List<DetailsOfUser> listDetailsOfUser =
                dal.ManagementOfUser.management_of_user.listOfUser();
            return listDetailsOfUser;


        }
        public static void addUser(common.DetailsOfCustomer details_of_customer)
        {
            dal.ManagementOfCustomer management_of_customer = new dal.ManagementOfCustomer();
            management_of_customer.addCustomer(details_of_customer);
        }









        //public static Boolean logIn(DetailsOfUser detailsOfUser)
        //{
        //    return false;
        //}
        //public static void addVehicles(common.Details_of_vehicles details_of_vehicles)
        //{
        //    dal.Management_of_vehicles management_of_vehicles = new dal.Management_of_vehicles();
        //    management_of_vehicles.addVehicles(details_of_vehicles);
        //}
        //public static List<common.Details_of_vehicles> viewVehicles()
        //{
        //    dal.Management_of_vehicles management_Of_Vehicles = new dal.Management_of_vehicles();
        //    List<common.Details_of_vehicles> list = management_Of_Vehicles.viewVehicles();
        //    return list;
        //}
    }
}

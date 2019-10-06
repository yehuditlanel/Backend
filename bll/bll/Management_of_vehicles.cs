using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
using dal;
namespace bll
{
    public static class Management_of_vehicles
    {
        public static void addVehicles(common.Details_of_vehicles details_of_vehicles)
        {
            dal.ManagementOfVehicles management_of_vehicles=new dal.ManagementOfVehicles();
            management_of_vehicles.addVehicles(details_of_vehicles);
        }
        public static List<common.Details_of_vehicles> viewVehicles()
        {
            dal.ManagementOfVehicles management_Of_Vehicles = new dal.ManagementOfVehicles();
            List<common.Details_of_vehicles>list= management_Of_Vehicles.viewVehicles();
            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
using dal;
namespace bll
{
    public static class ManagementOfVehicle
    {
        public static List<DetialsOfVehicles> GetVehicles()
        {
            return ManagementOfVehicles.management_of_vehicles.GetVehicles();
        }
        public static void AddVehicle(DetialsOfVehicles detialsOfVehicles)
        {
            ManagementOfVehicles.management_of_vehicles.AddVehicle(detialsOfVehicles);
        }
        //public static void RemoveCustomer(int id)
        //{
        //    ManagementOfCustomer.management_of_customer.RemoveCustomer(id);
        //}
        public static void UpdateVehicle(DetialsOfVehicles detialsOfVehicles)
        {
            ManagementOfVehicles.management_of_vehicles.UpdateVehicle(detialsOfVehicles);
        }
    }
}

﻿using System;
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
        public static List<VehicleType> GetVehicles()
        {
            return ManagementOfVehicles.management_of_vehicles.GetVehicles();
        }
        public static void AddVehicle(VehicleType detialsOfVehicles)
        {
            ManagementOfVehicles.management_of_vehicles.AddVehicle(detialsOfVehicles);
        }
        public static void RemoveVehicle(int id)
        {
            ManagementOfVehicles.management_of_vehicles.RemoveVehicle(id);
        }
        public static void UpdateVehicle(VehicleType detialsOfVehicles)
        {
            ManagementOfVehicles.management_of_vehicles.UpdateVehicle(detialsOfVehicles);
        }
    }
}

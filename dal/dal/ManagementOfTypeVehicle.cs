using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
namespace dal
{
    public class ManagementOfTypeVehicle
    {
        public static ManagementOfTypeVehicle management_of_type_vehicle;
        static ManagementOfTypeVehicle()
        {
            management_of_type_vehicle = new dal.ManagementOfTypeVehicle();
        }
        public List<VehicleType> GetTypeVehicle()
        {
            List<Type_of_vehicles> type_Of_Vehicles;
            using (var DbContext = new DataBaseEntities())
            {
                type_Of_Vehicles = DbContext.Type_of_vehicles.ToList();
            }
            return type_Of_Vehicles.Select(p => Mapper.ConvertTypeVehicleToCommon(p)).ToList();
        }
    }
}

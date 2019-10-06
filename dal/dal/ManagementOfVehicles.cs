using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
namespace dal
{
   public  class ManagementOfVehicles
    {
        public void addVehicles(common.Details_of_vehicles details_Of_Vehicles)
        {
            Details_of_vehicles details_Of_Vehicles_dal = new Details_of_vehicles();
            details_Of_Vehicles_dal = details_Of_Vehicles.Convert_vehicles_to__dal();
            DataBaseEntities db = new DataBaseEntities();
            db.Details_of_vehicles.Add(details_Of_Vehicles_dal);
            db.SaveChanges();
        }
        public List<common.Details_of_vehicles> viewVehicles()
        {
            List<common.Details_of_vehicles> details_Of_Vehicles;
            DataBaseEntities db = new DataBaseEntities();
            List<Details_of_vehicles> list = db.Details_of_vehicles.ToList<Details_of_vehicles>();
            details_Of_Vehicles = list.Select<Details_of_vehicles, common.Details_of_vehicles>(v => Mapper.Convert_to_common(v)).ToList<common.Details_of_vehicles>(); ;

            return details_Of_Vehicles;
        }
    }
}

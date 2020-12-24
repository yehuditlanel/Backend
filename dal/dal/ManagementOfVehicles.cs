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
        public static ManagementOfVehicles management_of_vehicles;
        static ManagementOfVehicles()
        {
            management_of_vehicles = new ManagementOfVehicles();
        }

       public void AddVehicle(DetialsOfVehicles detialsOfVehicles)
        {
            DataBaseEntities db = new DataBaseEntities();
            db.Details_of_vehicles.Add(detialsOfVehicles.ConvertVehiclesIoDal());
            db.SaveChanges();
        }
       public List<VehicleType> GetVehicles()
        {
            List<Type_of_vehicles> vehicles;
            using(var DbContext=new DataBaseEntities())
            {
                vehicles = DbContext.Type_of_vehicles.ToList();
            }
            return vehicles.Select(v => Mapper.ConvertVehicleToCommon(v)).ToList();
        }
        public void RemoveVehicle(int id)
        {
            string i = id.ToString();
            using (var db = new DataBaseEntities())
            {
                Details_of_vehicles c = db.Details_of_vehicles.Find(i);
                if (c != null)
                {
                    db.Details_of_vehicles.Remove(c);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateVehicle(DetialsOfVehicles detialsOfVehicles)
        {
            Details_of_vehicles details_Of_Vehicles = Mapper.ConvertVehiclesIoDal(detialsOfVehicles);
            using (var db = new DataBaseEntities())
            {
                db.Entry<Details_of_vehicles>(db.Set<Details_of_vehicles>().Find(details_Of_Vehicles.License_plate)).CurrentValues.SetValues(details_Of_Vehicles);
                db.SaveChanges();
            }
        }
    }
}

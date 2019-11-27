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
       public List<DetialsOfVehicles> GetVehicles()
        {
            List<Details_of_vehicles> details_Of_Vehicles;
            using(var DbContext=new DataBaseEntities())
            {
                details_Of_Vehicles = DbContext.Details_of_vehicles.ToList();
            }
            return details_Of_Vehicles.Select(v => Mapper.ConvertVehicleToCommon(v)).ToList();
        }
        //public void RemoveVehicle(int id)
        //{
        //    string i = id.ToString();
        //    using (var db = new DataBaseEntities())
        //    {
        //        de c = db.Customers.Find(i);
        //        if (c != null)
        //        {
        //            db.Customers.Remove(c);
        //            db.SaveChanges();
        //        }
        //    }
        //}

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

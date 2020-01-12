using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
namespace dal
{
    public class ManagementOfPassenger
    {
        public static ManagementOfPassenger management_of_passenger;
        static ManagementOfPassenger()
        {
            management_of_passenger = new dal.ManagementOfPassenger();
        }

        public List<DetailsOfPassenger> GetPassengers()
        {
            List<Passengers> passengers;
            using (var DbContext = new DataBaseEntities1())
            {
                passengers = DbContext.Passengers.ToList();
            }
            return passengers.Select(p => Mapper.ConvertPassengerToCommon(p)).ToList();
        }
        public void AddPassenger(DetailsOfPassenger detailsOfPassenger)
        {
            DataBaseEntities1 db = new DataBaseEntities1();
            db.Passengers.Add(detailsOfPassenger.ConvertPassengerToDal());
            db.SaveChanges();
        }

        public void UpdatePassenger(DetailsOfPassenger detailsOfPassenger)
        {
            Passengers passengers = Mapper.ConvertPassengerToDal(detailsOfPassenger);
            using (var db = new DataBaseEntities1())
            {
                db.Entry<Passengers>(db.Set<Passengers>().Find(passengers.Passenger_s_code)).CurrentValues.SetValues(passengers);
                db.SaveChanges();
            }
        }
        public void RemovePassenger(string id)
        {
            using (var db = new DataBaseEntities1())
            {
                Passengers p = db.Passengers.Find(id);
                if (p != null)
                {
                    db.Passengers.Remove(p);
                    db.SaveChanges();
                }
            }
        }
    }
}

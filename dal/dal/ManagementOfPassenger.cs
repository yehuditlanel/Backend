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
            using (var DbContext = new DataBaseEntities())
            {
                passengers = DbContext.Passengers.ToList();
            }
            return passengers.Select(p => Mapper.ConvertPassengerToCommon(p)).ToList();
        }
        public List<DetailsOfPassenger> GetPassengers(int trackCode)
        {
            List<int> passengersCode = new List<int>();

            List<Passengers> passengers;
            using (var DbContext = new DataBaseEntities())
            {
                //DbContext.Track_to_travel.FirstOrDefault().Passengers_to_track.ToList();
                passengersCode = DbContext.Passengers_to_track.Where(p => p.Track_s_code == trackCode).Select(p=>p.Passenger_s_code).ToList();
                passengers = DbContext.Passengers.Where(p=>passengersCode.Contains(p.Passenger_s_code)).ToList();
            }
            return passengers.Select(p => Mapper.ConvertPassengerToCommon(p)).ToList();
        }
        public void AddPassenger(DetailsOfPassenger detailsOfPassenger)
        {
            DataBaseEntities db = new DataBaseEntities();
            db.Passengers.Add(detailsOfPassenger.ConvertPassengerToDal());
            db.SaveChanges();
        }

        public void UpdatePassenger(DetailsOfPassenger detailsOfPassenger)
        {
            Passengers passengers = Mapper.ConvertPassengerToDal(detailsOfPassenger);
            using (var db = new DataBaseEntities())
            {
                db.Entry<Passengers>(db.Set<Passengers>().Find(passengers.Passenger_s_code)).CurrentValues.SetValues(passengers);
                db.SaveChanges();
            }
        }
        public void RemovePassenger(string id)
        {
            using (var db = new DataBaseEntities())
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

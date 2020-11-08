using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal;
using common;
namespace bll
{
    public static class ManagmentOfPassenger
    {
        public static List<Station> GetPassengers()
        {
            return ManagementOfPassenger.management_of_passenger.GetPassengers();
        }
        public static List<Station> GetPassengers(int trackCode)
        {
            return ManagementOfPassenger.management_of_passenger.GetPassengers(trackCode);
        }
        public static void AddPassenger(Station detailsOfPassenger)
        {
            ManagementOfPassenger.management_of_passenger.AddPassenger(detailsOfPassenger);
        }
        public static void UpdatePassenger(Station detailsOfPassenger)
        {
            ManagementOfPassenger.management_of_passenger.UpdatePassenger(detailsOfPassenger);
        }
        public static void RemovePassenger(string id)
        {
            ManagementOfPassenger.management_of_passenger.RemovePassenger(id);
        }
    }
}

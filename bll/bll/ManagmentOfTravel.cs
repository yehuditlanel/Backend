using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
using dal;
namespace bll
{
    public class ManagmentOfTravel
    {
        public static List<DetailsOfTravel> GetTravels()
        {
            return ManagementOfTravel.management_of_travel.GetTravels();
        }
        public static List<DetailsOfTravel> GetTravels(int groupCode)
        {
            return ManagementOfTravel.management_of_travel.GetTravels(groupCode);
        }
       
        public static void AddTravel(DetailsOfTravel detailsOfTravel)
        {
            ManagementOfTravel.management_of_travel.AddTravel(detailsOfTravel);
        }
        public static void UpdateTravel(DetailsOfTravel detailsOfTravel)
        {
            ManagementOfTravel.management_of_travel.UpdateTravel(detailsOfTravel);
        }
        public static void RemoveTravel(string id)
        {
            ManagementOfTravel.management_of_travel.RemoveTravel(id);
        }
    }

}

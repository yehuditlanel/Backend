using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
using dal;
using IronXL;
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
        public static void AddTravel(DetailsOfTravel detailsOfTravel, Stream fileStream)
        {
            WorkBook workbook = WorkBook.Load(fileStream);
            WorkSheet sheet = workbook.WorkSheets.First();
            int row = sheet.RowCount;
            List<common.DetailsOfPassenger> names = new List<common.DetailsOfPassenger>();
            for (int j = 2; j <= row; j++)
            {
                string name = sheet['A' + j.ToString()].StringValue;
                string address = sheet['B' + j.ToString()].StringValue;
                names.Add(new common.DetailsOfPassenger(j, name, address));
            }
            names.ForEach(i => Console.WriteLine(i.PassengerName + " " + i.PassengerAddress));

            ManagementOfTravel.management_of_travel.AddTravel(detailsOfTravel,names);
        }
    //public static void AddTravel(DetailsOfTravel detailsOfTravel)
    //{
    //    ManagementOfTravel.management_of_travel.AddTravel(detailsOfTravel);
    //}
    public static void UpdateTravel(DetailsOfTravel detailsOfTravel)
        {
            ManagementOfTravel.management_of_travel.UpdateTravel(detailsOfTravel);
        }
        public static void RemoveTravel(int id)
        {
            ManagementOfTravel.management_of_travel.RemoveTravel(id);
        }
    }

}

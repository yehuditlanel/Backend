using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
namespace dal
{
    public class ManagementOfTravel
    {
        public static ManagementOfTravel management_of_travel;
        static ManagementOfTravel()
        {
            management_of_travel = new dal.ManagementOfTravel();
        }
        public List<DetailsOfTravel> GetTravels()
        {
            List<Travels> travels;
            using (var DbContext = new DataBaseEntities())
            {
                travels = DbContext.Travels.ToList();
            }
            return travels.Select(t => Mapper.ConvertTravelToCommon(t)).ToList();
        }
        public void AddTravel(DetailsOfTravel detailsOfTravel)
        {
            DataBaseEntities db = new DataBaseEntities();
            db.Travels.Add(detailsOfTravel.ConvertTravelToDal());
            db.SaveChanges();
        }
        public void UpdateTravel(DetailsOfTravel detailsOfTravel)
        {
            Travels travels = Mapper.ConvertTravelToDal(detailsOfTravel);
            using (var db = new DataBaseEntities())
            {
                db.Entry<Travels>(db.Set<Travels>().Find(travels.Travel_s_code)).CurrentValues.SetValues(travels);
                db.SaveChanges();
            }

        }
        public void RemoveTravel(string id)
        {
            using (var db = new DataBaseEntities())
            {
                Travels t = db.Travels.Find(id);
                if (t != null)
                {
                    db.Travels.Remove(t);
                    db.SaveChanges();
                }
            }
        }
    }
}

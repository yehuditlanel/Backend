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
        public List<DetailsOfTravel> GetTravels(int groupCode)
        {
            List<Travels> travels;
            using (var DbContext = new DataBaseEntities())
            {
                travels = DbContext.Travels.Where(t=>t.Group_s_code==groupCode).ToList();
            }
            return travels.Select(t => Mapper.ConvertTravelToCommon(t)).ToList();
        }
        public void AddTravel(DetailsOfTravel detailsOfTravel, List<common.DetailsOfPassenger> names)
        {
            DetailsOfTrack track;
            Travels resTravel;
            Track_to_travel detailOfTrack;
            Passengers_to_track passengers_To_Track;
            DataBaseEntities db = new DataBaseEntities();
            //common.DetailsOfTravel detailsOfTravel;
            //detailsOfTravel = detailsOfAddTravel.MyProperty;
            resTravel=db.Travels.Add(detailsOfTravel.ConvertTravelToDal());
           
            
            db.SaveChanges();
            var travelCode = resTravel.Travel_s_code;
            track = new DetailsOfTrack(0, travelCode, 1111, "1111", detailsOfTravel.DateOfBegin, detailsOfTravel.Hour);
            detailOfTrack=db.Track_to_travel.Add(track.ConvertTrackToDal());
            db.SaveChanges();
            var trackCode = detailOfTrack.Track_s_code;
            for (int i = 0; i < names.Count; i++)
            {
                db.Passengers.Add(names[i].ConvertPassengerToDal());
                passengers_To_Track = new Passengers_to_track();
                //passengers_To_Track.Id = 4 + i;
                passengers_To_Track.Passenger_s_code = names[i].PassengerCode;
                passengers_To_Track.Track_s_code = trackCode;
                db.Passengers_to_track.Add(passengers_To_Track);
            }
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
        public void RemoveTravel(int id)
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

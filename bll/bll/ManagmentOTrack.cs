using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal;
using common;
namespace bll
{
    public static class ManagmentOTrack
    {
        public static List<DetailsOfTrack> GetTracks()
        {
            return ManagementOfTrack.management_of_track.GetTracks();
        }
        public static List<DetailsOfTrack>GetTracks(int travelCode)
        {
            return ManagementOfTrack.management_of_track.GetTracks(travelCode);
        }
        public static DetailsOfTravel GetTrackByDriverId(int userId)
        {
            return ManagementOfTrack.management_of_track.GetTrackByDriverId(userId);
        }
        public static void AddTrack(DetailsOfTrack detailsOfTrack)
        {
            ManagementOfTrack.management_of_track.AddTrack(detailsOfTrack);
        }
        public static void UpdateTrack(DetailsOfTrack detailsOfTrack)
        {
            ManagementOfTrack.management_of_track.UpdateTrack(detailsOfTrack);
        }
        public static void RemoveTrack(string id)
        {
            ManagementOfTrack.management_of_track.RemoveTrack(id);
        }
        
    }
}

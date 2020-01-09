using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{

    public class DetailsOfTrack
    {
        public DetailsOfTrack(int trackCode,int travelCode,int driverId,string licensePlate,DateTime dateOfTravel,TimeSpan hourOfBegin)
        {
            this.trackCode = trackCode;
            this.travelCode = travelCode;
            this.driverId = driverId;
            this.licensePlate = licensePlate;
            this.dateOfTravel = dateOfTravel;
            this.hourOfBegin = hourOfBegin;
        }
        private int trackCode;

        public int TrackCode
        {
            get { return trackCode; }
            set { trackCode = value; }
        }
        private int travelCode;

        public int TravelCode
        {
            get { return travelCode; }
            set { travelCode = value; }
        }
        private int driverId;

        public int DriverId
        {
            get { return driverId; }
            set { driverId = value; }
        }
        private string licensePlate;

        public string LicensePlate
        {
            get { return licensePlate; }
            set { licensePlate = value; }
        }
        private DateTime dateOfTravel;

        public DateTime DateOfTravel
        {
            get { return dateOfTravel; }
            set { dateOfTravel = value; }
        }
        private TimeSpan hourOfBegin;

        public TimeSpan HourOfBegin
        {
            get { return hourOfBegin; }
            set { hourOfBegin = value; }
        }
    }
}

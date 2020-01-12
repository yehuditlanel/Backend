using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public class DetailsOfPassenger
    {
        public DetailsOfPassenger(int passengerCode,string passengerName,string passengerAddress)
        {
            this.passengerCode = passengerCode;
            this.passengerName = passengerName;
            this.passengerAddress = passengerAddress;
        }
        private int passengerCode;

        public int PassengerCode
        {
            get { return passengerCode; }
            set { passengerCode = value; }
        }
        private string passengerName;

        public string PassengerName
        {
            get { return passengerName; }
            set { passengerName = value; }
        }
        private string passengerAddress;

        public string PassengerAddress
        {
            get { return passengerAddress; }
            set { passengerAddress = value; }
        }
        
    }
}

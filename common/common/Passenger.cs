using Geocoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public class Station
    {
        public Station(string id,string name, string address)
        {
            PassengerId = id;
            Address = address;
            Name = name;
            IsDestination = false;
            IsSource = false;

        }

        public Station(string id,string name, string address, double latitude, double longitude) : this(id,name, address)
        {
            Longitude = longitude;
            Latitude = latitude;

        }

        public string PassengerId { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public Address GoogleAddress { get; set; }

        public string FormattedAddress { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public bool IsDestination { get; set; }

        public bool IsSource { get; set; }

        public bool IsUsed { get; set; }

        public override string ToString()
        {
            return $"{this.PassengerId},{this.Longitude.ToString()},{this.Latitude.ToString()},{this.Address},{this.FormattedAddress}";
        }

        public Station Clone()
        {
            return new Station(PassengerId,Name, Address, Latitude, Longitude)
            {
                FormattedAddress = FormattedAddress,
                Address = Address,
                IsDestination = IsDestination,
                IsSource = IsSource
            };
        }

    }
}

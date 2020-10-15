using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public class DetialsOfVehicles
    {
        public DetialsOfVehicles(string license_plate, int several_places, double quantity_of_fuel_per_km, string type)
        {
            this.license_plate = license_plate;
            this.several_places = several_places;
            this.quantity_of_fuel_per_km = quantity_of_fuel_per_km;
            this.type = type;
        }

        private string license_plate;

        public string License_plate
        {
            get { return license_plate; }
            set { license_plate = value; }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private int several_places;

        public int Several_places
        {
            get { return several_places; }
            set { several_places = value; }
        }

        private double quantity_of_fuel_per_km;

        public double Quantity_of_fuel_per_km
        {
            get { return quantity_of_fuel_per_km; }
            set { quantity_of_fuel_per_km = value; }
        }
    }
}

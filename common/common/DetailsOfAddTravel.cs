using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public class DetailsOfAddTravel
    {
        private DetailsOfTravel detailsOfTravel;
        DetailsOfPassenger[] passenger;
        public DetailsOfAddTravel(DetailsOfTravel detailsOfTravel,DetailsOfPassenger[] passenger)
        {
            this.detailsOfTravel = detailsOfTravel;
            this.passenger = passenger;
        }

        //private DetailsOfTravel myVar;

        public DetailsOfTravel MyProperty
        {
            get { return detailsOfTravel; }
            set { detailsOfTravel = value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public class DetailsOfAddTravel
    {
        DetailsOfTravel detailsOfTravel;
        DetailsOfPassenger[] passenger;
        public DetailsOfAddTravel(DetailsOfTravel detailsOfTravel,DetailsOfPassenger[] passenger)
        {
            this.detailsOfTravel = detailsOfTravel;
            this.passenger = passenger;
        }
    }
}

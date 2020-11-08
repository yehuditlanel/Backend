using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public class Transportation
    {
        public Transportation()
        {
            Stations = new List<Station>();
        }


        public string TypeDesc { get; set; }

        public List<Station> Stations { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public class Distance
    {
        public Distance()
        {
            IsUsed = false;
        }

        public Station Station1 { get; set; }

        public Station Station2 { get; set; }

        public double distance { get; set; }

        public int index { get; set; }

        public bool IsUsed { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public class VehicleType
    {
        public VehicleType(int code,int count,string description)
        {
            this.Code = code;
            this.Count = count;
            this.Description = description;
        }
        public int Count { get; set; }

        public int Code { get; set; }

        public string Description { get; set; }
    }
}

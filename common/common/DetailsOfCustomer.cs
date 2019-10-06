using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public class DetailsOfCustomer
    {
        private string group_s_code;

        public string Group_s_code
        {
            get { return group_s_code; }
            set { group_s_code = value; }
        }
    private string conected_name;

    public string Conected_name
    {
        get { return conected_name; }
        set { conected_name = value; }
    }

    private string conected_phone;

    public string Conected_phone
    {
        get { return conected_phone; }
        set { conected_phone = value; }
    }

    private string group_s_name;

    public string Group_s_name
    {
        get { return group_s_name; }
        set { group_s_name = value; }
    }
    public DetailsOfCustomer(string conected_name, string conected_phone,string group_s_code, string group_s_name)
        
    {
            this.conected_name = conected_name;
            this.conected_phone = conected_phone;
            this.group_s_code = group_s_code;
            this.group_s_name = group_s_name;
    }
    }
}

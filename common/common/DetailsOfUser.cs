using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public enum Permition { Admin,Secretary,Driver };
    public class DetailsOfUser
    {
        private int user_s_Id;
        private string name_of_user;
        private string address_of_user;
        private string phone_of_user;
        private int? permition1;
       
        public DetailsOfUser(int userId,string nameOfUser,string addressOfUser,string phoneOfUser,Permition permition/*,string password*/)
        {
            this.userId = userId;
            this.nameOfUser = nameOfUser;
            this.addressOfUser = addressOfUser;
            this.phoneOfUser = phoneOfUser;
            this.permition = permition;
          //  this.password = password;
        }

        public DetailsOfUser(int user_s_Id, string name_of_user, string address_of_user, string phone_of_user, int? permition1)
        {
            this.user_s_Id = user_s_Id;
            this.name_of_user = name_of_user;
            this.address_of_user = address_of_user;
            this.phone_of_user = phone_of_user;
            this.permition1 = permition1;
        }

        public int userId { get; set; }
        public string nameOfUser { get; set; }
        public string addressOfUser { get; set; }
        public string phoneOfUser { get; set; }
        public Permition permition { get; set; }
        public string password { get; set; }
    }
}
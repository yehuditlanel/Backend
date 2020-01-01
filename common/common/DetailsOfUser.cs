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
        //private int user_s_Id;
        //private string name_of_user;
        //private string address_of_user;
        //private string phone_of_user;
        //private int? permition1;

        //public DetailsOfUser(int userId,string nameOfUser,string addressOfUser,string phoneOfUser,Permition permition)
        //{
        //    this.UserId = userId;
        //    this.NameOfUser = nameOfUser;
        //    this.AddressOfUser = addressOfUser;
        //    this.PhoneOfUser = phoneOfUser;
        //    this.Permition = permition;

        //}

        //public DetailsOfUser(int user_s_Id, string name_of_user, string address_of_user, string phone_of_user, int? permition1)
        //{
        //    this.user_s_Id = user_s_Id;
        //    this.name_of_user = name_of_user;
        //    this.address_of_user = address_of_user;
        //    this.phone_of_user = phone_of_user;
        //    this.permition1 = permition1;
        //}

        //public int UserId { get; set; }
        //public string NameOfUser { get; set; }
        //public string AddressOfUser { get; set; }
        //public string PhoneOfUser { get; set; }
        //public Permition Permition { get; set; }
        //public string Password { get; set; }
        //private int user_s_Id;
        //private string name_of_user;
        //private string address_of_user;
        //private string phone_of_user;
        //private int? permition;
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private string nameOfUser;

        public string NameOfUser
        {
            get { return nameOfUser; }
            set { nameOfUser = value; }
        }
        private string addressOfUser;

        public string AddressOfUser
        {
            get { return addressOfUser; }
            set { addressOfUser = value; }
        }
        private string phoneOfUser;

        public string PhoneOfUser
        {
            get { return phoneOfUser; }
            set { phoneOfUser = value; }
        }
        private Permition permition;

        public Permition Permition
        {
            get { return permition; }
            set { permition = value; }
        }

        public DetailsOfUser(int userId, string nameOfUser, string addressOfUser, string phoneOfUser, Permition permition)
        {
            this.userId = userId;
            this.nameOfUser = nameOfUser;
            this.addressOfUser = addressOfUser;
            this.phoneOfUser = phoneOfUser;
            this.permition = permition;
        }
    }
}
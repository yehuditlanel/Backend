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
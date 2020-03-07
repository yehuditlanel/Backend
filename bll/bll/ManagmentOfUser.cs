using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
using dal;
namespace bll
{
    public class ManagmentOfUser
    {
        public static List<DetailsOfUser> GetUsers()
        {
            return ManagementOfUser.management_of_user.GetUsers();
        }
        public static DetailsOfUser GetUsers(int id,string nameOfUser)
        {
            return ManagementOfUser.management_of_user.GetUsers(id,nameOfUser);
        }
        public static void addUser(DetailsOfUser detailsOfUser)
        {
            ManagementOfUser.management_of_user.AddUser(detailsOfUser);
        }
        public static void RemoveUser(int id)
        {
            ManagementOfUser.management_of_user.RemoveUser(id);
        }
        public static void UpdateUser(DetailsOfUser detailsOfUser)
        {
            ManagementOfUser.management_of_user.UpdateUser(detailsOfUser);
        }
    }
}

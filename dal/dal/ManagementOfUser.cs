using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
using System.Data;
using System.Data.Entity;
namespace dal
{
    public class ManagementOfUser
    {
        public static ManagementOfUser management_of_user;
        static ManagementOfUser()
        {
            management_of_user = new dal.ManagementOfUser();
        }
        public List<DetailsOfUser> listOfUser()
        {
            List<Users> listDetailsOfUser;
            DataBaseEntities db = new DataBaseEntities();
            listDetailsOfUser = db.Users.ToList<Users>();
            List<DetailsOfUser> listUser = listDetailsOfUser.Select<Users, DetailsOfUser>(m => Mapper.ConvertUserToCommon(m)).ToList<DetailsOfUser>();
            return listUser;
        }
    }
}

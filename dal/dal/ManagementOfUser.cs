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
        public void AddUser(DetailsOfUser detailsOfUser)
        {
            DataBaseEntities db = new DataBaseEntities();
            db.Users.Add(detailsOfUser.ConvertUserToDal());
            db.SaveChanges();
        }
        public List<DetailsOfUser> GetUsers()
        {
            List<Users> users;
            using (var DbContext = new DataBaseEntities())
            {
                users = DbContext.Users.Where(u=>u.Permition==dal.Permition.Driver).ToList();
            }
            return users.Select(u => Mapper.ConvertUserToCommon(u)).ToList();
        }
        public DetailsOfUser GetUsers(int id,string nameOfUser)
        {
            Users user;
            using(var DbContext=new DataBaseEntities())
            {
                user = DbContext.Users.Where(u => u.User_s_Id == id&&u.Name_of_user==nameOfUser).FirstOrDefault();
            }
            if (user == null) return null;
            return Mapper.ConvertUserToCommon(user);
        }
        public void RemoveUser(int id)
        {
            using (var db = new DataBaseEntities())
            {
                Users users = db.Users.Find(id);
                if (users != null)
                {
                    db.Users.Remove(users);
                    db.SaveChanges();
                }
            }
        }
        public void UpdateUser(DetailsOfUser detailsOfUser)
        {
            Users users = Mapper.ConvertUserToDal(detailsOfUser);
            using (var db = new DataBaseEntities())
            {
                db.Entry<Users>(db.Set<Users>().Find(users.User_s_Id)).CurrentValues.SetValues(users);
                db.SaveChanges();
            }
        }
    }
}

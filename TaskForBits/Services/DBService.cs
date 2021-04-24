using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TaskForBits.Models;
namespace TaskForBits.Services
{
    public class DBService
    {


        public void SetUserIntoDB(User user)
        {
            using (UserContext db = new UserContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
        public List<User> GetUsers(string strConn)
        {
            List<User> users = new List<User>();

            using (UserContext db = new UserContext())
            {
                return (from c in db.Users select c).ToList();
            }
        }
        public void DeleteUser(int UserID)
        {
            using (UserContext db = new UserContext())
            {
                db.Users.Remove((from c in db.Users where c.UserID == UserID select c).FirstOrDefault());
                db.SaveChanges();
            }
        }
    }
}
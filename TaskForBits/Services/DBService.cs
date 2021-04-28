using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TaskForBits.Models;
using TaskForBits.Context;
namespace TaskForBits.Services
{
    public class DBService
    {
        private readonly UserContext db = new UserContext();
        public void SetUserIntoDB(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public List<User> GetUsers()
        {
            return (from c in db.Users select c).ToList();
        }
        public void DeleteUser(int UserID)
        {
            db.Users.Remove((from c in db.Users where c.UserID == UserID select c).FirstOrDefault());
            db.SaveChanges();
        }
        public void EditUserInDB(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
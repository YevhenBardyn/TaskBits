using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using TaskForBits.Models;
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
                User curUser = new User();
                if ((from c in db.Users where c.UserID == user.UserID select c).FirstOrDefault() != null)
                {
                    curUser = (from c in db.Users where c.UserID == user.UserID select c).FirstOrDefault();
                    curUser.DateOfBirth = user.DateOfBirth;
                    curUser.Name = user.Name;
                    curUser.Phone = user.Phone;
                    curUser.Married = user.Married;
                    curUser.Salary = user.Salary;
                    db.Entry(curUser).State = EntityState.Modified;
                    db.SaveChanges();
            }
        }
        public void GetUsersFromCsvToDB(HttpPostedFileBase upload)
        {
            using (var reader = new StreamReader(upload.InputStream))
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                foreach (BaseUser baseUser in csvReader.GetRecords<BaseUser>().ToList())
                {
                    SetUserIntoDB(new User(baseUser));
                }
            }
        }
    }
}
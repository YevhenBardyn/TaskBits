﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public List<User> GetUsers()
        {
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
        public void EditUserInDB(User user)
        {
            using (UserContext db = new UserContext())
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
        }
    }
}
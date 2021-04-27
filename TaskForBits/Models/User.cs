using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace TaskForBits.Models
{
    public class User : BaseUser
    {
        public int UserID { get; set; }
        public User()
        {
        }
        public User(string name, DateTime dateOfBirth, bool married, string phone, decimal salary)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Married = married;
            Phone = phone;
            Salary = salary;
        }
        public User(BaseUser baseUser)
        {
            Name = baseUser.Name;
            DateOfBirth = baseUser.DateOfBirth;
            Phone = baseUser.Phone;
            Salary = baseUser.Salary;
        }
        public object this[string PropertyName]
        {
            get
            {
                Type myType = typeof(User);
                PropertyInfo pi = myType.GetProperty(PropertyName);
                return pi.GetValue(this, null);
            }
        }
    }
}
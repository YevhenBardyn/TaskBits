using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskForBits.Models
{
    public class User
    {
        public User(int userID, string name, DateTime dateOfBirth, bool married, string phone, decimal salary)
        {
            UserID = userID;
            Name = name;
            DateOfBirth = dateOfBirth;
            Married = married;
            Phone = phone;
            Salary = salary;
        }
        public User(string[] values)
        {
            UserID = 0;
            Name = values[0];
            DateOfBirth = Convert.ToDateTime(values[1]);
            Married = Convert.ToBoolean(Convert.ToInt32(values[2]));
            Phone = values[3];
            Salary = Convert.ToDecimal(values[4]);
        }

        public int UserID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; }
        public Decimal Salary { get; set; }
   

    }
}
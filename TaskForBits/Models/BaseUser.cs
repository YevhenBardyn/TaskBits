using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskForBits.Models
{
    public class BaseUser
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }

    }
}
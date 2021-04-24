using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskForBits.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base("MainContext")
        { }

        public DbSet<User> Users { get; set; }
    }
}
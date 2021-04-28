using System.Data.Entity;
using TaskForBits.Models;

namespace TaskForBits.Context
{
    public class UserContext : DbContext
    {
        public UserContext() : base("MainContext")
        { }
        public DbSet<User> Users { get; set; }
    }
}
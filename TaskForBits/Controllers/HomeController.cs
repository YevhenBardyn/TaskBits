using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskForBits.Services;
using TaskForBits.Models;
namespace TaskForBits.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string connectionString = @"Data Source=DESKTOP-R7LP984;Initial Catalog=BitsDB;Integrated Security=True";
            DBService dBService = new DBService();
            List<User> users = dBService.GetUsers(connectionString);
            ViewBag.Users = users;
            return View();
        }
        public RedirectResult ImportFromCSVToDB()
        {
            string connectionString = @"Data Source=DESKTOP-R7LP984;Initial Catalog=BitsDB;Integrated Security=True";
            CSVService cSVService = new CSVService();
            DBService dBService = new DBService();
            foreach (var item in cSVService.GetUsersFromCsv(Server.MapPath("..\\data.csv")))
            {
                dBService.SetUserIntoDB(item, connectionString);
            }
            return Redirect("/Home");
        }
        public RedirectResult DeleteUser(int UserID)
        {
            DBService dBService = new DBService();
            dBService.DeleteUser(UserID);
            return Redirect("/Home");
        }
        [HttpGet]
        public ActionResult EditUser(int UserID)
        {
            string connectionString = @"Data Source=DESKTOP-R7LP984;Initial Catalog=BitsDB;Integrated Security=True";
            DBService dBService = new DBService();
            List<User> users = dBService.GetUsers(connectionString);
            ViewBag.User = users.Find(User => User.UserID == UserID);
            return View();
        }
        [HttpPost]
        public RedirectResult EditUser(User user)
        {



            return Redirect("/Home");
        }
    }
}
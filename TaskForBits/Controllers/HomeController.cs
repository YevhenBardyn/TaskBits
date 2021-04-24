using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskForBits.Services;
using TaskForBits.Models;
using System.Configuration;
using System.Web.Mvc.Ajax;

namespace TaskForBits.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DBService dBService = new DBService();
            List<User> users = dBService.GetUsers();
            return View(users);
        }

        [HttpPost]
        public ActionResult Index(string filterColumn)
        {
            DBService dBService = new DBService();
            IEnumerable<User> users = dBService.GetUsers();
            return PartialView(users.OrderBy(prop => prop[filterColumn]));
        }
        public RedirectResult ImportFromCSVToDB()
        {
            CSVService cSVService = new CSVService();
            DBService dBService = new DBService();
            foreach (var item in cSVService.GetUsersFromCsv(Server.MapPath("..\\data.csv")))
            {
                dBService.SetUserIntoDB(item);
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
            DBService dBService = new DBService();
            List<User> users = dBService.GetUsers();
            return View(users.Find(User => User.UserID == UserID));
        }
        [HttpPost]
        public RedirectResult EditUser(User user)
        {
            DBService dBService = new DBService();
            dBService.EditUserInDB(user);
            return Redirect("/Home");
        }
    }
}
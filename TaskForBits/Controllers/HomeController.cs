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
        DBService dBService = new DBService();
        public ActionResult Index()
        {
            List<User> users = dBService.GetUsers();
            return View(users);
        }

        [HttpPost]
        public ActionResult Index(string filterColumn)
        {
            IEnumerable<User> users = dBService.GetUsers();
            return PartialView(users.OrderBy(prop => prop[filterColumn]));
        }
        public RedirectResult ImportFromCSVToDB()
        {
            CSVService cSVService = new CSVService();
            foreach (var item in cSVService.GetUsersFromCsv(Server.MapPath("..\\data.csv")))
            {
                dBService.SetUserIntoDB(item);
            }
            return Redirect("/Home");
        }
        public RedirectResult DeleteUser(int UserID)
        {
            dBService.DeleteUser(UserID);
            return Redirect("/Home");
        }
        [HttpGet]
        public ActionResult EditUser(int UserID)
        {
            List<User> users = dBService.GetUsers();
            return View(users.Find(User => User.UserID == UserID));
        }
        [HttpPost]
        public RedirectResult EditUser(User user)
        {
            dBService.EditUserInDB(user);
            return Redirect("/Home");
        }
    }
}
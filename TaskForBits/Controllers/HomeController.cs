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
            string connectionString = ConfigurationManager.ConnectionStrings["MainContext"].ConnectionString;
            DBService dBService = new DBService();
            List<User> users = dBService.GetUsers(connectionString);
            return View(users);
        }
        public PartialViewResult FilterUser(string filterColumn)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MainContext"].ConnectionString;
            DBService dBService = new DBService();
            IEnumerable<User> users = dBService.GetUsers(connectionString);
            ViewBag.Users = users.OrderBy(User=>User.Name);
            return PartialView("FilterUser.cshtml", users.OrderBy(User => User.Name));
        }
        public RedirectResult ImportFromCSVToDB()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MainContext"].ConnectionString;
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
            string connectionString = ConfigurationManager.ConnectionStrings["MainContext"].ConnectionString;
            DBService dBService = new DBService();
            List<User> users = dBService.GetUsers(connectionString);
            return View(users.Find(User => User.UserID == UserID));
        }
        [HttpPost]
        public RedirectResult EditUser(User user)
        {
            User user1 = user;


            return Redirect("/Home");
        }
        //public JsonResult FilterUser(string filterColumn)
        //{

        //    return Json(string.Empty, JsonRequestBehavior.AllowGet);
        //}
    }
}
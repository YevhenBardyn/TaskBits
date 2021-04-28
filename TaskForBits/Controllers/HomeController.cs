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
        readonly DBService dBService = new DBService();
        public ActionResult Index()
        {
            return View(dBService.GetUsers().ToList<User>());
        }

        [HttpPost]
        public ActionResult Index(string filterColumn)
        {
            IEnumerable<User> users = dBService.GetUsers();
            return PartialView("FilterUser", users.OrderBy(prop => prop[filterColumn]));
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            try
            {
                if (upload != null)
                {
                    dBService.GetUsersFromCsvToDB(upload);
                }
                return Redirect("/Home");
            }
            catch (Exception) 
            {
                return View("Error");
            }
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
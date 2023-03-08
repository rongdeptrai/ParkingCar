using MyParking.Common;
using MyParking.Model;
using ParkingCore.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyParking.Controllers
{
    public class HomeController : BaseController
    {
       

        public ActionResult Index()
        {
            var dao = new EmployeeDao();
            var session = (LoginModel)Session[Constants.USER_SESSION];
            if (session == null) return RedirectToAction("Index", "Login");
            int result = dao.checkTypeEmp(session.UserName);
            if (result == 0)
            {
                return RedirectToAction("Dashboard", "Site");
            }
            return View();
        }

        public ActionResult Logout()
        {
            var dao = new EmployeeDao();
            var session = (LoginModel)Session[Constants.USER_SESSION];
            if (session == null) return RedirectToAction("Index", "Login");
                Session[Constants.USER_SESSION] = null;
                return RedirectToAction("Index", "Login");

        }
    }
}
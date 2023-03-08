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
    public class LoginController : Controller
    {
        // GET: Login
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel user)
        {
            if (ModelState.IsValid)
            {

                var dao = new EmployeeDao();
                int result = dao.login(user.UserName, Encryptor.EncryptMD5(user.PassWord));
                if (result == 1)
                {
                    int check = dao.checkTypeEmp(user.UserName);
                    var pkID= dao.getPkID(user.UserName);
                    user.PkID = pkID;
                    if (check == 0)
                    {
                        Session.Add(Constants.USER_SESSION, user);
                        return RedirectToAction("Dashboard", "Site");
                    }
                    else if(check == 1)
                    {
                        Session.Add(Constants.USER_SESSION, user);
                        return RedirectToAction("Index", "ParkingSite");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Bạn không có quyền quản trị");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Đăng Nhập Không Thành Công");
                }

            }
            return View("Index");

        }
    }
}
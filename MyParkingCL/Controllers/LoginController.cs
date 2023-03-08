using MyParkingCL.Common;
using MyParkingCL.Model;
using ParkingCore.DAO;
using ParkingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyParkingCL.Controllers
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

                var dao = new CustomerDao();
                int result = dao.login(user.Phone, Encryptor.EncryptMD5(user.PassWord));
                var cus = dao.FinByPhone(user.Phone);
                user.Name = cus.CusName;
                user.Address = cus.Address;
                user.Email=cus.Email;
                if (result == 1)
                {
                    Session.Add(Constants.USER_SESSION, user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng Nhập Không Thành Công");
                }

            }
            return View("Index");

        }
        public ActionResult SignUp() 
        {
            return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var cus = new Customer();
                cus.CusID = "KSS001";
                cus.Email = user.Email; 
                cus.Address = user.Address;
                cus.CusName = user.Name;
                cus.Phone = user.Phone;
                cus.Pass = Encryptor.EncryptMD5(user.PassWord);
                var dao = new CustomerDao();
                int result = dao.SigUp(cus);
                if (result == 1)
                {
                    Session.Add(Constants.USER_SESSION, user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng Ký Không Thành Công");
                }

            }
            return View("Index");

        }
    }
}
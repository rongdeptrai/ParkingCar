using ParkingCore.DAO;
using ParkingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyParkingCL.Controllers
{
    public class CustomerController : BaseController
    {
        private CustomerDao db = new CustomerDao();
        private MyParkingDbContext context = new MyParkingDbContext();
        [HttpGet]
        public ActionResult Details(string phone)
        {
            if (phone == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer cus = db.FinByPhone(phone);

            if (cus == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarDetail = context.Cars.Where(x => x.CusID == cus.CusID).ToList();
            return View(cus);
        }
    }
}
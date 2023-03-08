using MyParkingCL.Common;
using MyParkingCL.Model;
using ParkingCore.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyParkingCL.Controllers
{
    public class HomeController : BaseController
    {
        public ParkingDao pkDao = new ParkingDao();
        public ParkingSlotDao pkslDao = new ParkingSlotDao();
        public BookingDao bkDao = new BookingDao();
        public ActionResult Index()
        {

            var pk = new ParkingDao();
            var model = pk.ListAll();
            return View(model);
        }
        public ActionResult Parking(string pkID)
        {
            var model = pkslDao.ListByID(pkID);
            setViewBage(pkID);
            return View(model);
        }
        public void setViewBage(string pkID)
        {
            var session = (LoginModel)Session[Constants.USER_SESSION];
            if (session == null) 
                RedirectToAction("Index", "Login");
            ViewBag.session=session;
            var booking = bkDao.FinByPkID(pkID);
            var floor = pkslDao.ListFloor(pkID);
            ViewBag.Bookings = booking;
            ViewBag.Floor = floor;
            ViewBag.PkID = pkID;
        }

    }
}
using MyParking.Common;
using MyParking.Model;
using ParkingCore.DAO;
using ParkingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyParking.Controllers
{
    public class ParkingSiteController : BaseController
    {
        public  ParkingDao pkDao= new ParkingDao();
        public  ParkingSlotDao pkslDao = new ParkingSlotDao();
        public  BookingDao bkDao = new BookingDao();
        // GET: ParkingSite
        public ActionResult Index()
        {
            var session = (LoginModel)Session[Constants.USER_SESSION];
            if (session == null) return RedirectToAction("Index", "Login");
            var model= pkslDao.ListByID(session.PkID);
            setViewBage(session);
            return View(model); 
        }

        // GET: ParkingSite/Details/5
        public ActionResult Details()
        {
            var session = (LoginModel)Session[Constants.USER_SESSION];
            if (session == null) return RedirectToAction("Index", "Login");
            var pkid = session.PkID;
            var pk= pkDao.FindByID(pkid);
            return View(pk);
        }

        // POST: ParkingSite/Edit/5
        [HttpPost]
        public ActionResult Update( FormCollection collection)
        {
            Parking pk = new Parking();
            pk = pkDao.FindByID(collection["PkID"]);
            pk.PkName = collection["PkName"];
            pk.PkAddress = collection["Address"];
            pk.Phone = collection["Phone"];
            pk.Email = collection["Email"];
            pk.Slot = int.Parse(collection["Slot"]);
            try
            {
                var rs= pkDao.Update(pk);
                if(rs ==true)
                {

                    SetAlert("Cập nhật thành công.", "success");
                }
                return RedirectToAction("Details", "ParkingSite");
            }
            catch
            {
                SetAlert("Cập nhật không thành công.", "error");
                return RedirectToAction("Details", "ParkingSite");
            }
        }
        [HttpPost]
        public ActionResult AddSlot(FormCollection collection)
        {
            var pksl = new ParkingSlot();
            pksl.PkSlotID = "ddd";
            pksl.PkID = collection["PkID"];
            pksl.SlotNo = collection["SlotNo"];
            pksl.Status = false;
            pksl.PkTID = "PKT001";
            pksl.Floor = 1;
            try
            {
                var rs = pkslDao.AddSlot(pksl);
                if (rs == true)
                {

                    SetAlert("Cập nhật thành công.", "success");
                }
                return RedirectToAction("Details", "ParkingSite");
            }
            catch
            {
                SetAlert("Cập nhật không thành công.", "error");
                return RedirectToAction("Details", "ParkingSite");
            }
        }
        public ActionResult Tk()
        {
            return View();
        }
        public void setViewBage(LoginModel session)
        {
            var booking = bkDao.FinByPkID(session.PkID);
            var floor = pkslDao.ListFloor(session.PkID);
            ViewBag.Bookings = booking;
            ViewBag.Floor = floor;
            ViewBag.PkID = session.PkID;
        }
     }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ParkingCore.Models;
using ParkingCore.DAO;

namespace MyParking.Controllers
{
    public class BookingsController : BaseController
    {
        private MyParkingDbContext db = new MyParkingDbContext();

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BookingID,CusID,CusName,Phone,CarNo,SlotNo,DateIn,ExpOut,Status,ExpTotalPrice,PaymentStatus,PkID,PkSlotID")] FormCollection filed)
        {
            Booking bk = new Booking();
            var cusDb = new CustomerDao();
            var customer= new Customer();
            bk.BookingID = "bk01";
            bk.Phone = filed["Phone"];
            bk.CusName = filed["CusName"];
            bk.CarNo = filed["CarNo"];
            bk.CarNo = filed["CarNo"];
            bk.SlotNo = filed["SlotNo"];
            bk.Status = true;
            bk.DateIn = DateTime.Now;
            bk.ExpOut = DateTime.Parse(filed["ExpOut"]);
            bk.PkSlotID = filed["PkSlotID"];
            bk.PkID = filed["PkID"];
            bk.PaymentStatus = true;
            bk.ExpTotalPrice = 1;
            customer = cusDb.FinByPhone(bk.Phone);
            if(customer == null)
            {
                bk.CusID = "Cus004";
            }
            else
            {
                bk.CusID = customer.CusID;
            }
            if (ModelState.IsValid)
            {
                try { 
                db.Bookings.Add(bk);
                await db.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Thành Công"+ex);
                }
                return RedirectToAction("Index", "ParkingSite");
            }
                return RedirectToAction("Index", "ParkingSite");
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( FormCollection filed)
        {
            if (ModelState.IsValid)
            {
                var bkId = filed["BkID"];
                var expOut = DateTime.Parse(filed["ExpOut"]);
                var bkDao = new BookingDao();
                var rs = bkDao.Update(bkId, expOut);
                if (rs == true)
                {
                    return RedirectToAction("Index", "ParkingSite");

                }
                else
                {
                    ModelState.AddModelError("Index", "Không Thành Công" );
                }
            }
            return RedirectToAction("Index", "ParkingSite");
        }


    }
}

using ParkingCore.DAO;
using ParkingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyParkingCL.Controllers
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
            var customer = new Customer();
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
            if (customer == null)
            {
                bk.CusID = "Cus004";
            }
            else
            {
                bk.CusID = customer.CusID;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Bookings.Add(bk);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    SetAlert("Đặt chỗ không thành công.", "error");
                    ModelState.AddModelError("", "Không Thành Công" + ex);
                }
                SetAlert("Đặt chỗ thành công.", "success");
                return RedirectToAction("Parking", "Home");
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(FormCollection filed)
        {
                var pkID1 = filed["PkID"];
            if (ModelState.IsValid)
            {
                var bkId = filed["BkID"];
                var pkID = filed["PkID"];
                var expOut = DateTime.Parse(filed["ExpOut"]);
                var bkDao = new BookingDao();
                var rs = bkDao.Update(bkId, expOut);
                if (rs == true)
                {
                    SetAlert("Cập nhật chỗ chỗ thành công.", "success");
                    return RedirectToAction("Parking", "Home",new { @pkID =pkID });

                }
                else
                {
                    SetAlert("Cập nhật không thành công.", "error");
                    ModelState.AddModelError("Index", "Không Thành Công");
                }
            }
            SetAlert("Cập nhật chỗ thành công.", "success");
            return RedirectToAction("Parking", "Home",new { @pkID = pkID1 });
        }


    }
}
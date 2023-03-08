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
using PagedList;
using MyParking.Model;
using MyParking.Common;

namespace MyParking.Controllers
{
    public class OrderInvoidsController : BaseController
    {
        private MyParkingDbContext db = new MyParkingDbContext();

        // GET: OrderInvoids
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var session = (LoginModel)Session[Constants.USER_SESSION];
            if (session == null) return RedirectToAction("Index", "Login");
            var iv = new OrderInvoidDao();
            var model = iv.ListAll(session.PkID);
            return View( model.ToPagedList(page, pagesize));

        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var iv = new OrderInvoidDao();

            var model = iv.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        // GET: OrderInvoids/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderInvoid orderInvoid = await db.OrderInvoids.FindAsync(id);
            if (orderInvoid == null)
            {
                return HttpNotFound();
            }
            return View(orderInvoid);
        }

        public  ActionResult Create(string bkID)
        {
            var bkdao = new BookingDao();
            var bk=   bkdao.FinByBkID(bkID);
            var ivDao = new OrderInvoidDao();
            var rs = ivDao.Add(bk);
            if(rs!=null) {
                SetAlert("Xuất bãi thành công.", "success");
                var ordID =  db.OrderInvoids.Where(x=>x.BookingID==bkID).OrderByDescending(x=>x.OrdID).Single();
                return RedirectToAction("Details", "OrderInvoids", new { @id = "OD009" });
            }
            else
            {
                SetAlert("Xuất bãi không thành công.", "error");
                return RedirectToAction("Index", "ParkingSite");
            }
        }

        // GET: OrderInvoids/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderInvoid orderInvoid = await db.OrderInvoids.FindAsync(id);
            if (orderInvoid == null)
            {
                return HttpNotFound();
            }
            return View(orderInvoid);
        }

        // POST: OrderInvoids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OrdID,BookingID,CusName,Phone,CarNo,PkID,PkName,PkSlotID,SlotNo,DateIn,ExpOut,DateOut,Status,ExpTotalPrice,Fine,TotalPrice,PaymentStatus")] OrderInvoid orderInvoid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderInvoid).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(orderInvoid);
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            OrderInvoid orderInvoid =  db.OrderInvoids.Find(id);
            db.OrderInvoids.Remove(orderInvoid);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

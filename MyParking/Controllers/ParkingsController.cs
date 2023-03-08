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

namespace MyParking.Controllers
{
    public class ParkingsController : BaseController
    {
        private MyParkingDbContext db = new MyParkingDbContext();

        // GET: Parkings
        public async Task<ActionResult> Index()
        {
            return View(await db.Parkings.ToListAsync());
        }

        // GET: Parkings/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parking parking = await db.Parkings.FindAsync(id);
            if (parking == null)
            {
                return HttpNotFound();
            }
            return View(parking);
        }

        // GET: Parkings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parkings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PkID,PkName,Phone,Email,Slot,Floor,PkAddress")] Parking parking)
        {
            if (ModelState.IsValid)
            {
                db.Parkings.Add(parking);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(parking);
        }

        // GET: Parkings/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parking parking = await db.Parkings.FindAsync(id);
            if (parking == null)
            {
                return HttpNotFound();
            }
            return View(parking);
        }

        // POST: Parkings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PkID,PkName,Phone,Email,Slot,Floor,PkAddress")] Parking parking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parking).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(parking);
        }

        // GET: Parkings/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parking parking = await db.Parkings.FindAsync(id);
            if (parking == null)
            {
                return HttpNotFound();
            }
            return View(parking);
        }

        // POST: Parkings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Parking parking = await db.Parkings.FindAsync(id);
            db.Parkings.Remove(parking);
            await db.SaveChangesAsync();
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

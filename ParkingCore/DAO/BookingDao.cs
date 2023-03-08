using ParkingCore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCore.DAO
{
    public class BookingDao
    {

        private MyParkingDbContext db;
        public BookingDao()
        {
            db = new MyParkingDbContext();

        }
        public List<Booking> FinByPkID(string pkID)
        {
            var booking = db.Bookings.Where(x => x.PkID == pkID && x.Status==true).ToList();
            return booking;
        }
        public List<Booking> FinByBkID(string bkID)
        {
            var booking = db.Bookings.Where(x => x.BookingID == bkID && x.Status == true).ToList();
            return booking;
        }
        public Booking Find(string bkId)

        {
            var d = db.Bookings.Find(bkId);
            return d;
        }
        public bool Update(string bkID, DateTime expOut)
        {
            try
            {
                var bk = Find(bkID);
                bk.ExpOut = expOut;
                db.Entry(bk).State=EntityState.Modified; ;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}

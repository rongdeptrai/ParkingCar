using PagedList;
using ParkingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCore.DAO
{
    public class OrderInvoidDao
    {
        private MyParkingDbContext db;
        public OrderInvoidDao()
        {
            db = new MyParkingDbContext();

        }
        public OrderInvoid Add(List<Booking> bk)
        {
            List<OrderInvoid> lsIv= new List<OrderInvoid>();
            var orderInvoid = new OrderInvoid();
            try
            {
                foreach (var item in bk)
            {
                orderInvoid.ExpOut=item.ExpOut;
                orderInvoid.OrdID = "";
                orderInvoid.PaymentStatus = 1;
                orderInvoid.Status = true;
                orderInvoid.DateOut=DateTime.Now;
                orderInvoid.ExpTotalPrice=item.ExpTotalPrice;
                orderInvoid.TotalPrice = 0;
                orderInvoid.BookingID = item.BookingID;
                orderInvoid.CarNo = item.CarNo;
                orderInvoid.CusName=item.CusName;
                orderInvoid.BookingID=item.BookingID;
                orderInvoid.DateIn=item.DateIn;
                orderInvoid.Fine = 0;
                orderInvoid.Phone=item.Phone;
                orderInvoid.SlotNo = item.SlotNo;
                orderInvoid.PkID = item.PkID;
                orderInvoid.PkSlotID=item.PkSlotID;
                orderInvoid.PkName = "Phan Chau trinh";
                lsIv.Add( orderInvoid);
                db.OrderInvoids.Add(orderInvoid); 
                db.SaveChanges();
                }
                return orderInvoid;
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                return orderInvoid=null;
            }
            
        }

        public IEnumerable<OrderInvoid> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<OrderInvoid> model = db.OrderInvoids;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.CusName.Contains(keysearch));
            }

            return model.OrderBy(x => x.DateOut).ToPagedList(page, pagesize);
        }

        public List<OrderInvoid> ListAll(string pkID)
        {
            var rs = new List<OrderInvoid>();
            rs = db.OrderInvoids.Where(x => x.PkID == pkID).ToList();
            if(rs.Count > 0)
            {
                return rs;
            }
            else
            {
                return null;
            }
           
        }
    }
}

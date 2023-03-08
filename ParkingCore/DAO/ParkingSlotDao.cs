using ParkingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCore.DAO
{
    public class ParkingSlotDao
    {
        private MyParkingDbContext db;
        public ParkingSlotDao()
        {
            db = new MyParkingDbContext();

        }
        public List<ParkingSlot> ListByID(string pkID)
        {
            return db.ParkingSlots.Where(x=>x.PkID==pkID).OrderBy(x => x.SlotNo).ToList();
        }
        public Array  ListFloor(string pkID)
        {
            var pkslot = ListByID(pkID);
            return pkslot.GroupBy(x => x.Floor).ToArray();
        }
        public bool AddSlot(ParkingSlot pksl)
        {
            var rs= db.ParkingSlots.Add(pksl);
            if (rs !=null)
            {
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using PagedList;
using ParkingCore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCore.DAO
{
    public class ParkingDao
    {
        private MyParkingDbContext db;
        public ParkingDao()
        {
            db = new MyParkingDbContext();

        }
        public List<Parking> ListAll()
        {
            return db.Parkings.ToList();
        }
        public List<Customer> ListAllCus()
        {
            return db.Customers.ToList();
        }
        public Parking FindByID(string pkId)
        {
            return db.Parkings.Find(pkId);
        }
        public bool Update(Parking parking)
        {
            try
            {
                db.Entry(parking).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
        public IEnumerable<Parking> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Parking> model = db.Parkings;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.PkName.Contains(keysearch));
            }

            return model.OrderBy(x => x.PkName).ToPagedList(page, pagesize);
        }
        public bool Add(Parking pk)
        {
            try
            {
                db.Parkings.Add(pk);
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

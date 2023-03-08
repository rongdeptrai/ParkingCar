
using ParkingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCore.DAO
{
    public class CustomerDao
    {
        private MyParkingDbContext db;

        public CustomerDao()
        {
            db = new MyParkingDbContext();

        }
        public Customer FinByPhone(string phone)
        {
            try
            {
                var cus = db.Customers.Where(x => x.Phone == phone).First();
                return cus;

            }
            catch (Exception ex) { return null; }


        }
        public List<Customer> ListAll (){
         return db.Customers.ToList();  
        }

        public int login(string phone, string pass)
        {
            var rs = db.Customers.SingleOrDefault(x => x.Phone.Contains(phone) && x.Pass.Contains(pass));
            if (rs == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public int SigUp(Customer customer)
        {
            var rs = db.Customers.Add(customer);
            if (rs == null)
            {

                return 0;
            }
            else
            {
                db.SaveChanges();
                return 1;
            }
        }
    }
}

using ParkingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCore.DAO
{
    public class EmployeeDao
    {
        private MyParkingDbContext db;
        public EmployeeDao()
        {
            db = new MyParkingDbContext();

        }
        public int login(string user, string pass)
        {
            var rs = db.Adminstrator.SingleOrDefault(x => x.UserName.Contains(user) && x.Pass.Contains(pass));
            if (rs == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public int checkTypeEmp(string user)
        {
            var rs = db.Adminstrator.Where(x => x.UserName == user).FirstOrDefault();
            if (rs.AdminID == "AD00")
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public string getPkID(string username) {
            var rs = db.Adminstrator.Where(x => x.UserName == username).FirstOrDefault();
            return rs.PkID;
        } 
    }
}

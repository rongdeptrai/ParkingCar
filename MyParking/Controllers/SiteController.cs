using PagedList;
using ParkingCore.DAO;
using ParkingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyParking.Controllers
{
    public class SiteController : BaseController
    {
        // GET: Site
        public ActionResult Index(int page = 1, int pagesize = 3)
        {
            var pk = new ParkingDao();
            var model = pk.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 3)
        {
            var pk = new ParkingDao();

            var model = pk.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Parking parking)
        {
            var pk = new Parking();
            pk.PkID  = "000a";
            pk.PkName = parking.PkName;
            pk.Email=parking.Email;
            pk.PkAddress=parking.PkAddress;
            pk.Slot=int.Parse(parking.Slot.ToString());
            pk.Floor =  int.Parse(parking.Floor.ToString());
            pk.Phone=parking.Phone;
           try
            {
                var pkDao = new ParkingDao();
                var rs= pkDao.Add(pk);
                if (rs)
                {
                    SetAlert("Tạo mới thành công.", "success");
                    return RedirectToAction("Index");

                }
                else
                {
                    SetAlert("Tạo mới không thành công.", "error");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                SetAlert("Tạo mới không thành công.", "error");
                return RedirectToAction("Index");
            }
        }

        public ActionResult Dashboard (){
            return View();
        }
        public ActionResult CusList(int page = 1, int pagesize = 3)
        {
            var pk = new ParkingDao();
            var model = pk.ListAllCus();
            return View(model.ToPagedList(page, pagesize));
        }
    }
}
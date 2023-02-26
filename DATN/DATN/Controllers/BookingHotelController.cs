using DATN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATN.Controllers
{
    public class BookingHotelController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookingHotel
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ItemPartialView()
        {
            var items = db.BookingRoom.Where(x => x.BookingHotelId == 2).Take(5).ToList();
            foreach(var i in items)
            {
                var itemImages = db.ImageRoom.Where(x => x.BookingRoomId == i.Id).FirstOrDefault();
                i.ImageRoom.Add(itemImages);
            }
            return PartialView(items);
        }
    }
}
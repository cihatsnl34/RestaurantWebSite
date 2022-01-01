using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class VideolartController : Controller
    {
        private RestaurantDBContext db = new RestaurantDBContext();
        // GET: Videolart
        public ActionResult Index()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageUrl=="Videolar").FirstOrDefault();
            return View(db.Videos.Where(x => x.IsActive == true).ToList().OrderByDescending(x => x.ID));
        }
        #region ParçalıSayfalar
        public ActionResult PartialVideoConstantValue()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "Videolar|Banner").FirstOrDefault();
            return PartialView(a);
        }
        #endregion
    }
}
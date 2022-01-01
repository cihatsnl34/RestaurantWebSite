using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class HaberDetayController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: HaberDetay
        public ActionResult Index(string s)
        {
            ViewBag.Seo = db.News.Where(x => x.Slug == s).FirstOrDefault();
            return View(db.News.Where(x => x.IsActive == true && x.Slug == s).FirstOrDefault());
        }
        #region ParçalıSayfalar
        public ActionResult PartialHaberDetayConstantValue()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "Haber Detay|Banner").FirstOrDefault();
            return PartialView(a);
        }
        public ActionResult PartialRandomNewsList()
        {
            return PartialView(db.News.OrderBy(x => Guid.NewGuid()).Where(x => x.IsActive == true).Take(5).ToList());
        }
        #endregion
    }
}
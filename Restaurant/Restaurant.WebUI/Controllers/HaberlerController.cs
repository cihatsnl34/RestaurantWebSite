using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class HaberlerController : Controller
    {

        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Haberler
        public ActionResult Index()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageUrl == "Bizden Haberler").FirstOrDefault();
            return View(db.News.Where(x=>x.IsActive==true).OrderByDescending(x => x.ID).ToList());
        }
        #region Partial View
        public ActionResult PartialHaberlerConstantValue()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "Haber|Banner").FirstOrDefault();
            return PartialView(a);
        }
        #endregion
    }
}
using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class SaglikliBeslenController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: SaglikliBeslen
        public ActionResult Index()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageUrl == "Sağlıklı Beslen").FirstOrDefault();
            return View(db.HealtyEats.Where(x => x.IsActive == true).ToList());
        }
        #region ParçalıSayfalar
        public ActionResult PartialSaglikliConstantValue()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "Sağlıklı Beslen|Banner").FirstOrDefault();
            return PartialView(a);
        }
        #endregion
    }
}
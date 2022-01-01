using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class BasinBizDetayController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: HaberDetay
        public ActionResult Index(string a)
        {
            ViewBag.Seo = db.BasindaBizs.Where(x => x.Slug == a).FirstOrDefault();
            return View(db.BasindaBizs.Where(x => x.IsActive == true && x.Slug == a).FirstOrDefault());
        }
        #region ParçalıSayfalar
        public ActionResult PartialBasindaBizDetayConstantValue()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "Basindabiz Detay|Banner").FirstOrDefault();
            return PartialView(a);
        }
        #endregion
    }
}
using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Restaurant.WebUI.Controllers
{
    public class UrunlerDetayController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: URUNLER
        public ActionResult Index(string s)
        {
            ViewBag.Seo = db.Products.Where(x => x.Slug == s).FirstOrDefault();
            return View(db.Products.Include(x => x.ProductCategory).Include(x => x.ProductFiles).Where(x => x.IsActive == true && x.Slug == s).FirstOrDefault());
        }
        #region ParçalıSayfalar
        public ActionResult PartialProductDetayConstantValue()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "UrunDetay|Banner").FirstOrDefault();
            return PartialView(a);
        }
        #endregion
    }
}
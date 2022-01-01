using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Restaurant.WebUI.Controllers
{
    public class KategoriDetayController : Controller
    {
        private RestaurantDBContext db = new RestaurantDBContext();
        // GET: KategoriDetay
        public ActionResult Index(string s)
        {
            ViewBag.Seo = db.ProductCategories.Where(x => x.Slug == s).FirstOrDefault();
            return View(db.Products.Include(x => x.ProductCategory).Where(x =>x.ProductCategory.Slug == s).OrderBy(x=>x.Rank).ToList());
        }
        public ActionResult PartialKategoriDetayConstantValue()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "KategoriDetay|Banner").FirstOrDefault();
            return PartialView(a);
        }
    }
}
using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class KategoriController : Controller
    {
        private RestaurantDBContext db = new RestaurantDBContext();
        // GET: Kategori
        public ActionResult Index()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.PageUrl == "Kategoriler").FirstOrDefault();
            return View(db.ProductCategories.Where(x => x.IsActive == true).ToList().OrderBy(x => x.Title));
        }
        #region ParçalıSayfalar
        public ActionResult PartialKategoriConstantValue()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "Kategori|Banner").FirstOrDefault();
            return PartialView(a);
        }
        #endregion
    }
}
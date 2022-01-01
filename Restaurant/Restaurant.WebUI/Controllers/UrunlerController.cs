using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class UrunlerController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Urunler
        public ActionResult Index()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true  && x.PageUrl=="Ürünler").FirstOrDefault();
            return View(db.Products.Where(x => x.IsActive == true).OrderBy(x=>x.Rank).ToList());
        }
        #region Partial View
        public ActionResult PartialProductConstantValue()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "Urunler|Banner").FirstOrDefault();
            return PartialView(a);
        }
        #endregion
    }
}
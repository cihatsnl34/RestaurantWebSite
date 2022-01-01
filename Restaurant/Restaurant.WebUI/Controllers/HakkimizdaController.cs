using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    
    public class HakkimizdaController : Controller
    {
        private RestaurantDBContext db = new RestaurantDBContext();
        // GET: About
        public ActionResult Index()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageUrl == "Hakkımızda").FirstOrDefault();
            return View(db.Abouts.Where(x=>x.IsActive==true && x.Title== "Bizim Hakkımızda").FirstOrDefault());
        }
        #region Sayfalar

        #endregion
        #region ParçalıSayfalar
        public ActionResult PartialHakkimizdaConstantValue()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "Hakkımızda|Banner").FirstOrDefault();
            return PartialView(a);
        }
        #endregion
    }
}
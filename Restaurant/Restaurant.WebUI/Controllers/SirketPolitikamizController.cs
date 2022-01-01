using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class SirketPolitikamizController : Controller
    {
        private RestaurantDBContext db = new RestaurantDBContext();
        // GET: SirketPolitikamiz
        public ActionResult Index()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageUrl == "Şirket Politikamız").FirstOrDefault();
            return View(db.Abouts.Where(x => x.IsActive == true && x.Title == "Şirket Politikamız").FirstOrDefault());
        }
        #region PartialView
        public ActionResult PartialSirketPolitikamizConstantValue()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "Şirket Politikamız|Banner").FirstOrDefault();
            return PartialView(a);
        }
        #endregion
    }
}
using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class MisyonumuzController : Controller
    {
        private RestaurantDBContext db = new RestaurantDBContext();
        // GET: Misyonumuz
        public ActionResult Index()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageUrl == "Misyonumuz").FirstOrDefault();
            var a = db.Abouts.Where(x => x.IsActive == true && x.Title == "Misyonumuz").FirstOrDefault();
            if (a != null)
            {
                return View(a);
            }
            else
            {
                string sayfa = "/hakkimizda";
                Response.Redirect(sayfa);
                return RedirectToAction(sayfa);
            }
        }
        #region Sayfalar

        #endregion
        #region ParçalıSayfalar
        public ActionResult PartialMisyonumuzConstantValue()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "Misyonumuz|Banner").FirstOrDefault();
            return PartialView(a);
        }
        #endregion
    }
}
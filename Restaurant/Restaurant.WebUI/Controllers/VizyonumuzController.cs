using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class VizyonumuzController : Controller
    {
        private RestaurantDBContext db = new RestaurantDBContext();
        // GET: Vizyonumuz
        public ActionResult Index()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageUrl == "Vizyonumuz").FirstOrDefault();
            var a = db.Abouts.Where(x => x.IsActive == true && x.Title == "Vizyonumuz").FirstOrDefault();
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

        #region PartialView
        public ActionResult PartialVizyonumuzConstantValue()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "Vizyonumuz|Banner").FirstOrDefault();
            return PartialView(a);
        }
        #endregion
    }
}
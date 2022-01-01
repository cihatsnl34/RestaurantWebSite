using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class RestorantVeIsController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: RestorantVeIs
        public ActionResult Index()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageUrl == "Restaurant").FirstOrDefault();
            return View(db.RestaurantBusinesses.Where(x => x.IsActive == true).OrderBy(x=>x.Rank).ToList());
        }
        #region ParçalıSayfalar
        public ActionResult PartialRestaurantConstantValue()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "Restaurant|Banner").FirstOrDefault();
            return PartialView(a);
        }
        #endregion
    }
}
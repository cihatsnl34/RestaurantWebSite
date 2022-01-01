using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class SıkcaSorulanSorularController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: SıkcaSorulanSorular
        public ActionResult Index()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageUrl == "Sıkça Sorulan Sorular").FirstOrDefault();
            return View(db.SSS.Where(x => x.IsActive == true).ToList().OrderBy(x=>x.Rank));
        }
        #region ParçalıSayfalar
        public ActionResult PartialSSSConstantValue()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "SSS|Banner").FirstOrDefault();
            return PartialView(a);
        }
        #endregion
    }
}
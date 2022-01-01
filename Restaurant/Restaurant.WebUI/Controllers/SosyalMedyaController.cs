using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class SosyalMedyaController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: SosyalMedya

        public ActionResult Index()
        {
            return View(db.SocialMedias.Where(x => x.IsActive == true).FirstOrDefault());
        }
        #region ParçalıSayfalar
        public ActionResult PartialSocialMedia()
        {
            return PartialView(db.SocialMedias.Where(x => x.IsActive == true).ToList());
        }
        #endregion
    }
}
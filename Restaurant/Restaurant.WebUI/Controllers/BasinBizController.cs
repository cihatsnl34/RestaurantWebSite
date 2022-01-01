using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class BasinBizController : Controller
    {
        private RestaurantDBContext db = new RestaurantDBContext();
        // GET: MailBilgi
        public ActionResult Index()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageUrl == "Basında Biz").FirstOrDefault();
            return View(db.BasindaBizs.Where(x => x.IsActive == true).ToList());
        }
        #region Partial View
        public ActionResult PartialBasindaBizConstantValue()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "BasindaBiz|Banner").FirstOrDefault();
            return PartialView(a);
        }
        #endregion
    }
}
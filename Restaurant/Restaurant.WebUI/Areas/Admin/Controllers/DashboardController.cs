using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/Dashboard
        #region Anasayfa
        public ActionResult Index()
        {
            return View();
        }

        #endregion
        #region basindabiz
        public ActionResult BasindaBiz()
        {
            var x = db.BasindaBizs.ToList();
            return View(x);
        }
        #endregion
        #region Haber
        public ActionResult News()
        {
            var x = db.News.ToList();
            return View(x);
        }
        #endregion
        #region Hakkımızda
        public ActionResult About()
        {
            var x = db.Abouts.ToList();
            return View(x);
        }
        #endregion
        #region InformationMail
        public ActionResult InformationMail()
        {
            var x = db.InformationMails.ToList();
            return View(x);
        }
        #endregion
        #region İletişimBilgileri
        public ActionResult ContactInformation()
        {
            var x = db.ContactInformations.ToList();
            return View(x);
        }
        #endregion
        #region İletişimMail
        public ActionResult ContactMail()
        {
            var x = db.ContactMails.ToList();
            return View(x);
        }
        #endregion
        #region İnsanKaynakları
        public ActionResult HumanResources()
        {
            var x = db.HumanResourcess.ToList();
            return View(x);
        }
        #endregion
        #region SabitDegerler
        public ActionResult ConstantValue()
        {
            var x = db.ConstantValues.ToList();
            return View(x);
        }
        #endregion
        #region SaglikliBeslen
        public ActionResult HealtyEat()
        {
            var x = db.HealtyEats.ToList();
            return View(x);
        }
        #endregion
        #region AnaGoogleSeo
        public ActionResult MainGoogleSeo()
        {
            var x = db.MainGoogleSeos.ToList();
            return View(x);
        }
        #endregion
        #region RestorantVeIs
        public ActionResult RestaurantBusines()
        {
            var x = db.RestaurantBusinesses.ToList();
            return View(x);
        }
        #endregion
        #region Kullanıcı
        public ActionResult UserMember()
        {
            var x = db.UserMembers.ToList();
            return View(x);
        }
        #endregion
        #region Slider
        public ActionResult Slider()
        {
            var x = db.Sliders.ToList();
            return View(x);
        }
        #endregion
        #region SSS
        public ActionResult SSS()
        {
            var x = db.SSS.ToList();
            return View(x);
        }
        #endregion
        #region SosyalMedya
        public ActionResult SocialMedia()
        {
            var x = db.SocialMedias.ToList();
            return View(x);
        }
        #endregion
        #region Lezzetlerimiz
        public ActionResult Flavors()
        {
            var x = db.flavorss.ToList();
            return View(x);
        }
        #endregion
        #region Ürün
        public ActionResult Product()
        {
            var x = db.Products.Include(y=>y.ProductCategory).ToList();
            return View(x);
        }
        public ActionResult ProductCategory()
        {
            var x = db.ProductCategories.ToList();
            return View(x);
        }
        public ActionResult ProductFile()
        {
            var x = db.ProductFiles.Include(y=>y.Product).ToList();
            return View(x);
        }
        #endregion
        #region Video
        public ActionResult Video()
        {
            var x = db.Videos.ToList();
            return View(x);
        }
        #endregion
    }
}
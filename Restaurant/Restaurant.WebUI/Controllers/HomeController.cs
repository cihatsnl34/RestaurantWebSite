using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Restaurant.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantDBContext db = new RestaurantDBContext();

        public ActionResult Index()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageUrl == "Anasayfa").FirstOrDefault();
            return View();
        }
        #region Partial
        public ActionResult PartialSlider()
        {
            return PartialView(db.Sliders.Where(x => x.IsActive == true).OrderByDescending(x=>x.ID).ToList());
        }
        public ActionResult PartialCategory()
        {
            return PartialView(db.flavorss.Where(x => x.IsActive == true).ToList().OrderBy(x=>x.Rank));
        }
        public ActionResult PartialTabCategory()
        {
            return PartialView(db.ProductCategories.Include(x=>x.Products).Where(x => x.IsActive == true).ToList().OrderBy(x => x.Rank));
        }
        public ActionResult PartialMobileMenuCategoryList()
        {
            return PartialView(db.ProductCategories.Where(x => x.IsActive == true).ToList().OrderBy(x => x.Title));
        }
        public ActionResult PartialConstantValue1()
        {
            var a= db.ConstantValues.Where(x => x.IsActive == true && x.Code == "Anasayfa|Alan1").FirstOrDefault();
            return PartialView(a);
        }
        public ActionResult PartialConstantValue2()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "Anasayfa|Alan2").FirstOrDefault();
            return PartialView(a);
        }
        public ActionResult PartialConstantValue3()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "Anasayfa|Alan3").FirstOrDefault();
            return PartialView(a);
        }
        public ActionResult PartialNews()
        {
            return PartialView(db.News.Where(x => x.IsActive == true).OrderByDescending(x=>x.ID).ToList().Take(15));
        }
        public ActionResult PartialVideoList()
        {
            return PartialView(db.Videos.Where(x => x.IsActive == true).ToList().OrderByDescending(x => x.ID).Take(3));
        }
        public ActionResult PartialHeaderMenuList()
        {
            return PartialView(db.MainGoogleSeos.Where(x => x.IsActive == true).OrderBy(x=>x.Rank).ToList());
        }
        public ActionResult PartialHeaderLezzetlerimizCateogryList()
        {
            return PartialView(db.ProductCategories.Include(x=>x.Products).Where(x => x.IsActive == true).OrderBy(x=>x.Rank).ToList());
        }
        public ActionResult PartialHeaderRestaurantList()
        {
            return PartialView(db.RestaurantBusinesses.Where(x => x.IsActive == true).ToList().OrderBy(x => x.Tittle));
        }
        public ActionResult PartialProductList()
        {
            return PartialView(db.Products.Include(x=>x.ProductCategory).Where(x => x.IsActive == true && x.HomePageIsActive==true).OrderBy(x=>x.ProductCategory.Rank).ToList().Take(8));
        }
        public ActionResult PartialFooterMenuCategoryList()
        {
            return PartialView(db.ProductCategories.Where(x => x.IsActive == true).ToList().OrderBy(x => x.Rank).Take(5));
        }
        public ActionResult PartialHeaderSaglikliBeslen()
        {
            return PartialView(db.HealtyEats.Where(x=>x.IsActive==true).ToList().OrderByDescending(x => x.ID).Take(5));
        }
        public ActionResult PartialHeaderBizdenHaberler()
        {
            return PartialView(db.News.Where(x => x.IsActive == true).ToList().OrderByDescending(x => x.ID).Take(5));
        }
        public ActionResult PartialMobileMenuList()
        {
            return PartialView(db.MainGoogleSeos.Where(x => x.IsActive == true).OrderBy(x=>x.Rank).ToList());
        }
        public ActionResult PartialAboutFooter()
        {
            return PartialView(db.Abouts.Where(x => x.Title == "Bizim Hakkımızda").FirstOrDefault());
        }
        public ActionResult PartialFooterMenuList()
        {
            return PartialView(db.MainGoogleSeos.Where(x => x.IsActive == true).OrderBy(x => x.Rank).ToList());
        }
        #endregion
    }
}
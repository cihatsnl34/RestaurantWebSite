using Restaurant.WebUI.Content.Helper;
using Restaurant.Entity.Entity;
using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/ProductCategory
        #region Create
        public ActionResult AddProductCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddProductCategory(ProductCategory productcategory, HttpPostedFileBase File)
        {

            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/ProductCategorys/" + photoName));
                    File.SaveAs(url);
                    productcategory.File = photoName;
                    productcategory.IsActive = true;
                    productcategory.LastDateTime = DateTime.Now;
                    productcategory.Slug = StringHelper.StringReplacer(productcategory.Title.ToLower());
                    productcategory.seoTitle = productcategory.Title + " - " + "Prosave Med";
                    productcategory.seoReply = "info@prosavemed.com";
                    productcategory.seoCopyright = "© Copyright BİDAA. All Rights Reserved Design By MekaSoftech";
                    productcategory.seoAuthor = "Prosave Med";
                    productcategory.seoDesigner = "Meka Software Yazılım Bilişim Sistemleri";
                    db.ProductCategories.Add(productcategory);
                    db.SaveChanges();
                    return RedirectToAction("ProductCategory", "Dashboard");
                }
            }
            return View(productcategory);
        }
        #endregion
        #region Delete
        public ActionResult DeleteProductCategory(int ID)
        {
            ProductCategory productcategory = db.ProductCategories.Where(x => x.ID == ID).SingleOrDefault();

            db.ProductCategories.Remove(productcategory);
            db.SaveChanges();
            return RedirectToAction("ProductCategory", "Dashboard");
        }
        #endregion
        #region Update
        public ActionResult UpdateProductCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory ProductCategory = db.ProductCategories.Find(id);
            if (ProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(ProductCategory);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateProductCategory(int id, ProductCategory ProductCategory, HttpPostedFileBase File)
        {
            var AU = db.ProductCategories.Find(id);
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/ProductCategorys/" + photoName));
                    File.SaveAs(url);
                    AU.File = photoName;
                }
                AU.Title = ProductCategory.Title;
                AU.Content = ProductCategory.Content;
                AU.Note = ProductCategory.Note;
                AU.IsActive = ProductCategory.IsActive;
                AU.LastDateTime = DateTime.Now;
                AU.Slug = StringHelper.StringReplacer(AU.Title.ToLower());
                AU.seoTitle = AU.Title + " - " + "BİDAA";
                AU.seoReply = "info@prosavemed.com";
                AU.seoCopyright = "© Copyright BİDAA All Rights Reserved Design By MekaSoftech";
                AU.seoAuthor = "BİDAA";
                AU.seoDesigner = "Meka Software Yazılım Bilişim Sistemleri";
                AU.seoClassification = ProductCategory.seoClassification;
                AU.seoFacebookDescription = ProductCategory.seoFacebookDescription;
                AU.seoFacebookTitle = ProductCategory.seoFacebookTitle;
                AU.seoKDescription = ProductCategory.seoKDescription;
                AU.seoFacebookUrl = ProductCategory.seoFacebookUrl;
                AU.seoKeywords = ProductCategory.seoKeywords;
                AU.seoPublisher = "MekaSoftware";
                AU.seoSubject = ProductCategory.seoSubject;
                AU.seoTwitterDescription = ProductCategory.seoTwitterDescription;
                AU.seoTwitterTitle = ProductCategory.seoTwitterTitle;
                AU.seoTwitterUrl = ProductCategory.seoTwitterUrl;
                AU.Rank = ProductCategory.Rank;
                db.SaveChanges();
                return RedirectToAction("ProductCategory", "Dashboard");
            }
            return View(ProductCategory);
        }
        #endregion 


    }
}
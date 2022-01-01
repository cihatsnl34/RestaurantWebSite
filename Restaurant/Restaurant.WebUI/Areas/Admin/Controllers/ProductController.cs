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
    public class ProductController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/Product
        #region Create
        public ActionResult AddProduct()
        {
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories.Where(x => x.IsActive == true), "ID", "Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult AddProduct(Product product, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/Products/" + photoName));
                    File.SaveAs(url);
                    product.File = photoName;
                }
                product.IsActive = true;
                product.LastDateTime = DateTime.Now;
                product.Slug = StringHelper.StringReplacer(product.Title.ToLower());
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Product", "Dashboard");
            }
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories.Where(x => x.IsActive == true), "ID", "Title", product.ProductCategoryID);
            return View(product);
        }
        #endregion
        #region Delete
        public ActionResult DeleteProduct(int ID)
        {
            Product product = db.Products.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/File/Products/" + product.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/File/Products/" + product.File));
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Product", "Dashboard");
        }
        #endregion
        #region Update
        public ActionResult UpdateProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product s = db.Products.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories.Where(x => x.IsActive == true), "ID", "Title");

            return View(s);
        }

        [HttpPost] [ValidateAntiForgeryToken] [ValidateInput(false)]
        public ActionResult UpdateProduct(int id, Product Product, HttpPostedFileBase File)
        {
            var AU = db.Products.Find(id);
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/File/Products/" + AU.File)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/File/Products/" + AU.File));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/Products/" + photoName));
                    File.SaveAs(url);
                    AU.File = photoName;
                }
                AU.Title = Product.Title;
                AU.Description = Product.Description;
                AU.FileAlt = Product.FileAlt;
                AU.ShortDescription = Product.ShortDescription;
                AU.ProductIndex = Product.ProductIndex;
                AU.Protein = Product.Protein;
                AU.ServiceReco = Product.ServiceReco;
                AU.Tuz = Product.Tuz;
                AU.Yag = Product.Yag;
                AU.Sugar = Product.Sugar;
                AU.Rank = Product.Rank;
                AU.HomePageIsActive = Product.HomePageIsActive;
                AU.DoymusYag = Product.DoymusYag;
                AU.Energy = Product.Energy;
                AU.Allergen = Product.Allergen;
                AU.Karbonhidrat = Product.Karbonhidrat;
                AU.KayıtNo = Product.KayıtNo;
                AU.Mensei = Product.Mensei;
                AU.NetGram = Product.NetGram;
                AU.StorageCondition = Product.StorageCondition;
                AU.IsActive = Product.IsActive;
                AU.LastDateTime = DateTime.Now;
                AU.Slug = StringHelper.StringReplacer(AU.Title.ToLower());
                AU.seoTitle = AU.Title + " - " + "BİDAA";
                AU.seoReply = "info@prosavemed.com";
                AU.seoCopyright = "© Copyright BİDAA All Rights Reserved Design By MekaSoftech";
                AU.seoAuthor = "BİDAA";
                AU.seoDesigner = "Meka Software Yazılım Bilişim Sistemleri";
                AU.seoClassification = Product.seoClassification;
                AU.seoFacebookDescription = Product.seoFacebookDescription;
                AU.seoFacebookTitle = Product.seoFacebookTitle;
                AU.seoKDescription = Product.seoKDescription;
                AU.seoFacebookUrl = Product.seoFacebookUrl;
                AU.seoKeywords = Product.seoKeywords;
                AU.seoPublisher = "MekaSoftware";
                AU.seoSubject = Product.seoSubject;
                AU.seoTwitterDescription = Product.seoTwitterDescription;
                AU.seoTwitterTitle = Product.seoTwitterTitle;
                AU.seoTwitterUrl = Product.seoTwitterUrl;
                AU.Feature = Product.Feature;
                db.SaveChanges();
                return RedirectToAction("Product", "Dashboard");
            }
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories.Where(x => x.IsActive == true), "ID", "Title");

            return View(Product);
        }
        #endregion
    }
}
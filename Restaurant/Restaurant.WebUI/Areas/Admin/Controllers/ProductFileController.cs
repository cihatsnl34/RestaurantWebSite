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
    public class ProductFileController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/ProductFile
        #region Create
        public ActionResult AddProductFile()
        {
            ViewBag.ProductID = new SelectList(db.Products.Where(x => x.IsActive == true), "ID", "Title");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddProductFile(ProductFile productimage, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/ProductFiles/" + photoName));
                    File.SaveAs(url);
                    productimage.File = photoName;
                }
                productimage.IsActive = true;
                productimage.LastDateTime = DateTime.Now;
                ProductFile product = db.ProductFiles.Add(productimage);
                db.SaveChanges();
                return RedirectToAction("ProductFile", "Dashboard");
            }
            ViewBag.ProductID = new SelectList(db.Products.Where(x => x.IsActive == true), "ID", "Title", productimage.ProductID);
            return View(productimage);
        }
        #endregion
        #region Delete
        public ActionResult DeleteProductFile(int ID)
        {
            ProductFile productfile = db.ProductFiles.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/File/ProductFiles/" + productfile.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/File/ProductFiles/" + productfile.File));
            }
            db.ProductFiles.Remove(productfile);
            db.SaveChanges();
            return RedirectToAction("ProductFile", "Dashboard");
        }
        #endregion
        #region Update
        public ActionResult UpdateProductFile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductFile ProductFile = db.ProductFiles.Find(id);
            if (ProductFile == null)
            {
                return HttpNotFound();
            }
            return View(ProductFile);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateProductFile(int id, ProductFile ProductFile, HttpPostedFileBase File)
        {
            var AU = db.ProductFiles.Find(id);
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/File/ProductFiles/" + AU.File)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/File/ProductFiles/" + AU.File));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/ProductFiles/" + photoName));
                    File.SaveAs(url);
                    AU.File = photoName;
                }
                AU.FileAlt = ProductFile.FileAlt;
                AU.ProductID = ProductFile.ProductID;
                AU.Product = ProductFile.Product;
                AU.IsActive = ProductFile.IsActive;
                AU.LastDateTime = DateTime.Now;
                //AU.Slug = StringHelper.StringReplacer(AU.Name.ToLower());
                db.SaveChanges();
                return RedirectToAction("ProductFile", "Dashboard");
            }
            return View(ProductFile);
        }
        #endregion
    }
}
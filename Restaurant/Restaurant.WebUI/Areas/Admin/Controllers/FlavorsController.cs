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
    public class FlavorsController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/Flavors
        #region Create
        public ActionResult AddFlavors()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddFlavors(Flavors flavorss, HttpPostedFileBase File)
        {
           
            if (ModelState.IsValid)
            {
                
                    
                
                    if (File != null)
                    {
                        string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                        var url = Path.Combine(Server.MapPath("~/File/Flavors/" + photoName));

                        File.SaveAs(url);
                         flavorss.File = photoName;
                         flavorss.IsActive = true;
                         flavorss.LastDateTime = DateTime.Now;
                        db.flavorss.Add(flavorss);
                        db.SaveChanges();
                        return RedirectToAction("Flavors", "Dashboard");
                    }
                
            }
            return View(flavorss);
        }
        #endregion
        #region Update
        public ActionResult UpdateFlavors(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flavors s = db.flavorss.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateFlavors(int id, Flavors slider, HttpPostedFileBase File)
        {
            var AU = db.flavorss.Find(id);
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/File/Flavors/" + AU.File)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/File/Flavors/" + AU.File));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/Flavors/" + photoName));
                    File.SaveAs(url);
                    AU.File = photoName;
                }
                AU.Title = slider.Title;
                AU.Rank = slider.Rank;
                AU.Content = slider.Content;
                AU.pageUrl = slider.pageUrl;
                AU.haberUrl = slider.haberUrl;
                AU.basinUrl = slider.basinUrl;
                AU.kategoriUrl = slider.kategoriUrl;
                AU.urunUrl = slider.urunUrl;
                AU.IsActive = slider.IsActive;
                AU.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Flavors", "Dashboard");
            }
            return View(slider);
        }
        #endregion    
        #region Delete
        public ActionResult DeleteFlavors(int ID)
        {
            Flavors flavorss = db.flavorss.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/File/Flavors/" + flavorss.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/File/Flavors/" + flavorss.File));
            }
            db.flavorss.Remove(flavorss);
            db.SaveChanges();
            return RedirectToAction("Flavors", "Dashboard");
        }
        #endregion
    }
}
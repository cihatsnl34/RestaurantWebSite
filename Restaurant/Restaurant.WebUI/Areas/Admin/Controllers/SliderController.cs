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
    public class SliderController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/Slider
        #region Create
        public ActionResult AddSlider()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddSlider(Slider slider, HttpPostedFileBase File)
        {
           
            if (ModelState.IsValid)
            {
               
               
                    if (File != null)
                    {
                        string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                        var url = Path.Combine(Server.MapPath("~/File/Sliders/" + photoName));
                        File.SaveAs(url);
                        slider.File = photoName;
                        slider.IsActive = true;
                        slider.LastDateTime = DateTime.Now;
                        slider.Slug = StringHelper.StringReplacer(slider.Title.ToLower());
                        db.Sliders.Add(slider);
                        db.SaveChanges();
                        return RedirectToAction("Slider", "Dashboard");
                    }
                
            }
            return View(slider);
        }
        #endregion
        #region Delete
        public ActionResult DeleteSlider(int ID)
                {
                    Slider slider = db.Sliders.Where(x => x.ID == ID).SingleOrDefault();
                    if (System.IO.File.Exists(Server.MapPath("~/File/Sliders/" + slider.File)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/File/Sliders/" + slider.File));
                    }
                    db.Sliders.Remove(slider);
                    db.SaveChanges();
                    return RedirectToAction("Slider", "Dashboard");
                }
        #endregion
        #region Update
        public ActionResult UpdateSlider(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider s = db.Sliders.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateSlider(int id, Slider slider, HttpPostedFileBase File)
        {
            var AU = db.Sliders.Find(id);
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/File/Sliders/" + AU.File)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/File/Sliders/" + AU.File));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/Sliders/" + photoName));
                    File.SaveAs(url);
                    AU.File = photoName;
                }
                AU.Title = slider.Title;
                AU.Description = slider.Description;
                AU.FileAlt = slider.FileAlt;
                AU.Center = slider.Center;
                AU.Left = slider.Left;
                AU.Right = slider.Right;
                AU.PageUrl = slider.PageUrl;
                AU.LezzetUrl = slider.LezzetUrl;
                AU.ProductUrl = slider.ProductUrl;
                AU.IsActive = slider.IsActive;
                AU.LastDateTime = DateTime.Now;
                AU.Slug = StringHelper.StringReplacer(AU.Title.ToLower());
                db.SaveChanges();
                return RedirectToAction("Slider", "Dashboard");
            }
            return View(slider);
        }
        #endregion


    }
}
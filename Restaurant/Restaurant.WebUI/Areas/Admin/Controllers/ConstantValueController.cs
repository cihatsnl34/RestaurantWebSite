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
    public class ConstantValueController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/ConstantValue
        #region Create
        public ActionResult AddConstantValue()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddConstantValue(ConstantValue constantvalue, HttpPostedFileBase ImageUrl)
        {
            var c = db.ConstantValues.Where(x => x.Code == constantvalue.Code).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (c == null)
                {
                    if (ImageUrl != null)
                    {
                        //dasd
                        string photoName = Path.GetFileName(Guid.NewGuid().ToString() + ImageUrl.FileName);
                        var url = Path.Combine(Server.MapPath("~/File/ConstantValuess/" + photoName));
                        ImageUrl.SaveAs(url);
                        constantvalue.ImageUrl = photoName;
                    }
                    constantvalue.IsActive = true;
                    constantvalue.LastDateTime = DateTime.Now;
                    db.ConstantValues.Add(constantvalue);
                    db.SaveChanges();
                    return RedirectToAction("ConstantValue", "Dashboard");
                }
                else
                {
                    ViewBag.Mesaj = "Sistemde bu bölüme ait bir içerik mevcut";
                    return View(constantvalue);
                }

            }
            return View(constantvalue);
        }
        #endregion
        #region Delete
        public ActionResult DeleteConstantValue(int ID)
        {
            ConstantValue constant = db.ConstantValues.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/File/ConstantValuess/" + constant.ImageUrl)))
            {
                System.IO.File.Delete(Server.MapPath("~/File/ConstantValuess/" + constant.ImageUrl));
            }
            db.ConstantValues.Remove(constant);
            db.SaveChanges();
            return RedirectToAction("ConstantValue", "Dashboard");
        }
        #endregion
        #region Update
        public ActionResult UpdateConstantValue(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConstantValue c = db.ConstantValues.Find(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateConstantValue(int id, ConstantValue slider, HttpPostedFileBase ImageUrl)
        {
            var c = db.ConstantValues.Where(x => x.Code == slider.Code && x.ID!=id).FirstOrDefault();
            var AU = db.ConstantValues.Find(id);
            if (c == null)
            {
                if (ModelState.IsValid)
                {
                    if (ImageUrl != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath("~/File/ConstantValuess/" + AU.ImageUrl)))
                        {
                            System.IO.File.Delete(Server.MapPath("~/File/ConstantValuess/" + AU.ImageUrl));
                        }
                        string photoName = Path.GetFileName(Guid.NewGuid().ToString() + ImageUrl.FileName);
                        var url = Path.Combine(Server.MapPath("~/File/ConstantValuess/" + photoName));
                        ImageUrl.SaveAs(url);
                        AU.ImageUrl = photoName;
                        AU.ImageAlt = slider.ImageAlt;
                    }

                    AU.Title = slider.Title;
                    AU.Content = slider.Content;
                    AU.Code = slider.Code;
                    AU.url = slider.url;
                    AU.IsActive = slider.IsActive;
                    AU.LastDateTime = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("ConstantValue", "Dashboard");
                }
            }
            else
            {
                ViewBag.Mesaj = "Sistemde bu bölüme ait bir içerik mevcut";
                return View(slider);
            }
            return View(slider);
        }
        #endregion    

    }
}
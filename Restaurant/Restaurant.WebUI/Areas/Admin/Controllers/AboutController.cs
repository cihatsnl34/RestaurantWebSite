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
    public class AboutController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/About
        #region Create
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddAbout(About about, HttpPostedFileBase File)
        {
            var AA = db.Abouts.Where(x => x.Title == about.Title).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (AA != null)
                {
                    ViewBag.Mesaj = "Sistemde " + about.Title + " adında kayıt bulunduğu için yenisini ekleyemezsiniz";
                    return View(about);
                }
                else
                {
                    if (File != null)
                    {
                        string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                        var url = Path.Combine(Server.MapPath("~/File/Abouts/" + photoName));
                        
                        File.SaveAs(url);
                        about.File = photoName;
                        about.IsActive = true;
                        about.LastDateTime = DateTime.Now;
                        //about.ShortDescription=
                        //about.Slug = StringHelper.StringReplacer(about.Title.ToLower());
                        db.Abouts.Add(about);
                        db.SaveChanges();
                        return RedirectToAction("About", "Dashboard");
                    }
                }
            }
            return View(about);
        }
        #endregion
        #region Update
        public ActionResult UpdateAbout(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.Abouts.Find(id);
            if (about==null)
            {
                return HttpNotFound();
            }
            return View(about);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateAbout(int ID,About about,HttpPostedFileBase File)
        {
            var AA = db.Abouts.Where(x => x.Title == about.Title && x.ID !=ID).FirstOrDefault();
            var AU = db.Abouts.Find(ID);
            if (ModelState.IsValid)
            {
                if (AA != null)
                {
                    ViewBag.Mesaj = "Sistemde " + about.Title + " adında kayıt bulunduğu için yenisini ekleyemezsiniz";
                    return View(about);
                }
                else
                {
                    if (File != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath("~/File/Abouts/" + about.File)))
                        {
                            System.IO.File.Delete(Server.MapPath("~/File/Abouts/" + about.File));
                        }
                        string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                        var url = Path.Combine(Server.MapPath("~/File/Abouts/" + photoName));
                        File.SaveAs(url);
                        AU.File = photoName;

                    }
                    AU.Title = about.Title;
                    AU.ShortDescription = about.ShortDescription;
                    AU.Description = about.Description;
                    AU.IsActive = about.IsActive;
                    AU.LastDateTime = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("About", "Dashboard");
                }
            }
            return View(about);
        }
        #endregion
        #region Delete
        public ActionResult DeleteAbout(int ID)
        {
            About about = db.Abouts.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/File/Abouts/" + about.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/File/Abouts/" + about.File));
            }
            db.Abouts.Remove(about);
            db.SaveChanges();
            return RedirectToAction("About", "Dashboard");
        }
        #endregion
    }
}
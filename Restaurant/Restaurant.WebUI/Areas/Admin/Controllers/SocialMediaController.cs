using Restaurant.Entity.Entity;
using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    public class SocialMediaController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/SocialMedia
        #region Create
        public ActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSocialMedia(SocialMedia social)
        {
            if (ModelState.IsValid)
            {
                social.IsActive = true;
                social.LastDateTime = DateTime.Now;
                db.SocialMedias.Add(social);
                db.SaveChanges();
                return RedirectToAction("SocialMedia", "Dashboard");
            }
            return View(social);
        }
        #endregion
        #region Delete
        [HttpGet]
        public ActionResult DeleteSocialMedia(int ID)
        {
            SocialMedia socialMedia = db.SocialMedias.Where(x => x.ID == ID).SingleOrDefault();
            db.SocialMedias.Remove(socialMedia);
            db.SaveChanges();
            return RedirectToAction("SocialMedia", "Dashboard");
        }

        #endregion
        #region Update
        public ActionResult UpdateSocialMedia(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMedia SocialMedia = db.SocialMedias.Find(id);
            if (SocialMedia == null)
            {
                return HttpNotFound();
            }
            return View(SocialMedia);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateSocialMedia(int id, SocialMedia SocialMedia)
        {
            var AU = db.SocialMedias.Find(id);
            if (ModelState.IsValid)
            {
                AU.Title = SocialMedia.Title;
                AU.Url = SocialMedia.Url;
                AU.Icon = SocialMedia.Icon;
                AU.IsActive = SocialMedia.IsActive;
                AU.LastDateTime = DateTime.Now;
                //AU.Slug = StringHelper.StringReplacer(AU.Name.ToLower());
                db.SaveChanges();
                return RedirectToAction("SocialMedia", "Dashboard");
            }
            return View(SocialMedia);
        }
        #endregion 

    }
}
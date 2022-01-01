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
    public class BasindaBizController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/BasindaBiz
        #region Create
        public ActionResult AddBasindaBiz()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddBasindaBiz(BasindaBiz basindabiz, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {

                if (File != null)
                {
                    //dasd
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/BasindaBiz/" + photoName));
                    File.SaveAs(url);
                    basindabiz.File = photoName;
                }
                basindabiz.Slug = StringHelper.StringReplacer(basindabiz.Title.ToLower());
                basindabiz.IsActive = true;
                basindabiz.LastDateTime = DateTime.Now;
                db.BasindaBizs.Add(basindabiz);
                db.SaveChanges();
                return RedirectToAction("BasindaBiz", "Dashboard");



            }
            return View(basindabiz);
        }
        #endregion
        #region Delete
        public ActionResult DeleteBasindaBiz(int ID)
        {
            BasindaBiz basindabiz = db.BasindaBizs.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/File/BasindaBiz/" + basindabiz.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/File/BasindaBiz/" + basindabiz.File));
            }
            db.BasindaBizs.Remove(basindabiz);
            db.SaveChanges();
            return RedirectToAction("BasindaBiz", "Dashboard");
        }
        #endregion
        #region Update
        public ActionResult UpdateBasindaBiz(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasindaBiz s = db.BasindaBizs.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateBasindaBiz(int id, BasindaBiz basindabiz, HttpPostedFileBase File)
        {
            var AU = db.BasindaBizs.Find(id);
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/File/BasindaBiz/" + AU.File)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/File/BasindaBiz/" + AU.File));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/BasindaBiz/" + photoName));
                    File.SaveAs(url);
                    AU.File = photoName;
                }
                AU.Title = basindabiz.Title;
                AU.Content = basindabiz.Content;
                AU.ShortDescription = basindabiz.ShortDescription;
                AU.IsActive = basindabiz.IsActive;
                AU.LastDateTime = DateTime.Now;
                AU.Slug = StringHelper.StringReplacer(AU.Title.ToLower());
                AU.seoTitle = AU.Title + " - " + "BİDAA";
                AU.seoReply = "info@prosavemed.com";
                AU.seoCopyright = "© Copyright BİDAA All Rights Reserved Design By MekaSoftech";
                AU.seoAuthor = "BİDAA";
                AU.seoDesigner = "Meka Software Yazılım Bilişim Sistemleri";
                AU.seoClassification = basindabiz.seoClassification;
                AU.seoFacebookDescription = basindabiz.seoFacebookDescription;
                AU.seoFacebookTitle = basindabiz.seoFacebookTitle;
                AU.seoKDescription = basindabiz.seoKDescription;
                AU.seoFacebookUrl = basindabiz.seoFacebookUrl;
                AU.seoKeywords = basindabiz.seoKeywords;
                AU.seoPublisher = "MekaSoftware";
                AU.seoSubject = basindabiz.seoSubject;
                AU.seoTwitterDescription = basindabiz.seoTwitterDescription;
                AU.seoTwitterTitle = basindabiz.seoTwitterTitle;
                AU.seoTwitterUrl = basindabiz.seoTwitterUrl;
                db.SaveChanges();
                return RedirectToAction("BasindaBiz", "Dashboard");
            }
            return View(basindabiz);
        }
        #endregion
    }
}
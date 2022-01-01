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
    public class SeoController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        public ActionResult AddSeo()
        {
            return View();
        }
        // GET: Admin/Seo
        #region Create
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        
        public ActionResult AddSeo(MainGoogleSeo maingoogleSeo, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {
                if (maingoogleSeo.PageUrl == "Katolog")
                {
                    if (File != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath("~/File/Seo/" + maingoogleSeo.File)))
                        {
                            System.IO.File.Delete(Server.MapPath("~/File/Seo/" + maingoogleSeo.File));
                        }
                        string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                        var url = Path.Combine(Server.MapPath("~/File/Seo/" + photoName));
                        File.SaveAs(url);
                        maingoogleSeo.File = photoName;
                    }
                    maingoogleSeo.IsActive = true;
                    maingoogleSeo.LastDateTime = DateTime.Now;
                    maingoogleSeo.seoTitle = maingoogleSeo.PageName + " - " + "BİDAA";
                    maingoogleSeo.seoReply = "info@prosavemed.com";
                    maingoogleSeo.seoCopyright = "© Copyright BİDAA All Rights Reserved Design By MekaSoftech";
                    maingoogleSeo.seoAuthor = "BİDAA";
                    maingoogleSeo.seoDesigner = "Meka Software Yazılım Bilişim Sistemleri";
                    db.MainGoogleSeos.Add(maingoogleSeo);
                    db.SaveChanges();
                    return RedirectToAction("MainGoogleSeo", "Dashboard");
                }
                else if (maingoogleSeo.PageUrl != "Katolog" && File != null)
                {
                    ViewBag.Mesaj = "Sadece katolog sayfasına PDF dosyası ekleyebilirsiniz";
                    return View(maingoogleSeo);
                }
                else
                {
                    maingoogleSeo.IsActive = true;
                    maingoogleSeo.LastDateTime = DateTime.Now;
                    maingoogleSeo.seoTitle = maingoogleSeo.PageName + " - " + "BİDAA";
                    maingoogleSeo.seoReply = "info@prosavemed.com";
                    maingoogleSeo.seoCopyright = "© Copyright BİDAA All Rights Reserved Design By MekaSoftech";
                    maingoogleSeo.seoAuthor = "BİDAA";
                    maingoogleSeo.seoDesigner = "Meka Software Yazılım Bilişim Sistemleri";
                    db.MainGoogleSeos.Add(maingoogleSeo);
                    db.SaveChanges();
                    return RedirectToAction("MainGoogleSeo", "Dashboard");
                }

            }
            return View(maingoogleSeo);
        }
        #endregion
        #region Delete
        public ActionResult DeleteSeo(int ID)
        {
            MainGoogleSeo maingoogleSeo = db.MainGoogleSeos.Find(ID);
            if (System.IO.File.Exists(Server.MapPath("~/File/Seo/" + maingoogleSeo.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/File/Seo/" + maingoogleSeo.File));
            }
            db.MainGoogleSeos.Remove(maingoogleSeo);
            db.SaveChanges();
            return RedirectToAction("MainGoogleSeo", "Dashboard");
        }

        #endregion
        #region Update
        public ActionResult UpdateSeo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainGoogleSeo Seo = db.MainGoogleSeos.Find(id);
            if (Seo == null)
            {
                return HttpNotFound();
            }
            return View(Seo);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateSeo(int id, MainGoogleSeo Seo, HttpPostedFileBase File)
        {
            var AU = db.MainGoogleSeos.Find(id);
            if (ModelState.IsValid)
            {
                if (Seo.PageUrl == "Katolog")
                {
                    if (File != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath("~/File/Seo/" + AU.File)))
                        {
                            System.IO.File.Delete(Server.MapPath("~/File/Seo/" + AU.File));
                        }
                        string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                        var url = Path.Combine(Server.MapPath("~/File/Seo/" + photoName));
                        File.SaveAs(url);
                        AU.File = photoName;
                    }
                    AU.PageName = Seo.PageName;
                    AU.PageUrl = Seo.PageUrl;
                    AU.LargeDropDown = Seo.LargeDropDown;
                    AU.SmallDropDown = Seo.SmallDropDown;
                    AU.IsActive = Seo.IsActive;
                    AU.LastDateTime = DateTime.Now;
                    AU.seoTitle = AU.PageName + " - " + "BİDAA";
                    AU.seoReply = "info@prosavemed.com";
                    AU.seoCopyright = "© Copyright BİDAA All Rights Reserved Design By MekaSoftech";
                    AU.seoAuthor = "BİDAA";
                    AU.seoDesigner = "Meka Software Yazılım Bilişim Sistemleri";
                    AU.seoClassification = Seo.seoClassification;
                    AU.seoFacebookDescription = Seo.seoFacebookDescription;
                    AU.seoFacebookTitle = Seo.seoFacebookTitle;
                    AU.seoFacebookUrl = Seo.seoFacebookUrl;
                    AU.seoKDescription = Seo.seoKDescription;
                    AU.seoKeywords = Seo.seoKeywords;
                    AU.seoPublisher = Seo.seoPublisher;
                    AU.seoSubject = Seo.seoSubject;
                    AU.seoTwitterDescription = Seo.seoTwitterDescription;
                    AU.seoTwitterTitle = Seo.seoTwitterUrl;
                    AU.Rank = Seo.Rank;
                    //AU.Slug = StringHelper.StringReplacer(AU.Name.ToLower());
                    db.SaveChanges();
                    return RedirectToAction("MainGoogleSeo", "Dashboard");
                }
                else if(Seo.PageUrl != "Katolog" && File != null)
                {
                    ViewBag.Mesaj = "Sadece katolog sayfasına PDF dosyası ekleyebilirsiniz";
                    return View(Seo);
                }
                else
                {
                    AU.PageName = Seo.PageName;
                    AU.PageUrl = Seo.PageUrl;
                    AU.LargeDropDown = Seo.LargeDropDown;
                    AU.SmallDropDown = Seo.SmallDropDown;
                    AU.IsActive = Seo.IsActive;
                    AU.LastDateTime = DateTime.Now;
                    AU.seoTitle = AU.PageName + " - " + "BİDAA";
                    AU.seoReply = "info@prosavemed.com";
                    AU.seoCopyright = "© Copyright BİDAA All Rights Reserved Design By MekaSoftech";
                    AU.seoAuthor = "BİDAA";
                    AU.seoDesigner = "Meka Software Yazılım Bilişim Sistemleri";
                    AU.seoClassification = Seo.seoClassification;
                    AU.seoFacebookDescription = Seo.seoFacebookDescription;
                    AU.seoFacebookTitle = Seo.seoFacebookTitle;
                    AU.seoFacebookUrl = Seo.seoFacebookUrl;
                    AU.seoKDescription = Seo.seoKDescription;
                    AU.seoKeywords = Seo.seoKeywords;
                    AU.seoPublisher = Seo.seoPublisher;
                    AU.seoSubject = Seo.seoSubject;
                    AU.seoTwitterDescription = Seo.seoTwitterDescription;
                    AU.seoTwitterTitle = Seo.seoTwitterUrl;
                    AU.Rank = Seo.Rank;
                    //AU.Slug = StringHelper.StringReplacer(AU.Name.ToLower());
                    db.SaveChanges();
                    return RedirectToAction("MainGoogleSeo", "Dashboard");
                }
                
            }
            return View(Seo);
        }
        #endregion 

    }
}
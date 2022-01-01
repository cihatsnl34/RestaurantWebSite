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
    public class NewsController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/News
        #region Create
        public ActionResult AddNews()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNews(News news, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {
                
                    if (File != null)
                    {
                        //dasd
                        string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                        var url = Path.Combine(Server.MapPath("~/File/News/" + photoName));
                        File.SaveAs(url);
                        news.File = photoName;
                    }
                    news.Slug = StringHelper.StringReplacer(news.Title.ToLower());
                    news.IsActive = true;
                    news.LastDateTime = DateTime.Now;
                    db.News.Add(news);
                    db.SaveChanges();
                    return RedirectToAction("News", "Dashboard");
                
                

            }
            return View(news);
        }
        #endregion
        #region Delete
        public ActionResult DeleteNews(int ID)
        {
            News news = db.News.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/File/News/" + news.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/File/News/" + news.File));
            }
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("News", "Dashboard");
        }
        #endregion
        #region Update
        public ActionResult UpdateNews(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News s = db.News.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateNews(int id, News news, HttpPostedFileBase File)
        {
            var AU = db.News.Find(id);
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/File/News/" + AU.File)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/File/News/" + AU.File));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/News/" + photoName));
                    File.SaveAs(url);
                    AU.File = photoName;
                }
                AU.Title = news.Title;
                AU.Content = news.Content;
                AU.ShortDescription = news.ShortDescription;
                AU.IsActive = news.IsActive;
                AU.LastDateTime = DateTime.Now;
                AU.Slug = StringHelper.StringReplacer(AU.Title.ToLower());
                AU.seoTitle = AU.Title + " - " + "BİDAA";
                AU.seoReply = "info@prosavemed.com";
                AU.seoCopyright = "© Copyright BİDAA All Rights Reserved Design By MekaSoftech";
                AU.seoAuthor = "BİDAA";
                AU.seoDesigner = "Meka Software Yazılım Bilişim Sistemleri";
                AU.seoClassification = news.seoClassification;
                AU.seoFacebookDescription = news.seoFacebookDescription;
                AU.seoFacebookTitle = news.seoFacebookTitle;
                AU.seoKDescription = news.seoKDescription;
                AU.seoFacebookUrl = news.seoFacebookUrl;
                AU.seoKeywords = news.seoKeywords;
                AU.seoPublisher = "MekaSoftware";
                AU.seoSubject = news.seoSubject;
                AU.seoTwitterDescription = news.seoTwitterDescription;
                AU.seoTwitterTitle = news.seoTwitterTitle;
                AU.seoTwitterUrl = news.seoTwitterUrl;
                db.SaveChanges();
                return RedirectToAction("News", "Dashboard");
            }
            return View(news);
        }
        #endregion
    }
}
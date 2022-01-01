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
    public class VideoController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/Video
        #region Create
        public ActionResult AddVideo()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddVideo(Video video, HttpPostedFileBase File)
        {

            if (ModelState.IsValid)
            {


                if (File != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/Videos/" + photoName));
                    File.SaveAs(url);
                    video.File = photoName;
                    video.IsActive = true;
                    video.LastDateTime = DateTime.Now;
                    //video.Slug = StringHelper.StringReplacer(video.Title.ToLower());
                    db.Videos.Add(video);
                    db.SaveChanges();
                    return RedirectToAction("Video", "Dashboard");
                }

            }
            return View(video);
        }
        #endregion
        #region Delete
        public ActionResult DeleteVideo(int ID)
        {
            Video video = db.Videos.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/File/Videos/" + video.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/File/Videos/" + video.File));
            }
            db.Videos.Remove(video);
            db.SaveChanges();
            return RedirectToAction("Video", "Dashboard");
        }
        #endregion
        #region Update
        public ActionResult UpdateVideo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video s = db.Videos.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateVideo(int id, Video video, HttpPostedFileBase File)
        {
            var AU = db.Videos.Find(id);
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/File/Videos/" + AU.File)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/File/Videos/" + AU.File));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/Videos/" + photoName));
                    File.SaveAs(url);
                    AU.File = photoName;
                }
                AU.Title = video.Title;
                AU.Content = video.Content;
                AU.IsActive = video.IsActive;
                AU.LastDateTime = DateTime.Now;
                //AU.Slug = StringHelper.StringReplacer(AU.Title.ToLower());
                db.SaveChanges();
                return RedirectToAction("Video", "Dashboard");
            }
            return View(video);
        }
    }
}
        #endregion

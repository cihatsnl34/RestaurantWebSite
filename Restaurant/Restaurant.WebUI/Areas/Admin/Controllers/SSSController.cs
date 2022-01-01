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
    public class SSSController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/RestaurantBusines
        #region Create
        public ActionResult AddSSS()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddSSS(SSS sss, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/SSSs/" + photoName));
                    File.SaveAs(url);
                    sss.File = photoName;
                    sss.IsActive = true;
                    sss.LastDateTime = DateTime.Now;
                    db.SSS.Add(sss);
                    db.SaveChanges();
                    return RedirectToAction("SSS", "Dashboard");
                }

            }
            return View(sss);
        }
        #endregion
        #region Delete
        public ActionResult DeleteSSS(int ID)
        {
            SSS sSS = db.SSS.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/File/SSSs/" + sSS.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/File/SSSs/" + sSS.File));
            }
            db.SSS.Remove(sSS);
            db.SaveChanges();
            return RedirectToAction("SSS", "Dashboard");
        }
        #endregion
        #region Update
        public ActionResult UpdateSSS(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SSS s = db.SSS.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateSSS(int id, SSS slider, HttpPostedFileBase File)
        {
            var AU = db.SSS.Find(id);
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/File/SSSs/" + AU.File)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/File/SSSs/" + AU.File));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/SSSs/" + photoName));
                    File.SaveAs(url);
                    AU.File = photoName;
                }
                AU.Tittle = slider.Tittle;
                AU.Rank = slider.Rank;
                AU.Content = slider.Content;
                AU.IsActive = slider.IsActive;
                AU.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("SSS", "Dashboard");
            }
            return View(slider);
        }
        #endregion    


    }
}
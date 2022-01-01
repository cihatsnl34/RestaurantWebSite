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
    public class HealtyEatController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/HealtyEat
        #region Create
        public ActionResult AddHealtyEat()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddHealtyEat(HealtyEat healtyeat, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/HealtyEats/" + photoName));
                    File.SaveAs(url);
                    healtyeat.File = photoName;
                    healtyeat.IsActive = true;
                    healtyeat.LastDateTime = DateTime.Now;
                    db.HealtyEats.Add(healtyeat);
                    db.SaveChanges();
                    return RedirectToAction("HealtyEat", "Dashboard");
                }

            }
            return View(healtyeat);
        }
        #endregion
        #region Delete
        public ActionResult DeleteHealtyEat(int ID)
        {
            HealtyEat healtyeat = db.HealtyEats.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/File/HealtyEats/" + healtyeat.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/File/HealtyEats/" + healtyeat.File));
            }
            db.HealtyEats.Remove(healtyeat);
            db.SaveChanges();
            return RedirectToAction("HealtyEat", "Dashboard");
        }
        #endregion
        #region Update
        public ActionResult UpdateHealtyEat(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealtyEat s = db.HealtyEats.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateHealtyEat(int id, HealtyEat slider, HttpPostedFileBase File)
        {
            var AU = db.HealtyEats.Find(id);
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/File/HealtyEats/" + AU.File)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/File/HealtyEats/" + AU.File));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/HealtyEats/" + photoName));
                    File.SaveAs(url);
                    AU.File = photoName;
                }
                AU.Tittle = slider.Tittle;
                AU.Rank = slider.Rank;
                AU.Content = slider.Content;
                AU.IsActive = slider.IsActive;
                AU.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("HealtyEat", "Dashboard");
            }
            return View(slider);
        }
        #endregion    
    }
}

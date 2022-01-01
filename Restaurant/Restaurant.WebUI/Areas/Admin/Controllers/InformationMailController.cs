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
    public class InformationMailController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/InformationMail
        #region Create
        public ActionResult AddInformationMail()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddInformationMail(InformationMail ınformationmail)
        {

            if (ModelState.IsValid)
            {
                ınformationmail.IsActive = true;
                ınformationmail.LastDateTime = DateTime.Now;
                db.InformationMails.Add(ınformationmail);
                db.SaveChanges();
                return RedirectToAction("InformationMail", "Dashboard");
            }
            return View(ınformationmail);
        }
        #endregion
        #region Delete
        public ActionResult DeleteInformationMail(int ID)
        {
            InformationMail ınformationmail = db.InformationMails.Find(ID);
            db.InformationMails.Remove(ınformationmail);
            db.SaveChanges();
            return RedirectToAction("InformationMail", "Dashboard");
        }
        #endregion
        #region Update
        public ActionResult UpdateInformationMail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformationMail informationmail = db.InformationMails.Find(id);
            if (informationmail == null)
            {
                return HttpNotFound();
            }
            return View(informationmail);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateInformationMail(int id, InformationMail informationmail)
        {
            var AU = db.InformationMails.Find(id);
            if (ModelState.IsValid)
            {
                AU.NameSurname = informationmail.NameSurname;
                AU.Phone = informationmail.Phone;
                AU.Subject = informationmail.Subject;
                AU.Messages = informationmail.Messages;
                AU.Email = informationmail.Email;
                AU.IsActive = informationmail.IsActive;
                AU.LastDateTime = DateTime.Now;
                //AU.Slug = StringHelper.StringReplacer(AU.Name.ToLower());
                db.SaveChanges();
                return RedirectToAction("InformationMail", "Dashboard");
            }
            return View(informationmail);
        }
        #endregion 
    }
}
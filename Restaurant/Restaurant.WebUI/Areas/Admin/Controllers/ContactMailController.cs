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
    public class ContactMailController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/ContactInformation
        #region Create
        public ActionResult AddContactMail()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddContactMail(ContactMail contactmail)
        {
            
            if (ModelState.IsValid)
            {
                contactmail.IsActive = true;
                contactmail.LastDateTime = DateTime.Now;
                db.ContactMails.Add(contactmail);
                db.SaveChanges();
                return RedirectToAction("ContactMail", "Dashboard");
            }
            return View(contactmail);
        }
        #endregion
        #region Delete
        public ActionResult DeleteContactMail(int ID)
        {
            ContactMail contactMail = db.ContactMails.Find(ID);
            db.ContactMails.Remove(contactMail);
            db.SaveChanges();
            return RedirectToAction("ContactMail", "Dashboard");
        }
        #endregion
        #region Update
        public ActionResult UpdateContactMail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactMail ContactMail = db.ContactMails.Find(id);
            if (ContactMail == null)
            {
                return HttpNotFound();
            }
            return View(ContactMail);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateContactMail(int id, ContactMail ContactMail)
        {
            var AU = db.ContactMails.Find(id);
            if (ModelState.IsValid)
            {
                AU.NameSurname = ContactMail.NameSurname;
                AU.Phone = ContactMail.Phone;
                AU.Subject= ContactMail.Subject;
                AU.Messages = ContactMail.Messages;
                AU.Email = ContactMail.Email;
                AU.IsActive = ContactMail.IsActive;
                AU.LastDateTime = DateTime.Now;
                //AU.Slug = StringHelper.StringReplacer(AU.Name.ToLower());
                db.SaveChanges();
                return RedirectToAction("ContactMail", "Dashboard");
            }
            return View(ContactMail);
        }
        #endregion 

    }
}
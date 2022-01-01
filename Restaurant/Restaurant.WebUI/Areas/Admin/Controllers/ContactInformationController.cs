using Restaurant.Entity.Entity;
using Restaurant.Entity.Model;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    public class ContactInformationController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/ContactInformation
        #region Create
        public ActionResult AddContactInformation()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddContactInformation(ContactInformation contactinformation)
        {
            var AA = db.Abouts.Count();
            if (ModelState.IsValid)
            {
                contactinformation.IsActive = true;
                contactinformation.LastDateTime = DateTime.Now;
                db.ContactInformations.Add(contactinformation);
                db.SaveChanges();
                return RedirectToAction("ContactInformation", "Dashboard");
            }
            return View(contactinformation);
        }
        #endregion
        #region Delete
        public ActionResult DeleteContactInformation(int ID)
        {
            ContactInformation contact = db.ContactInformations.Find(ID);
            db.ContactInformations.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("ContactInformation", "Dashboard");
        }
        #endregion
        #region Update
        public ActionResult UpdateContactInformation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInformation ContactInformation = db.ContactInformations.Find(id);
            if (ContactInformation == null)
            {
                return HttpNotFound();
            }
            return View(ContactInformation);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateContactInformation(int id, ContactInformation ContactInformation)
        {
            var AU = db.ContactInformations.Find(id);
            if (ModelState.IsValid)
            {
                AU.Phone = ContactInformation.Phone; 
                AU.Address = ContactInformation.Address;
                AU.Email = ContactInformation.Email;
                AU.IsActive = ContactInformation.IsActive;
                AU.LastDateTime = DateTime.Now;
                //AU.Slug = StringHelper.StringReplacer(AU.Name.ToLower());
                db.SaveChanges();
                return RedirectToAction("ContactInformation", "Dashboard");
            }
            return View(ContactInformation);
        }
        #endregion 

    }
}
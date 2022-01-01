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
    public class UserMemberController : Controller
    {

        // GET: Admin/UserMember
        RestaurantDBContext db = new RestaurantDBContext();
        #region Create
        public ActionResult AddUserMember()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddUserMember(UserMember usermember)
        {

            if (ModelState.IsValid)
            {

                usermember.IsActive = true;
                usermember.LastDateTime = DateTime.Now;
                //usermember.Slug = StringHelper.StringReplacer(usermember.Surname.ToLower());
                db.UserMembers.Add(usermember);
                db.SaveChanges();
                return RedirectToAction("UserMember", "Dashboard");


            }
            return View(usermember);
        }
        #endregion
        #region Delete
        public ActionResult DeleteUserMember(int ID)
        {
            UserMember usermember = db.UserMembers.Where(x => x.ID == ID).SingleOrDefault();

            db.UserMembers.Remove(usermember);
            db.SaveChanges();
            return RedirectToAction("UserMember", "Dashboard");
        }
        #endregion
        #region Update
        public ActionResult UpdateUserMember(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMember usermember = db.UserMembers.Find(id);
            if (usermember == null)
            {
                return HttpNotFound();
            }
            return View(usermember);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateUserMember(int id, UserMember usermember)
        {
            var AU = db.UserMembers.Find(id);
            if (ModelState.IsValid)
            {
                AU.Name = usermember.Name;
                AU.Surname = usermember.Surname;
                AU.UserName = usermember.UserName;
                AU.Password = usermember.Password;
                AU.Email = usermember.Email;
                AU.IsActive = usermember.IsActive;
                AU.LastDateTime = DateTime.Now;
                //AU.Slug = StringHelper.StringReplacer(AU.Name.ToLower());
                db.SaveChanges();
                return RedirectToAction("UserMember", "Dashboard");
            }
            return View(usermember);
        }
        #endregion 
        
    }
}
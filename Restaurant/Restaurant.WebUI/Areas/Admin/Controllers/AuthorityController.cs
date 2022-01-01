using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    public class AuthorityController : Controller
    {
        private RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/Authority
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            var data = db.UserMembers.Where(x => x.UserName == Username && x.Password == Password).ToList();
            if (data.Count == 1)
            {
                Session["AdminGiris"] = data.FirstOrDefault();
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                Session["User"] = null;
                ViewBag.ErrorMessage = "Lütfen şifrenizi veya kullanıcı adınızı doğru girdiğinizden emin olunuz.";
                return View(data);
            }
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Login", "Authority");
        }
    }
}
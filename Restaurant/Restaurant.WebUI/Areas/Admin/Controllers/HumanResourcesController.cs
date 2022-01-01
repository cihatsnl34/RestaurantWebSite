using Restaurant.Entity.Entity;
using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    public class HumanResourcesController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/HumanResources
        #region Delete
        public ActionResult DeleteHumanResources(int ID)
        {
            HumanResources humanresources = db.HumanResourcess.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/File/HumanResources/" + humanresources.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/File/HumanResources/" + humanresources.File));
            }
            db.HumanResourcess.Remove(humanresources);
            db.SaveChanges();
            return RedirectToAction("HumanResources", "Dashboard");
        }
        #endregion
    }
}
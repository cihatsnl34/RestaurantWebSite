using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class ErorrController : Controller
    {
        private RestaurantDBContext db = new RestaurantDBContext();
        // GET: Erorr
        public ActionResult NotFound()
        {
            Response.StatusCode = 504;
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = 503;
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = 500;
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = 403;
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = 400;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
    }
}
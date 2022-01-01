using Restaurant.Entity.Entity;
using Restaurant.Entity.Model;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    public class RestaurantBusinesController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Admin/RestaurantBusines
        #region Create
        public ActionResult AddRestaurantBusines()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddRestaurantBusines(RestaurantBusines restaurantbusines)
        {
            if (ModelState.IsValid)
            {
                restaurantbusines.IsActive = true;
                restaurantbusines.LastDateTime = DateTime.Now;
                db.RestaurantBusinesses.Add(restaurantbusines);
                db.SaveChanges();
                return RedirectToAction("RestaurantBusines", "Dashboard");

            }
            return View(restaurantbusines);
        }
        #endregion
        #region Delete
        public ActionResult DeleteRestaurantBusines(int ID)
        {
            RestaurantBusines restaurantbusines = db.RestaurantBusinesses.Where(x => x.ID == ID).SingleOrDefault();
            db.RestaurantBusinesses.Remove(restaurantbusines);
            db.SaveChanges();
            return RedirectToAction("RestaurantBusines", "Dashboard");
        }
        #endregion
        #region Update
        public ActionResult UpdateRestaurantBusines(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantBusines s = db.RestaurantBusinesses.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateRestaurantBusines(int id, RestaurantBusines restaurant)
        {
            var AU = db.RestaurantBusinesses.Find(id);
            if (ModelState.IsValid)
            {
                AU.Tittle = restaurant.Tittle;
                AU.Rank = restaurant.Rank;
                AU.Content = restaurant.Content;
                AU.IsActive = restaurant.IsActive;
                AU.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("RestaurantBusines", "Dashboard");
            }
            return View(restaurant);
        }
        #endregion    



    }
}
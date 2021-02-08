using CustomCar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TravelManager.Controllers
{
    public class ServiceController : Controller
    {
       
        [HttpGet]
        public ActionResult Service(int idCar)
        {
            using (var db = new Entities())
            {
                var servisi = db.Service.Where(s => s.CarIDCar.Equals(idCar)).ToList();
                ViewBag.car = db.Car.Single(c => c.IDCar.Equals(idCar));
                return View(servisi);
            }
        }

        [HttpGet]
        public ActionResult CreateService(int idCar)
        {
            ViewBag.idcar = idCar;
            return View();
        }


        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            using (var db = new Entities())
            {
                db.Service.Add(service);
                db.SaveChanges();
            }
            return RedirectToAction("Service", new RouteValueDictionary(new {idCar = service.CarIDCar}));
        }

       
        public ActionResult DeleteService(int idService)
        {
            using (var db = new Entities())
            {
                Service service = db.Service.Find(idService);
                db.Service.Remove(service);
                db.SaveChanges();
                return RedirectToAction("Service", new RouteValueDictionary(new { idCar = service.CarIDCar }));
            }
        }

        [HttpGet]
        public ActionResult EditService(int idService)
        {

            using (var db = new Entities())
            {
                return View(db.Service.Single(s => s.IDService.Equals(idService)));
            }
        }


        [HttpPost]
        public ActionResult EditService(Service service)
        {
            using (var db = new Entities())
            {
                db.Entry(service).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Service", new RouteValueDictionary(new { idCar = service.CarIDCar }));
            }
        }

        [HttpGet]
        public ActionResult Item(int idService)
        {
            using (var db = new Entities())
            {
                var items = db.Item.Where(s => s.Service == (idService)).ToList();
                Service service = db.Service.Find(idService);
                ViewBag.car = service.CarIDCar;
                ViewBag.service = idService;
                return View(items);
            }
        }



        public ActionResult DeleteItem(int idItem)
        {
            using (var db = new Entities())
            {
                Item item = db.Item.Find(idItem);
                db.Item.Remove(item);
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        [HttpGet]
        public ActionResult EditItem(int idItem)
        {

            using (var db = new Entities())
            {
                Item item = db.Item.Find(idItem);
                ViewBag.idService = item.Service ;
 
                return View(db.Item.Single(s => s.IDItem.Equals(idItem)));
                
            }
        }


        [HttpPost]
        public ActionResult EditItem(Item item)
        {
            using (var db = new Entities())
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Item", new RouteValueDictionary(new { idService = item.Service}));
            }
        }

        [HttpGet]
        public ActionResult CreateItem(int idService)
        {
            ViewBag.idservice = idService;
            return View();
        }

        [HttpPost]
        public ActionResult CreateItem(Item item)
        {
            using (var db = new Entities())
            {
                db.Item.Add(item);
                db.SaveChanges();
            }
            return RedirectToAction("Item", new RouteValueDictionary(new { idService = item.Service }));
        }
        [HttpGet]
        public ActionResult Report(int idCar)
        {

            try
            {
                using (var db = new Entities())
                {
                    Car car = db.Car.Single(c => c.IDCar == idCar);

                    double km = 0;
                    int s = 0;
                    int count = 0;
                    foreach (TravelInfo t in car.TravelInfo)
                    {
                        km += (double)t.TravelLength;

                        var r = db.Route.Where(a => a.TravelInfo.IDTravelInfo == (t.IDTravelInfo)).ToList();

                        count = r.Count;
                        r.ToList().Where(x => x.TravelInfoID == t.IDTravelInfo).ToList().ForEach(ro => s += (int)ro.AverageSpeed);
                    }

                    ViewBag.km = km;
                    ViewBag.car = db.Car.Single(c => c.IDCar == idCar);
                    ViewBag.item = db.Item.ToList();

                    if (count != 0)
                    {
                        s = s / count;
                        ViewBag.speed = s;
                    }
                    var service = db.Service.Where(d => d.CarIDCar == idCar).ToList();
                    return View(service);
                }
            }
            catch (Exception e)
            {
                ViewBag.error = e.StackTrace;
                return View("Error");
            }
        }


    }
}
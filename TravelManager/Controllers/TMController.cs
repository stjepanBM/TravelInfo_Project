using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelManager.Dal;
using TravelManager.Models;

namespace TravelManager.Controllers
{
    public class TMController : Controller
    {
         public static IRepository Repo = RepoFactory.GetRepository();

        public ActionResult Drivers()
        {
            return View(Repo.GetDrivers());
        }
        public ActionResult DatabaseManager()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddDriver()
        {
            ViewBag.gradovi = Repo.GetDrivers();
            return View();
        }

        [HttpPost]
        public ActionResult AddDriver(Driver model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Repo.InsertDriver(model);
                    ViewBag.message = "Driver succesfully added";
                    return View("Confirmation");
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.GetBaseException().Message;
                    return View("Error");
                }
            }
            else
            {
                return View(model);
            }
        }


       



        [HttpGet]
        public ActionResult EditDriver(int IDDriver)
        {
            try
            {
                return View(Repo.GetDriver(IDDriver));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult EditDriver(Driver model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (Repo.UpdateDriver(model) > 0)
                    {
                        ViewBag.message = "Driver's info succesfully updated!";
                        return View("Confirmation");
                    }
                    else
                    {
                        ViewBag.message = "Driver's info not updated!";
                        return View("Confirmation");
                    }

                   
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.GetBaseException().Message;
                    return View("Error");
                }
            }
            else
            {
                
                return View("UrediKupca", Repo.GetDriver(model.IDDriver));
            }
        }
        
        public ActionResult DeleteDriver(int IDDriver)
        {

            try
            {
                if (Repo.DeleteDriver(IDDriver) > 0)
                {
                    
                    return RedirectToAction("Drivers");
                }
                else
                {
                    ViewBag.message = "Driver's info not deleted!";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }


        }


        public ActionResult Cars()
        {
            try
            {
                var cars = Repo.GetCars();
                if (cars != null)
                    return View(cars);
                else
                {
                    ViewBag.error = "nema";
                    return View("Error");

                }
            }
            catch (Exception ex)
            {

                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }


        public ActionResult AddCar(Car car)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Repo.InsertCar(car);
                    ViewBag.message = "Car succesfully added";
                    return View("Confirmation");
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.GetBaseException().Message;
                    return View("Error");
                }
            }
            else
            {
                return View(car);
            }
        }
        public ActionResult DeleteCar(int IDCar)
        {

            try
            {
                int num = Repo.DeleteCar(IDCar);
                if (num > 0)
                {
                    
                    return RedirectToAction("Cars");
                }
                else
                {
                    ViewBag.message = "Driver's info not deleted!";
                    return View("Confirmation");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }



        [HttpGet]
        public ActionResult EditCar(int IDCar)
        {
            try
            {
                return View(Repo.GetCar(IDCar));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult EditCar(Car car)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Repo.UpdateCar(car) > 0)
                    {
                        ViewBag.message = "Car info succesfully updated!";
                        return View("Confirmation");
                    }
                    else
                    {
                        ViewBag.message = "Car info not updated!";
                        return View("Confirmation");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.message = ex.GetBaseException().Message;
                    return View("Error");
                }
            }
            else
            {
                return View("EditCar", Repo.GetCar(car.IDCar));
            }
        }

        [HttpGet]
        public ActionResult AddTravelWarrant()
        {

            try
            {
                ViewBag.drivers = Repo.GetDrivers();
                ViewBag.cars = Repo.GetCars();
                ViewBag.cities = Repo.GetCities();
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult AddTravelWarrant(TravelWarrant model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Repo.InsertTravelWarrant(model);
                    ViewBag.message = "Travel warrant succesfully added";
                    return View("Confirmation");
                }
                catch (Exception ex)
                {
                    ViewBag.message = ex.GetBaseException().Message;
                    return View("Error");
                }
            }
            else
            {
                return View(model);
            }
        }



        [HttpGet]
        public ActionResult TravelWarantDetails(int IDTravelWarrant)
        {
            try
            {
                ViewBag.routes = Repo.GetRoutesForTravelWarrant(IDTravelWarrant);
                return View(Repo.GetTravelWarrant(IDTravelWarrant));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult RouteDetails(int IDTravelWarrant)
        {
            try
            {

                List<Route> routes = Repo.GetRoutesForTravelWarrant(IDTravelWarrant);
                ViewBag.routes = routes;
                return View(routes);
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        public ActionResult TravelWarrant()
        {
            try
            {
                ViewBag.drivers = Repo.GetDrivers();
                ViewBag.cars = Repo.GetCars();
                ViewBag.cities = Repo.GetCities();
                return View(Repo.GetTravelWarrant());
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.StackTrace;
                return View("Error");
                //return View("Error");
            }
        }
        [ChildActionOnly]
        public ActionResult GetCar(int IDCar)
        {
            return Content(Repo.GetCar(IDCar).Brand + "; " + Repo.GetCar(IDCar).YearOfMaking);
        }

        [ChildActionOnly]
        public ActionResult GetDriver(int IDDriver)
        {
            return Content(Repo.GetDriver(IDDriver).DriverName +" " + Repo.GetDriver(IDDriver).DriverSurname);
        }
        [ChildActionOnly]
        public ActionResult GetCity(int IDCity)
        {

            City city = Repo.GetCities().ToList().Find(d => d.IDCity == IDCity);

            return Content(city.CityName);
        }



        public ActionResult DriversTravelWarrant(int IDDriver)
        {
            try
            {
                ViewBag.drivers = Repo.GetDriver(IDDriver);
                return View(Repo.GetDriversTravelWarrant(IDDriver));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }
        public ActionResult _DriversTravelWarrant(int IDDriver)
        {
            try
            {
                ViewBag.drivers = Repo.GetDriver(IDDriver);
                return PartialView(Repo.GetDriversTravelWarrant(IDDriver));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        
        public ActionResult DeleteTravelWarrant(int IDTravelWarrant)
        {

            try
            {
                int num = Repo.DeleteTravelWarrant(IDTravelWarrant);
                if (num > 0)
                {
                    return RedirectToAction("TravelWarrant");
                }
                else
                {
                    ViewBag.message = "Driver's info not deleted!";
                    return View("Confirmation");
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult CreateXml()
        {
            try
            {
                Repo.CreateXml();
                ViewBag.message = "Xml succesfully created!";
                return View("Confirmation");
                //return Redirect(Request.UrlReferrer.ToString());
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.StackTrace;
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult ImportXml()
        {
            try
            {
                Repo.ImportXml();
                return Redirect(Request.UrlReferrer.ToString());
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.StackTrace;
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult AddRoute(int IDTravelWarrant)
        {

            try
            {
                ViewBag.TravelWarrant = IDTravelWarrant;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }

        }



        [HttpPost]
        public ActionResult AddRoute(Route route)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Repo.InsertRoute(route);
                    ViewBag.message = "Route succesfully added";
                     
                    return View("Confirmation");
                    // return Redirect(Request.UrlReferrer.ToString());
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.GetBaseException().Message;
                    return View("Error");
                }
            }
            else
            {
                return View(route);
            }

        }


        
        public ActionResult DeleteRoute(int IDRoute)
        {
            try
            {
                Repo.DeleteRoute(IDRoute);
                return Redirect(Request.UrlReferrer.ToString());
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.StackTrace;
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult EditRoute(int IDRoute)
        {
            try
            {
                Route r = Repo.GetRoute(IDRoute);
                return View(r);
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.StackTrace;
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult EditRoute(Route r)
        {
            try
            {
                Repo.EditRoute(r.TravelInfoID,r);
                ViewBag.message = "Route succesfully updated";
                return View("Confirmation");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.StackTrace;
                return View("Error");
            }
        }
        public ActionResult DeleteRoutes(int IDTravelWarrant)
        {
            try
            {
                List<Route> routes = Repo.GetRoutesForTravelWarrant(IDTravelWarrant);

                foreach (Route route in routes)
                {
                    Repo.DeleteRoute(route.IDRoute);
                }
                

                return Redirect(Request.UrlReferrer.ToString());
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.StackTrace;
                return View("Error");
            }
        }

        
        public ActionResult BackupDatabase()
        {
            try
            {
                Repo.BackupDatabase();
                ViewBag.message = " Database Backup succesfull";
                return View("Confirmation");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.StackTrace;
                return View("Error");
            }
        }

        public ActionResult ClearDatabase()
        {
            try
            {
                Repo.ClearDatabase();
                ViewBag.message = " Database Cleared succesfully";
                return View("Confirmation");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.StackTrace;
                return View("Error");
            }
        }

        public ActionResult RestoreDatabase()
        {
            try
            {
                Repo.RestoreDatabase();
                ViewBag.message = " Database restored";
                return View("Confirmation");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.StackTrace;
                return View("Error");
            }
        }

      



    }
}
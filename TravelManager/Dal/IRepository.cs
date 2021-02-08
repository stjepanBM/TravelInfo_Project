using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManager.Models;

namespace TravelManager.Dal
{
   public interface IRepository
    {

        List<Driver> GetDrivers();
        void InsertDriver(Driver model);
        int UpdateDriver(Driver model);
        Driver GetDriver(int iDDriver);
        int DeleteDriver(int iDDriver);
        Car GetCar(int iDCar);
        List<Car> GetCars();
        int UpdateCar(Car car);
        int InsertCar(Car car);
        void InsertTravelWarrant(TravelWarrant model);
        List<City> GetCities();
        List<TravelWarrant> GetTravelWarrant();
        List<TravelWarrant> GetDriversTravelWarrant(int iDDriver);
        int DeleteTravelWarrant(int iDTravelWarrant);
        int DeleteCar(int iDCar);
        void CreateXml();
        TravelWarrant GetTravelWarrant(int iDTravelWarrant);
        List<Route> GetRoutesForTravelWarrant(int iDTravelWarrant);
        void DeleteRoute(int iDRoute);
        int InsertRoute(Route route);
        void ImportXml();
        void EditRoute(int iDTravelWarrant,Route r);
        Route GetRoute(int iDRoute);
        void BackupDatabase();
        void ClearDatabase();
        void RestoreDatabase();
    }
}

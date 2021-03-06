﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CustomCar
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {

        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<TravelInfo> TravelInfo { get; set; }
    
        public virtual int addRoute(string time, string coordinatesALength, string coordinatesAWidth, string coordinatesBLength, string coordinatesBWidth, Nullable<int> travelLength, Nullable<int> averageSpeed, Nullable<int> fuelConsumption, Nullable<int> travelInfoID)
        {
            var timeParameter = time != null ?
                new ObjectParameter("Time", time) :
                new ObjectParameter("Time", typeof(string));
    
            var coordinatesALengthParameter = coordinatesALength != null ?
                new ObjectParameter("CoordinatesALength", coordinatesALength) :
                new ObjectParameter("CoordinatesALength", typeof(string));
    
            var coordinatesAWidthParameter = coordinatesAWidth != null ?
                new ObjectParameter("CoordinatesAWidth", coordinatesAWidth) :
                new ObjectParameter("CoordinatesAWidth", typeof(string));
    
            var coordinatesBLengthParameter = coordinatesBLength != null ?
                new ObjectParameter("CoordinatesBLength", coordinatesBLength) :
                new ObjectParameter("CoordinatesBLength", typeof(string));
    
            var coordinatesBWidthParameter = coordinatesBWidth != null ?
                new ObjectParameter("CoordinatesBWidth", coordinatesBWidth) :
                new ObjectParameter("CoordinatesBWidth", typeof(string));
    
            var travelLengthParameter = travelLength.HasValue ?
                new ObjectParameter("TravelLength", travelLength) :
                new ObjectParameter("TravelLength", typeof(int));
    
            var averageSpeedParameter = averageSpeed.HasValue ?
                new ObjectParameter("AverageSpeed", averageSpeed) :
                new ObjectParameter("AverageSpeed", typeof(int));
    
            var fuelConsumptionParameter = fuelConsumption.HasValue ?
                new ObjectParameter("FuelConsumption", fuelConsumption) :
                new ObjectParameter("FuelConsumption", typeof(int));
    
            var travelInfoIDParameter = travelInfoID.HasValue ?
                new ObjectParameter("TravelInfoID", travelInfoID) :
                new ObjectParameter("TravelInfoID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addRoute", timeParameter, coordinatesALengthParameter, coordinatesAWidthParameter, coordinatesBLengthParameter, coordinatesBWidthParameter, travelLengthParameter, averageSpeedParameter, fuelConsumptionParameter, travelInfoIDParameter);
        }
    
        public virtual int cleanDatabase()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("cleanDatabase");
        }
    
        public virtual int deleteCar(Nullable<int> iDCar)
        {
            var iDCarParameter = iDCar.HasValue ?
                new ObjectParameter("IDCar", iDCar) :
                new ObjectParameter("IDCar", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteCar", iDCarParameter);
        }
    
        public virtual int deleteCity(Nullable<int> iDCity)
        {
            var iDCityParameter = iDCity.HasValue ?
                new ObjectParameter("IDCity", iDCity) :
                new ObjectParameter("IDCity", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteCity", iDCityParameter);
        }
    
        public virtual int deleteDriver(Nullable<int> iDDriver)
        {
            var iDDriverParameter = iDDriver.HasValue ?
                new ObjectParameter("IDDriver", iDDriver) :
                new ObjectParameter("IDDriver", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteDriver", iDDriverParameter);
        }
    
        public virtual int deleteRoute(Nullable<int> iDRoute)
        {
            var iDRouteParameter = iDRoute.HasValue ?
                new ObjectParameter("IDRoute", iDRoute) :
                new ObjectParameter("IDRoute", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteRoute", iDRouteParameter);
        }
    
        public virtual int deleteTravelInfo(Nullable<int> iDTravelInfo)
        {
            var iDTravelInfoParameter = iDTravelInfo.HasValue ?
                new ObjectParameter("IDTravelInfo", iDTravelInfo) :
                new ObjectParameter("IDTravelInfo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteTravelInfo", iDTravelInfoParameter);
        }
    
        public virtual ObjectResult<getCar_Result> getCar(Nullable<int> iDCar)
        {
            var iDCarParameter = iDCar.HasValue ?
                new ObjectParameter("IDCar", iDCar) :
                new ObjectParameter("IDCar", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getCar_Result>("getCar", iDCarParameter);
        }
    
        public virtual ObjectResult<getCars_Result> getCars()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getCars_Result>("getCars");
        }
    
        public virtual ObjectResult<getCities_Result> getCities()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getCities_Result>("getCities");
        }
    
        public virtual ObjectResult<getCity_Result> getCity(Nullable<int> iDCity)
        {
            var iDCityParameter = iDCity.HasValue ?
                new ObjectParameter("IDCity", iDCity) :
                new ObjectParameter("IDCity", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getCity_Result>("getCity", iDCityParameter);
        }
    
        public virtual ObjectResult<getDriver_Result> getDriver(Nullable<int> iDDriver)
        {
            var iDDriverParameter = iDDriver.HasValue ?
                new ObjectParameter("IDDriver", iDDriver) :
                new ObjectParameter("IDDriver", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getDriver_Result>("getDriver", iDDriverParameter);
        }
    
        public virtual ObjectResult<getDrivers_Result> getDrivers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getDrivers_Result>("getDrivers");
        }
    
        public virtual ObjectResult<getDriversTravelInfo_Result> getDriversTravelInfo(Nullable<int> iDDriver)
        {
            var iDDriverParameter = iDDriver.HasValue ?
                new ObjectParameter("IDDriver", iDDriver) :
                new ObjectParameter("IDDriver", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getDriversTravelInfo_Result>("getDriversTravelInfo", iDDriverParameter);
        }
    
        public virtual ObjectResult<getRoute_Result> getRoute(Nullable<int> iDRoute)
        {
            var iDRouteParameter = iDRoute.HasValue ?
                new ObjectParameter("IDRoute", iDRoute) :
                new ObjectParameter("IDRoute", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getRoute_Result>("getRoute", iDRouteParameter);
        }
    
        public virtual ObjectResult<getRouteForTravelWarrant_Result> getRouteForTravelWarrant(Nullable<int> iDTravelWarrant)
        {
            var iDTravelWarrantParameter = iDTravelWarrant.HasValue ?
                new ObjectParameter("IDTravelWarrant", iDTravelWarrant) :
                new ObjectParameter("IDTravelWarrant", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getRouteForTravelWarrant_Result>("getRouteForTravelWarrant", iDTravelWarrantParameter);
        }
    
        public virtual ObjectResult<getTravelInfo_Result> getTravelInfo()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getTravelInfo_Result>("getTravelInfo");
        }
    
        public virtual ObjectResult<getTravelWarrant_Result> getTravelWarrant(Nullable<int> iDTravelWarrant)
        {
            var iDTravelWarrantParameter = iDTravelWarrant.HasValue ?
                new ObjectParameter("IDTravelWarrant", iDTravelWarrant) :
                new ObjectParameter("IDTravelWarrant", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getTravelWarrant_Result>("getTravelWarrant", iDTravelWarrantParameter);
        }
    
        public virtual int insertCar(string carType, string brand, Nullable<int> yearOdMaking, Nullable<int> mileage, Nullable<bool> carReserved)
        {
            var carTypeParameter = carType != null ?
                new ObjectParameter("CarType", carType) :
                new ObjectParameter("CarType", typeof(string));
    
            var brandParameter = brand != null ?
                new ObjectParameter("Brand", brand) :
                new ObjectParameter("Brand", typeof(string));
    
            var yearOdMakingParameter = yearOdMaking.HasValue ?
                new ObjectParameter("YearOdMaking", yearOdMaking) :
                new ObjectParameter("YearOdMaking", typeof(int));
    
            var mileageParameter = mileage.HasValue ?
                new ObjectParameter("Mileage", mileage) :
                new ObjectParameter("Mileage", typeof(int));
    
            var carReservedParameter = carReserved.HasValue ?
                new ObjectParameter("CarReserved", carReserved) :
                new ObjectParameter("CarReserved", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertCar", carTypeParameter, brandParameter, yearOdMakingParameter, mileageParameter, carReservedParameter);
        }
    
        public virtual int insertCity(string cityName, Nullable<int> stateID)
        {
            var cityNameParameter = cityName != null ?
                new ObjectParameter("CityName", cityName) :
                new ObjectParameter("CityName", typeof(string));
    
            var stateIDParameter = stateID.HasValue ?
                new ObjectParameter("StateID", stateID) :
                new ObjectParameter("StateID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertCity", cityNameParameter, stateIDParameter);
        }
    
        public virtual int insertDriver(string driverName, string driverSurname, string telephone, Nullable<int> licenceNumber)
        {
            var driverNameParameter = driverName != null ?
                new ObjectParameter("DriverName", driverName) :
                new ObjectParameter("DriverName", typeof(string));
    
            var driverSurnameParameter = driverSurname != null ?
                new ObjectParameter("DriverSurname", driverSurname) :
                new ObjectParameter("DriverSurname", typeof(string));
    
            var telephoneParameter = telephone != null ?
                new ObjectParameter("Telephone", telephone) :
                new ObjectParameter("Telephone", typeof(string));
    
            var licenceNumberParameter = licenceNumber.HasValue ?
                new ObjectParameter("LicenceNumber", licenceNumber) :
                new ObjectParameter("LicenceNumber", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertDriver", driverNameParameter, driverSurnameParameter, telephoneParameter, licenceNumberParameter);
        }
    
        public virtual int insertTravelInfo(string status, Nullable<int> driverID, Nullable<double> travelLength, Nullable<int> daysExcpected, Nullable<int> startCity, Nullable<int> stopCity, Nullable<int> carID)
        {
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            var driverIDParameter = driverID.HasValue ?
                new ObjectParameter("DriverID", driverID) :
                new ObjectParameter("DriverID", typeof(int));
    
            var travelLengthParameter = travelLength.HasValue ?
                new ObjectParameter("TravelLength", travelLength) :
                new ObjectParameter("TravelLength", typeof(double));
    
            var daysExcpectedParameter = daysExcpected.HasValue ?
                new ObjectParameter("DaysExcpected", daysExcpected) :
                new ObjectParameter("DaysExcpected", typeof(int));
    
            var startCityParameter = startCity.HasValue ?
                new ObjectParameter("StartCity", startCity) :
                new ObjectParameter("StartCity", typeof(int));
    
            var stopCityParameter = stopCity.HasValue ?
                new ObjectParameter("StopCity", stopCity) :
                new ObjectParameter("StopCity", typeof(int));
    
            var carIDParameter = carID.HasValue ?
                new ObjectParameter("CarID", carID) :
                new ObjectParameter("CarID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertTravelInfo", statusParameter, driverIDParameter, travelLengthParameter, daysExcpectedParameter, startCityParameter, stopCityParameter, carIDParameter);
        }
    
        public virtual int updateCar(Nullable<int> iDCar, string carType, string brand, Nullable<int> yearOfMaking, Nullable<int> mileage, Nullable<bool> carReserved)
        {
            var iDCarParameter = iDCar.HasValue ?
                new ObjectParameter("IDCar", iDCar) :
                new ObjectParameter("IDCar", typeof(int));
    
            var carTypeParameter = carType != null ?
                new ObjectParameter("CarType", carType) :
                new ObjectParameter("CarType", typeof(string));
    
            var brandParameter = brand != null ?
                new ObjectParameter("Brand", brand) :
                new ObjectParameter("Brand", typeof(string));
    
            var yearOfMakingParameter = yearOfMaking.HasValue ?
                new ObjectParameter("YearOfMaking", yearOfMaking) :
                new ObjectParameter("YearOfMaking", typeof(int));
    
            var mileageParameter = mileage.HasValue ?
                new ObjectParameter("Mileage", mileage) :
                new ObjectParameter("Mileage", typeof(int));
    
            var carReservedParameter = carReserved.HasValue ?
                new ObjectParameter("CarReserved", carReserved) :
                new ObjectParameter("CarReserved", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateCar", iDCarParameter, carTypeParameter, brandParameter, yearOfMakingParameter, mileageParameter, carReservedParameter);
        }
    
        public virtual int updateCity(Nullable<int> iDCity, string cityName, Nullable<int> stateID)
        {
            var iDCityParameter = iDCity.HasValue ?
                new ObjectParameter("IDCity", iDCity) :
                new ObjectParameter("IDCity", typeof(int));
    
            var cityNameParameter = cityName != null ?
                new ObjectParameter("CityName", cityName) :
                new ObjectParameter("CityName", typeof(string));
    
            var stateIDParameter = stateID.HasValue ?
                new ObjectParameter("StateID", stateID) :
                new ObjectParameter("StateID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateCity", iDCityParameter, cityNameParameter, stateIDParameter);
        }
    
        public virtual int updateDriver(Nullable<int> iDDriver, string driverName, string driverSurname, string telephone, Nullable<int> licenceNumber)
        {
            var iDDriverParameter = iDDriver.HasValue ?
                new ObjectParameter("IDDriver", iDDriver) :
                new ObjectParameter("IDDriver", typeof(int));
    
            var driverNameParameter = driverName != null ?
                new ObjectParameter("DriverName", driverName) :
                new ObjectParameter("DriverName", typeof(string));
    
            var driverSurnameParameter = driverSurname != null ?
                new ObjectParameter("DriverSurname", driverSurname) :
                new ObjectParameter("DriverSurname", typeof(string));
    
            var telephoneParameter = telephone != null ?
                new ObjectParameter("Telephone", telephone) :
                new ObjectParameter("Telephone", typeof(string));
    
            var licenceNumberParameter = licenceNumber.HasValue ?
                new ObjectParameter("LicenceNumber", licenceNumber) :
                new ObjectParameter("LicenceNumber", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateDriver", iDDriverParameter, driverNameParameter, driverSurnameParameter, telephoneParameter, licenceNumberParameter);
        }
    
        public virtual int updateRoute(Nullable<int> iDRoute, string time, string coordinatesALength, string coordinatesAWidth, string coordinatesBLength, string coordinatesBWidth, Nullable<int> travelLength, Nullable<int> averageSpeed, Nullable<int> fuelConsumption, Nullable<int> travelInfoID)
        {
            var iDRouteParameter = iDRoute.HasValue ?
                new ObjectParameter("IDRoute", iDRoute) :
                new ObjectParameter("IDRoute", typeof(int));
    
            var timeParameter = time != null ?
                new ObjectParameter("Time", time) :
                new ObjectParameter("Time", typeof(string));
    
            var coordinatesALengthParameter = coordinatesALength != null ?
                new ObjectParameter("CoordinatesALength", coordinatesALength) :
                new ObjectParameter("CoordinatesALength", typeof(string));
    
            var coordinatesAWidthParameter = coordinatesAWidth != null ?
                new ObjectParameter("CoordinatesAWidth", coordinatesAWidth) :
                new ObjectParameter("CoordinatesAWidth", typeof(string));
    
            var coordinatesBLengthParameter = coordinatesBLength != null ?
                new ObjectParameter("CoordinatesBLength", coordinatesBLength) :
                new ObjectParameter("CoordinatesBLength", typeof(string));
    
            var coordinatesBWidthParameter = coordinatesBWidth != null ?
                new ObjectParameter("CoordinatesBWidth", coordinatesBWidth) :
                new ObjectParameter("CoordinatesBWidth", typeof(string));
    
            var travelLengthParameter = travelLength.HasValue ?
                new ObjectParameter("TravelLength", travelLength) :
                new ObjectParameter("TravelLength", typeof(int));
    
            var averageSpeedParameter = averageSpeed.HasValue ?
                new ObjectParameter("AverageSpeed", averageSpeed) :
                new ObjectParameter("AverageSpeed", typeof(int));
    
            var fuelConsumptionParameter = fuelConsumption.HasValue ?
                new ObjectParameter("FuelConsumption", fuelConsumption) :
                new ObjectParameter("FuelConsumption", typeof(int));
    
            var travelInfoIDParameter = travelInfoID.HasValue ?
                new ObjectParameter("TravelInfoID", travelInfoID) :
                new ObjectParameter("TravelInfoID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateRoute", iDRouteParameter, timeParameter, coordinatesALengthParameter, coordinatesAWidthParameter, coordinatesBLengthParameter, coordinatesBWidthParameter, travelLengthParameter, averageSpeedParameter, fuelConsumptionParameter, travelInfoIDParameter);
        }
    
        public virtual int updateTravelInfo(Nullable<int> iDTravel, string status, Nullable<int> driverID, Nullable<double> travelLength, Nullable<int> daysExcpected, Nullable<int> startCity, Nullable<int> stopCity, Nullable<int> carID)
        {
            var iDTravelParameter = iDTravel.HasValue ?
                new ObjectParameter("IDTravel", iDTravel) :
                new ObjectParameter("IDTravel", typeof(int));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            var driverIDParameter = driverID.HasValue ?
                new ObjectParameter("DriverID", driverID) :
                new ObjectParameter("DriverID", typeof(int));
    
            var travelLengthParameter = travelLength.HasValue ?
                new ObjectParameter("TravelLength", travelLength) :
                new ObjectParameter("TravelLength", typeof(double));
    
            var daysExcpectedParameter = daysExcpected.HasValue ?
                new ObjectParameter("DaysExcpected", daysExcpected) :
                new ObjectParameter("DaysExcpected", typeof(int));
    
            var startCityParameter = startCity.HasValue ?
                new ObjectParameter("StartCity", startCity) :
                new ObjectParameter("StartCity", typeof(int));
    
            var stopCityParameter = stopCity.HasValue ?
                new ObjectParameter("StopCity", stopCity) :
                new ObjectParameter("StopCity", typeof(int));
    
            var carIDParameter = carID.HasValue ?
                new ObjectParameter("CarID", carID) :
                new ObjectParameter("CarID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateTravelInfo", iDTravelParameter, statusParameter, driverIDParameter, travelLengthParameter, daysExcpectedParameter, startCityParameter, stopCityParameter, carIDParameter);
        }
    
        public virtual int insertService(string name, Nullable<System.DateTime> dateOfService, Nullable<int> price, Nullable<int> carID)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var dateOfServiceParameter = dateOfService.HasValue ?
                new ObjectParameter("DateOfService", dateOfService) :
                new ObjectParameter("DateOfService", typeof(System.DateTime));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(int));
    
            var carIDParameter = carID.HasValue ?
                new ObjectParameter("CarID", carID) :
                new ObjectParameter("CarID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertService", nameParameter, dateOfServiceParameter, priceParameter, carIDParameter);
        }
    
        public virtual ObjectResult<getService_Result> getService()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getService_Result>("getService");
        }
    }
}

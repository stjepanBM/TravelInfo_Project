using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Web;
using TravelManager.Models;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using System.Xml;
using System.Globalization;

namespace TravelManager.Dal
{
    public class SqlRepository : IRepository
    {
        private const string SELECT_DRIVER = "select * from Driver";
        private const string INSERT_DRIVER = "insert into Driver values(@DriverName,@DriverSurname,@Telephone,@LicenceNumber)";
        private const string DELETE_DRIVER =
            "update Fuel set DriverID = null where DriverID = @IDDriver " +
            "update TravelInfo set DriverID = null where DriverID = @IDDriver " +
            "delete from Driver where IDDriver = @IDDriver";
        private const string UPDATE_DRIVER = "update Driver set DriverName = @DriverName, DriverSurname = @DriverSurname, Telephone = @Telephone, LicenceNumber = @LicenceNumber where IDDriver = @IDDriver";
        private const string DRIVER_NAME = "@DriverName";
        private const string DRIVER_SURNAME = "@DriverSurname";
        private const string LICENCE_NUMBER = "@LicenceNumber";
        private const string TELEPHONE = "@Telephone";
        private const string ID_DRIVER = "@IDDriver";
        private const string ID_TRAVEL_WARRANT = "@IDTravelWarrant";
        private const string GET_CARS = "getCars";
        private const string GET_DRIVER = "select * from Driver where IDDriver = @IDDriver";
        private const string GET_CAR = "getCar";
        private const string ID_CAR = "@IDCar";
        private const string CAR_TYPE = "@CarType";
        private const string BRAND = "@Brand";
        private const string YEAR_OF_MAKING = "@YearOfMaking";
        private const string CAR_RESERVED = "@CarReserved";
        private const string MILEAGE = "@Mileage";
        private const string UPDATE_CAR = "updateCar";
        private const string INSERT_CAR = "insertCar";
        private const string GET_DRIVERS_TRAVELWARRANT = "getDriversTravelInfo";
        private const string DELETE_CAR = "deleteCar";
        private const string GET_TRAVEL_INFO = "getTravelInfo";
        private const string ADD_ROUTE = "addRoute";
        private const string GET_TRAVEL_WARRANT = "getTravelWarrant";
        private const string GET_ROUTES_TRAVELWARRANT = "getRouteForTravelWarrant";
        private const string ID_ROUTE = "@IDRoute";
        private const string DELETE_ROUTE = "deleteRoute";

        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;


        public List<Driver> GetDrivers()
        {
            List<Driver> drivers = new List<Driver>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = SELECT_DRIVER;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {

                            drivers.Add(new Driver
                            {
                                IDDriver = (int)r[nameof(Driver.IDDriver)],
                                DriverName = r[nameof(Driver.DriverName)].ToString(),
                                DriverSurname = r[nameof(Driver.DriverSurname)].ToString(),
                                LicenceNumber = (int)r[nameof(Driver.LicenceNumber)],
                                Telephone = r[nameof(Driver.Telephone)].ToString()
                            });
                        }
                    }
                }
            }
            return drivers;
        }

        public void InsertDriver(Driver model)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = INSERT_DRIVER;
                    cmd.Parameters.AddWithValue(DRIVER_NAME, model.DriverName);
                    cmd.Parameters.AddWithValue(DRIVER_SURNAME, model.DriverSurname);
                    cmd.Parameters.AddWithValue(TELEPHONE, model.Telephone);
                    cmd.Parameters.AddWithValue(LICENCE_NUMBER, model.LicenceNumber);
                    cmd.ExecuteNonQuery();

                }
            }
        }




        public int UpdateDriver(Driver model)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = UPDATE_DRIVER;
                    cmd.Parameters.AddWithValue(ID_DRIVER, model.IDDriver);
                    cmd.Parameters.AddWithValue(DRIVER_NAME, model.DriverName);
                    cmd.Parameters.AddWithValue(DRIVER_SURNAME, model.DriverSurname);
                    cmd.Parameters.AddWithValue(TELEPHONE, model.Telephone);
                    cmd.Parameters.AddWithValue(LICENCE_NUMBER, model.LicenceNumber);
                    return cmd.ExecuteNonQuery();

                }
            }
        }

        public Driver GetDriver(int iDDriver)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = GET_DRIVER;
                    cmd.Parameters.AddWithValue(ID_DRIVER, iDDriver);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            return new Driver
                            {
                                IDDriver = (int)r[nameof(Driver.IDDriver)],
                                DriverName = r[nameof(Driver.DriverName)].ToString(),
                                DriverSurname = r[nameof(Driver.DriverSurname)].ToString(),
                                Telephone = r[nameof(Driver.Telephone)].ToString(),
                                LicenceNumber = (int)r[nameof(Driver.LicenceNumber)]
                            };
                        }
                    }
                }
            }
            return null;
        }

        public int DeleteDriver(int iDDriver)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = DELETE_DRIVER;
                    cmd.Parameters.AddWithValue(ID_DRIVER, iDDriver);

                    return cmd.ExecuteNonQuery();

                }
            }
        }
        private void Con_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {

        }


        //CARS DATABASE PROCEDURES

        public List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = GET_CARS;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            cars.Add(new Car
                            {
                                IDCar = (int)r[nameof(Car.IDCar)],
                                CarType = r[nameof(Car.CarType)].ToString(),
                                Brand = r[nameof(Car.Brand)].ToString(),
                                YearOfMaking = (int)r[nameof(Car.YearOfMaking)],
                                Mileage = (int)r[nameof(Car.Mileage)],
                                CarReserved = (bool)r[nameof(Car.CarReserved)]
                            });
                        }
                    }
                }
            }
            return cars;
        }

        public Car GetCar(int iDCar)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = GET_CAR;
                    cmd.Parameters.AddWithValue("@IDCar", iDCar);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            return new Car
                            {
                                IDCar = (int)r[nameof(Car.IDCar)],
                                CarType = r[nameof(Car.CarType)].ToString(),
                                Brand = r[nameof(Car.Brand)].ToString(),
                                YearOfMaking = (int)r[nameof(Car.YearOfMaking)],
                                Mileage = (int)r[nameof(Car.Mileage)],
                                CarReserved = (bool)r[nameof(Car.CarReserved)]
                            };
                        }
                    }
                }
            }
            return null;
        }

        public int UpdateCar(Car car)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = UPDATE_CAR;
                    cmd.Parameters.AddWithValue(ID_CAR, car.IDCar);
                    cmd.Parameters.AddWithValue(CAR_TYPE, car.CarType);
                    cmd.Parameters.AddWithValue(BRAND, car.Brand);
                    cmd.Parameters.AddWithValue(YEAR_OF_MAKING, car.YearOfMaking);
                    cmd.Parameters.AddWithValue(MILEAGE, car.Mileage);
                    cmd.Parameters.AddWithValue(CAR_RESERVED, car.CarReserved);
                    return cmd.ExecuteNonQuery();

                }
            }
        }

        public int InsertCar(Car car)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = INSERT_CAR;
                    cmd.Parameters.AddWithValue(CAR_TYPE, car.CarType);
                    cmd.Parameters.AddWithValue(BRAND, car.Brand);
                    cmd.Parameters.AddWithValue(YEAR_OF_MAKING, car.YearOfMaking);
                    cmd.Parameters.AddWithValue(MILEAGE, car.Mileage);
                    cmd.Parameters.AddWithValue(CAR_RESERVED, car.CarReserved);
                    return cmd.ExecuteNonQuery();

                }
            }
        }

        public void InsertTravelWarrant(TravelWarrant model)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "insertTravelInfo";
                    cmd.Parameters.AddWithValue("@Status", model.Status);
                    cmd.Parameters.AddWithValue("@DriverID", model.DriverID);
                    cmd.Parameters.AddWithValue("@TravelLength", model.TravelLength);
                    cmd.Parameters.AddWithValue("@DaysExcpected", model.DaysExpected);
                    cmd.Parameters.AddWithValue("@StartCity", model.StartCity);
                    cmd.Parameters.AddWithValue("@StopCity", model.StopCity);
                    cmd.Parameters.AddWithValue("@CarID", model.CarID);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public List<City> GetCities()
        {
            List<City> cities = new List<City>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "getCities";
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            cities.Add(new City
                            {
                                IDCity = (int)r[nameof(City.IDCity)],
                                CityName = r[nameof(City.CityName)].ToString(),
                                StateID = (int)r[nameof(City.StateID)]
                            });

                        }
                    }
                }
            }
            return cities;
        }

        public List<TravelWarrant> GetTravelWarrant()
        {
            List<TravelWarrant> warrants = new List<TravelWarrant>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = GET_TRAVEL_INFO;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            warrants.Add(new TravelWarrant
                            {
                                IDTravelInfo = (int)r[nameof(TravelWarrant.IDTravelInfo)],
                                Status = r[nameof(TravelWarrant.Status)].ToString(),
                                DriverID = (int)r[nameof(TravelWarrant.DriverID)],
                                TravelLength = float.Parse(r[nameof(TravelWarrant.TravelLength)].ToString()),
                                DaysExpected = (int)r[nameof(TravelWarrant.DaysExpected)],
                                StartCity = (int)r[nameof(TravelWarrant.StartCity)],
                                StopCity = (int)r[nameof(TravelWarrant.StopCity)],
                                CarID = (int)r[nameof(TravelWarrant.CarID)]
                            });
                        }
                    }
                }
            }
            return warrants;
        }

        public List<TravelWarrant> GetDriversTravelWarrant(int iDDriver)
        {
            List<TravelWarrant> warrants = new List<TravelWarrant>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = GET_DRIVERS_TRAVELWARRANT;
                    cmd.Parameters.AddWithValue(ID_DRIVER, iDDriver);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            warrants.Add(new TravelWarrant
                            {
                                IDTravelInfo = (int)r[nameof(TravelWarrant.IDTravelInfo)],
                                Status = r[nameof(TravelWarrant.Status)].ToString(),
                                TravelLength = float.Parse(r[nameof(TravelWarrant.TravelLength)].ToString()),
                                DaysExpected = (int)r[nameof(TravelWarrant.DaysExpected)],
                                StartCity = (int)r[nameof(TravelWarrant.StartCity)],
                                StopCity = (int)r[nameof(TravelWarrant.StopCity)],
                                CarID = (int)r[nameof(TravelWarrant.CarID)]
                            });
                        }
                    }
                }
            }
            return warrants;
        }

        public int DeleteTravelWarrant(int iDTravelWarrant)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "deleteTravelInfo";
                    cmd.Parameters.AddWithValue("@IDTravelInfo", iDTravelWarrant);

                    return cmd.ExecuteNonQuery();

                }
            }
        }

        public int DeleteCar(int iDCar)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = DELETE_CAR;
                    cmd.Parameters.AddWithValue(ID_CAR, iDCar);

                    return cmd.ExecuteNonQuery();

                }
            }
        }

        public void CreateXml()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TravelInfo;SELECT * FROM Route", con);

            DataSet ds = new DataSet("TravelWarrant");
            da.Fill(ds);

            ds.Tables[0].TableName = "TravelInfo";
            ds.Tables[1].TableName = "Route";


            DataRelation relacija = new DataRelation("relacijaVozac", ds.Tables[0].Columns["IDTravelInfo"], ds.Tables[1].Columns["TravelInfoID"]);
            relacija.Nested = true;

            ds.Relations.Add(relacija);
            ds.WriteXml(HttpContext.Current.Server.MapPath("~/App_Data/TravelInfo.xml"), XmlWriteMode.WriteSchema);
        }


        public void ImportXml()
        {

            DataSet ds = new DataSet();

            ds.ReadXml(HttpContext.Current.Server.MapPath("~/App_Data/TravelInfo.xml"));

            foreach (DataRow travelInfo in ds.Tables["Route"].Rows)
            {

                List<Route> routes = GetRoutesForTravelWarrant(int.Parse(travelInfo["TravelInfoID"].ToString()));


                Route r = new Route();
                r.Time = travelInfo["Time"].ToString();
                r.CoordinatesALength = travelInfo["CoordinatesALength"].ToString();
                r.CoordinatesBLength = travelInfo["CoordinatesBLength"].ToString();
                r.CoordinatesAWidth = travelInfo["CoordinatesAWidth"].ToString();
                r.CoordinatesBWidth = travelInfo["CoordinatesBWidth"].ToString();
                r.TravelLength = int.Parse(travelInfo["TravelLength"].ToString());
                r.AverageSpeed = int.Parse(travelInfo["AverageSpeed"].ToString());
                r.FuelConsumption = int.Parse(travelInfo["FuelConsumption"].ToString());
                r.TravelInfoID = int.Parse(travelInfo["TravelInfoID"].ToString());

                if (!routes.Exists(x => x.TravelInfoID == r.TravelInfoID))
                {
                    InsertRoute(r);
                }
            }
        }

        public TravelWarrant GetTravelWarrant(int iDTravelWarrant)
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = GET_TRAVEL_WARRANT;
                    cmd.Parameters.AddWithValue(ID_TRAVEL_WARRANT, iDTravelWarrant);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            return new TravelWarrant
                            {
                                IDTravelInfo = (int)r[nameof(TravelWarrant.IDTravelInfo)],
                                Status = r[nameof(TravelWarrant.Status)].ToString(),
                                TravelLength = float.Parse(r[nameof(TravelWarrant.TravelLength)].ToString()),
                                DaysExpected = (int)r[nameof(TravelWarrant.DaysExpected)],
                                StartCity = (int)r[nameof(TravelWarrant.StartCity)],
                                StopCity = (int)r[nameof(TravelWarrant.StopCity)],
                                CarID = (int)r[nameof(TravelWarrant.CarID)],
                                DriverID = (int)r[nameof(TravelWarrant.DriverID)]
                            };
                        }
                    }
                }
            }
            return null;
        }

        public Route GetRouteForTravelWarrant(int iDTravelWarrant)
        {
            List<Route> routes = new List<Route>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = GET_ROUTES_TRAVELWARRANT;
                    cmd.Parameters.AddWithValue(ID_TRAVEL_WARRANT, iDTravelWarrant);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            new Route
                            {
                                IDRoute = (int)r[nameof(Route.IDRoute)],
                                Time = r[nameof(Route.Time)].ToString(),
                                CoordinatesALength = r[nameof(Route.CoordinatesALength)].ToString(),
                                CoordinatesBLength = r[nameof(Route.CoordinatesBLength)].ToString(),
                                CoordinatesAWidth = r[nameof(Route.CoordinatesAWidth)].ToString(),
                                CoordinatesBWidth = r[nameof(Route.CoordinatesBWidth)].ToString(),
                                TravelLength = (int)r[nameof(Route.TravelLength)],
                                AverageSpeed = (int)r[nameof(Route.AverageSpeed)],
                                FuelConsumption = (int)r[nameof(Route.FuelConsumption)],
                                TravelInfoID = (int)r[nameof(Route.TravelInfoID)]
                            };
                        }
                    }
                }
            }
            return null;
        }


        public List<Route> GetRoutesForTravelWarrant(int iDTravelWarrant)
        {
            List<Route> routes = new List<Route>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = GET_ROUTES_TRAVELWARRANT;
                    cmd.Parameters.AddWithValue(ID_TRAVEL_WARRANT, iDTravelWarrant);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            routes.Add(new Route
                            {
                                IDRoute = (int)r[nameof(Route.IDRoute)],
                                Time = r[nameof(Route.Time)].ToString(),
                                CoordinatesALength = r[nameof(Route.CoordinatesALength)].ToString(),
                                CoordinatesBLength = r[nameof(Route.CoordinatesBLength)].ToString(),
                                CoordinatesAWidth = r[nameof(Route.CoordinatesAWidth)].ToString(),
                                CoordinatesBWidth = r[nameof(Route.CoordinatesBWidth)].ToString(),
                                TravelLength = (int)r[nameof(Route.TravelLength)],
                                AverageSpeed = (int)r[nameof(Route.AverageSpeed)],
                                FuelConsumption = (int)r[nameof(Route.FuelConsumption)],
                                TravelInfoID = (int)r[nameof(Route.TravelInfoID)]
                            });
                        }
                    }
                }
            }
            return routes;
        }

        public void DeleteRoute(int iDRoute)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {


                SqlHelper.ExecuteNonQuery(cs, DELETE_ROUTE, iDRoute);



                //Klasicno brisanje
                //con.Open();
                //con.FireInfoMessageEventOnUserErrors = true;
                //con.InfoMessage += Con_InfoMessage;
                //using (SqlCommand cmd = con.CreateCommand())
                //{
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    cmd.CommandText = DELETE_ROUTE;
                //    cmd.Parameters.AddWithValue(ID_ROUTE, iDRoute);
                //    cmd.ExecuteNonQuery();
                //}
            }
        }

        public int InsertRoute(Route r)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                return SqlHelper.ExecuteNonQuery(cs, ADD_ROUTE, r.Time, r.CoordinatesALength, r.CoordinatesAWidth, r.CoordinatesBLength, r.CoordinatesBWidth, r.TravelLength, r.AverageSpeed, r.FuelConsumption, r.TravelInfoID);

                //KLASICNO DODAVANJE RUTE

                //con.Open();
                //con.FireInfoMessageEventOnUserErrors = true;
                //con.InfoMessage += Con_InfoMessage;
                //using (SqlCommand cmd = con.CreateCommand())
                //{
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    cmd.CommandText = ADD_ROUTE;
                //    cmd.Parameters.AddWithValue("@Time", route.Time);
                //    cmd.Parameters.AddWithValue("@CoordinatesALength", route.CoordinatesALength);
                //    cmd.Parameters.AddWithValue("@CoordinatesAWidth", route.CoordinatesAWidth);
                //    cmd.Parameters.AddWithValue("@CoordinatesBLength", route.CoordinatesBLength);
                //    cmd.Parameters.AddWithValue("@CoordinatesBWidth", route.CoordinatesBWidth);
                //    cmd.Parameters.AddWithValue("@TravelLength", route.TravelLength);
                //    cmd.Parameters.AddWithValue("@AverageSpeed", route.AverageSpeed);
                //    cmd.Parameters.AddWithValue("@FuelConsumption", route.FuelConsumption);
                //    cmd.Parameters.AddWithValue("@TravelInfoID", route.TravelInfoID);
                //    return cmd.ExecuteNonQuery();
                //}
            }
        }

        public void EditRoute(int iDTravelWarrant, Route r)
        {
            SqlHelper.ExecuteNonQuery(cs, "updateRoute", r.IDRoute, r.Time, r.CoordinatesALength, r.CoordinatesAWidth, r.CoordinatesBLength, r.CoordinatesBWidth, r.TravelLength, r.AverageSpeed, r.FuelConsumption, r.TravelInfoID);
        }

        public Route GetRoute(int iDRoute)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "getRoute", iDRoute).Tables[0].Rows[0];

            return new Route
            {
                IDRoute = (int)row[nameof(Route.IDRoute)],
                Time = row[nameof(Route.Time)].ToString(),
                CoordinatesALength = row[nameof(Route.CoordinatesALength)].ToString(),
                CoordinatesAWidth = row[nameof(Route.CoordinatesAWidth)].ToString(),
                CoordinatesBLength = row[nameof(Route.CoordinatesBLength)].ToString(),
                CoordinatesBWidth = row[nameof(Route.CoordinatesBWidth)].ToString(),
                TravelLength = (int)row[nameof(Route.TravelLength)],
                AverageSpeed = (int)row[nameof(Route.AverageSpeed)],
                FuelConsumption = (int)row[nameof(Route.FuelConsumption)],
                TravelInfoID = (int)row[nameof(Route.TravelInfoID)]
            };
        }

        public void BackupDatabase()
        {
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            DataSet ds = new DataSet();

            SqlHelper.FillDataset(cs, CommandType.Text,
                "select * from Driver;" +
                "select * from Car;" +
                "select * from TravelInfo;" +
                "select * from Route;", ds, new string[] { });


            ds.Tables[0].TableName = "Driver";
            ds.Tables[1].TableName = "Car";
            ds.Tables[2].TableName = "TravelInfo";
            ds.Tables[3].TableName = "Route";




            using (var xw = XmlWriter.Create(HttpContext.Current.Server.MapPath("~/App_Data/Database.xml"), xmlSettings))
            {
                xw.WriteStartDocument();
                xw.WriteStartElement("Backup");
                foreach (DataTable table in ds.Tables)
                {

                    foreach (DataRow row in table.Rows)
                    {
                        xw.WriteStartElement(table.TableName);
                        foreach (DataColumn column in table.Columns)
                        {
                            xw.WriteElementString(column.ColumnName, row[column].ToString());
                        }
                        xw.WriteEndElement();
                    }

                }
                xw.WriteEndElement();
                xw.WriteEndDocument();
            }
        }


        public void RestoreDatabase()
        {
            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.IgnoreWhitespace = true;
            xmlSettings.CloseInput = false;

            using (XmlReader r = XmlReader.Create(HttpContext.Current.Server.MapPath("~/App_Data/Database.xml"), xmlSettings))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(r);

                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        switch (table.TableName)
                        {
                            case nameof(Car):
                                Car car = new Car();
                                car.IDCar = int.Parse(row[nameof(Car.IDCar)].ToString());
                                car.Brand = row[nameof(Car.Brand)].ToString();
                                car.Mileage = int.Parse(row[nameof(Car.Mileage)].ToString());
                                car.CarType = row[nameof(Car.CarType)].ToString();
                                car.Mileage = int.Parse(row[nameof(Car.Mileage)].ToString());
                                car.CarReserved = bool.Parse(row[nameof(Car.CarReserved)].ToString());
                                RestoreCar(car);
                                break;
                            case nameof(Driver):
                                Driver driver = new Driver();
                                driver.IDDriver = int.Parse(row[nameof(Driver.IDDriver)].ToString());
                                driver.DriverName = row[nameof(Driver.DriverName)].ToString();
                                driver.DriverSurname = row[nameof(Driver.DriverSurname)].ToString();
                                driver.Telephone = row[nameof(Driver.Telephone)].ToString();
                                driver.LicenceNumber = int.Parse(row[nameof(Driver.LicenceNumber)].ToString());
                                RestoreDriver(driver);
                                break;
                            case "TravelInfo":
                                TravelWarrant tw = new TravelWarrant();
                                tw.IDTravelInfo = int.Parse(row[nameof(TravelWarrant.IDTravelInfo)].ToString());
                                tw.Status = row[nameof(TravelWarrant.Status)].ToString();
                                tw.DriverID = int.Parse(row[nameof(TravelWarrant.DriverID)].ToString());
                                tw.StartCity = int.Parse(row[nameof(TravelWarrant.StartCity)].ToString());
                                tw.StopCity = int.Parse(row[nameof(TravelWarrant.StopCity)].ToString());
                                tw.TravelLength = int.Parse(row[nameof(TravelWarrant.TravelLength)].ToString());
                                tw.DaysExpected = int.Parse(row[nameof(TravelWarrant.DaysExpected)].ToString());
                                tw.CarID = int.Parse(row[nameof(TravelWarrant.CarID)].ToString());
                                RestoreTravelWarrant(tw);
                                break;
                            case nameof(Route):
                                Route ruta = new Route();
                                ruta.IDRoute = int.Parse(row[nameof(Route.IDRoute)].ToString());
                                ruta.Time = row[nameof(Route.Time)].ToString();
                                ruta.CoordinatesALength = row[nameof(Route.CoordinatesALength)].ToString();
                                ruta.CoordinatesBLength = row[nameof(Route.CoordinatesBLength)].ToString();
                                ruta.CoordinatesAWidth = row[nameof(Route.CoordinatesAWidth)].ToString();
                                ruta.CoordinatesBWidth = row[nameof(Route.CoordinatesBWidth)].ToString();
                                ruta.TravelLength = int.Parse(row[nameof(Route.TravelLength)].ToString());
                                ruta.AverageSpeed = int.Parse(row[nameof(Route.AverageSpeed)].ToString());
                                ruta.FuelConsumption = int.Parse(row[nameof(Route.FuelConsumption)].ToString());
                                ruta.TravelInfoID = int.Parse(row[nameof(Route.IDRoute)].ToString());
                                RestoreRoute(ruta);
                                break;
                        }
                    }
                }
            }
        }

        private void RestoreRoute(Route ruta)
        {

            const string RESTORE_ROUTE = "set IDENTITY_INSERT dbo.Route on;" +
                "insert into Route(IDRoute,Time,CoordinatesALength,CoordinatesAWidth,CoordinatesBLength,CoordinatesBWidth,TravelLength,AverageSpeed,FuelConsumption,TravelInfoID) " + " values(@IDRoute,@Time, @CoordinatesALength, @CoordinatesAWidth, @CoordinatesBLength, @CoordinatesBWidth, @TravelLength, @AverageSpeed, @FuelConsumption, @TravelInfoID);" +
                "set IDENTITY_INSERT dbo.Route off;";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = RESTORE_ROUTE;
                    cmd.Parameters.AddWithValue("@IDRoute", ruta.IDRoute);
                    cmd.Parameters.AddWithValue("@Time", ruta.Time);
                    cmd.Parameters.AddWithValue("@CoordinatesALength", ruta.CoordinatesALength);
                    cmd.Parameters.AddWithValue("@CoordinatesAWidth", ruta.CoordinatesAWidth);
                    cmd.Parameters.AddWithValue("@CoordinatesBLength", ruta.CoordinatesBLength);
                    cmd.Parameters.AddWithValue("@CoordinatesBWidth", ruta.CoordinatesBWidth);
                    cmd.Parameters.AddWithValue("@TravelLength", ruta.TravelLength);
                    cmd.Parameters.AddWithValue("@AverageSpeed", ruta.AverageSpeed);
                    cmd.Parameters.AddWithValue("@FuelConsumption", ruta.FuelConsumption);
                    cmd.Parameters.AddWithValue("@TravelInfoID", ruta.TravelInfoID);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        private void RestoreTravelWarrant(TravelWarrant tw)
        {
            const string RESTORE_TRAVEL_WARRANT = "set IDENTITY_INSERT dbo.TravelInfo on;" +
                 "insert into TravelInfo(IDTravelInfo,Status, DriverID, TravelLength, DaysExpected, StartCity, StopCity, CarID)" +
                 " values(@IDTravelInfo,@Status, @DriverID, @TravelLength, @DaysExcpected, @StartCity, @StopCity, @CarID);" +
                 "set IDENTITY_INSERT dbo.TravelInfo off;";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = RESTORE_TRAVEL_WARRANT;
                    cmd.Parameters.AddWithValue("@IDTravelInfo", tw.IDTravelInfo);
                    cmd.Parameters.AddWithValue("@Status", tw.Status);
                    cmd.Parameters.AddWithValue("@DriverID", tw.DriverID);
                    cmd.Parameters.AddWithValue("@TravelLength", tw.TravelLength);
                    cmd.Parameters.AddWithValue("@DaysExcpected", tw.DaysExpected);
                    cmd.Parameters.AddWithValue("@StartCity", tw.StartCity);
                    cmd.Parameters.AddWithValue("@StopCity", tw.StopCity);
                    cmd.Parameters.AddWithValue("@CarID", tw.CarID);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        private void RestoreDriver(Driver driver)
        {
            const string RESTORE_DRIVER = "set IDENTITY_INSERT dbo.Driver on;" +
                "insert into Driver(IDDriver,DriverName,DriverSurname,Telephone,LicenceNumber) " +
                " values(@IDDriver,@DriverName, @DriverSurname, @Telephone, @LicenceNumber);" +
                "set IDENTITY_INSERT dbo.Driver off;";
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = RESTORE_DRIVER;
                    cmd.Parameters.AddWithValue("@IDDriver", driver.IDDriver);
                    cmd.Parameters.AddWithValue("@DriverName", driver.DriverName);
                    cmd.Parameters.AddWithValue("@DriverSurname", driver.DriverSurname);
                    cmd.Parameters.AddWithValue("@Telephone", driver.Telephone);
                    cmd.Parameters.AddWithValue("@LicenceNumber", driver.LicenceNumber);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        private void RestoreCar(Car car)
        {
            const string RESTORE_CAR = "set IDENTITY_INSERT dbo.Car on;" +
                "insert into Car(IDCar,CarType, Brand, YearOfMaking, Mileage, CarReserved) " +
                " values(@IDCar,@CarType, @Brand, @YearOdMaking, @Mileage,@CarReserved);" +
                "set IDENTITY_INSERT dbo.Car off;";
            using (SqlConnection con = new SqlConnection(cs))
            {

                con.Open();
                con.FireInfoMessageEventOnUserErrors = true;
                con.InfoMessage += Con_InfoMessage;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = RESTORE_CAR;
                    cmd.Parameters.AddWithValue("@IDCar", car.IDCar);
                    cmd.Parameters.AddWithValue("@CarType", car.CarType);
                    cmd.Parameters.AddWithValue("@Brand", car.Brand);
                    cmd.Parameters.AddWithValue("@YearOdMaking", car.YearOfMaking);
                    cmd.Parameters.AddWithValue("@Mileage", car.Mileage);
                    cmd.Parameters.AddWithValue("@CarReserved", car.CarReserved);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void ClearDatabase()
        {
            SqlHelper.ExecuteNonQuery(cs, "cleanDatabase");
        }
    }

}
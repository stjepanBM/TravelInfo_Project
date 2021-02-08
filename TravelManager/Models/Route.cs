using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelManager.Models
{
    public class Route
    {
        public int IDRoute { get; set; }
        public string Time { get; set; }
        public string CoordinatesALength { get; set; }
        public string CoordinatesAWidth { get; set; }
        public string CoordinatesBLength { get; set; }
        public string CoordinatesBWidth { get; set; }
        [Display(Name = "Travel length(km)")]
        public int TravelLength { get; set; }
        [Display(Name = "Average speed(km/h)")]
        public int AverageSpeed { get; set; }
        [Display(Name = "Fuel consumption(L)")]
        public int FuelConsumption { get; set; }
        public int TravelInfoID { get; set; }

        public override string ToString() => $"{Time}{CoordinatesALength}{CoordinatesAWidth}{CoordinatesBLength}{CoordinatesBWidth}{TravelLength}{AverageSpeed}{FuelConsumption}{TravelInfoID}";


    }
}
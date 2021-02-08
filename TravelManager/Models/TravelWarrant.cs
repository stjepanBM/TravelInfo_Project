using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelManager.Models
{

    public enum Status
    {
        Active,
        Future,
        Closed
    }

    public class TravelWarrant
    {
        public int IDTravelInfo { get; set; }
        [Required(ErrorMessage = "You must enter status!!!")]
        public string Status { get; set; }

        [Required(ErrorMessage = "You must enter travel length!!!")]
        public float TravelLength { get; set; }

        [Required(ErrorMessage = "You must enter days!!!")]
        public int DaysExpected { get; set; }
        public int StartCity { get; set; }
        public int StopCity { get; set; }
        [Display(Name = "Car")]
        public int CarID { get; set; }
        [Display(Name = "Driver")]
        public int DriverID { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TravelManager.Models
{
    public class Driver
    {
        [Display(Name="Driver")]
        public int IDDriver { get; set; }

        [Display(Name = "Driver name")]
        [Required(ErrorMessage = "You must enter driver's name!!!")]
        public string DriverName { get; set; }

        [Display(Name = "Driver surname")]
        [Required(ErrorMessage = "You must enter driver's surname!!!")]
        public string DriverSurname { get; set; }
        public string Telephone { get; set; }

        [Display(Name = "Licence number")]
        public int LicenceNumber { get; set; }
        public override string ToString() => $"Name: {DriverName}, Surname: {DriverSurname}, Telephone: {Telephone}, Licence number: {LicenceNumber}";
    }
}
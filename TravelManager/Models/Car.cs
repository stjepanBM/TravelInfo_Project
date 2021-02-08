using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelManager.Models
{
    public class Car
    {

        public int IDCar { get; set; }
        [Required(ErrorMessage ="You need to enter car type!!!")]
        public string CarType { get; set; }
        [Required(ErrorMessage ="You need to enter brand of the car!!!")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Enter Year of making!!!")]
        public int YearOfMaking { get; set; }
        [Display(Name = "Mileage(km)")]
        public int Mileage { get; set; }
        public bool CarReserved { get; set; }

        public override string ToString() => $"Car type:{CarType}, Brand:{Brand}, Year of making:{YearOfMaking}, Mileage:{Mileage}";



    }
}
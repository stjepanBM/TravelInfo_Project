//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            this.Service = new HashSet<Service>();
            this.TravelInfo = new HashSet<TravelInfo>();
        }
    
        public int IDCar { get; set; }
        public string CarType { get; set; }
        public string Brand { get; set; }
        public Nullable<int> YearOfMaking { get; set; }
        public Nullable<int> Mileage { get; set; }
        public Nullable<bool> CarReserved { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Service> Service { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TravelInfo> TravelInfo { get; set; }
    }
}

using System.Collections.Generic;
using EF_CORE_NT_BROKER.Models;

namespace EF_CORE_NT_BROKER.Dtos
{
    public class ApartmentIndex
    {
        public Apartment Apartment { get; set; }
        //public Company Company { get; set; }
        //public Broker Broker { get; set; }
        public List<Apartment> AllApartments { get; set; }

    }
}

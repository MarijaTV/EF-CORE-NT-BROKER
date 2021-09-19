using System.Collections.Generic;
using EF_CORE_NT_BROKER.Models;

namespace EF_CORE_NT_BROKER.Dtos
{
    public class ApartmentCreate
    {
        public Apartment Apartment { get; set; }
        public List<Company> AllCompanies { get; set; }
        public List<Broker> AllBrokers { get; set; }
    }
}

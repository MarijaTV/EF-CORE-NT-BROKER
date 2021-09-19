using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_CORE_NT_BROKER.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public List<Broker> Brokers { get; set; }
        [NotMapped]
        public List<int> BrokerIds { get; set; }


    }
}

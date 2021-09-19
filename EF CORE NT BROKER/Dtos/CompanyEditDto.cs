using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_CORE_NT_BROKER.Models;

namespace EF_CORE_NT_BROKER.Dtos
{
    public class CompanyEditDto
    {
        public Company Company { get; set; }

        public List<int> BrokerIds { get; set; }
        public List<Broker> AllBrokers { get; set; }
    }
}

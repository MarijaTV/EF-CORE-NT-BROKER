using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_CORE_NT_BROKER.Models
{
    public class Broker
    {
        public int Id { get; set; }
        [DisplayName("Broker Name")]
        public string Name { get; set; }
        public string Surname { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return Name + " " + Surname;
            }
        }
        public List<Company> Companies { get; set; }



    }
}

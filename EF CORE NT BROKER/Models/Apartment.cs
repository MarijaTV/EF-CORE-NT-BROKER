using System.ComponentModel.DataAnnotations.Schema;

namespace EF_CORE_NT_BROKER.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public string ApartmentName
        {
            get
            {
                return $"{ApartmentType}, {Street} g. {HouseNo}, {City}";
            }
        }

        [NotMapped]
        public string[] ApartmentTypes { get; set; } = new string[] { "Room", "Flat", "Apartment", "House" };
        public string ApartmentType { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNo { get; set; }
        public int FloorOf { get; set; }
        public int Floors { get; set; }
        public decimal Area { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public int BrokerId { get; set; }
        public Broker Broker { get; set; }

    }
}

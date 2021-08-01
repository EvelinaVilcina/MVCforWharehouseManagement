using System.ComponentModel.DataAnnotations;

namespace MVCForWharehouseManagement.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        public string StreetName { get; set; }

        public string HouseName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public short Zip { get; set; }
    }
}

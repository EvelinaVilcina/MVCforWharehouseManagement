using System.ComponentModel.DataAnnotations;

namespace MVCForWharehouseManagement.Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }

        public string FullName { get; set; }

        public int AddressID { get; set; }

        public Address Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}

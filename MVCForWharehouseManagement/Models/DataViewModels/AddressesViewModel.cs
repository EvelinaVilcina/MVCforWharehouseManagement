namespace MVCForWharehouseManagement.Models.DataViewModels
{
    public class AddressesViewModel
    {
        public int AddressId { get; set; }

        public string StreetName { get; set; }

        public string HouseName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public short Zip { get; set; }
    }
}

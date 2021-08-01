
using System.ComponentModel.DataAnnotations;

namespace MVCForWharehouseManagement.Models
{
    public class OrderedProducts
    {
        [Key]
        public int OrderedProductID { get; set; }

        public int ProductID { get; set; }

        public string Name { get; set; }

        public string OrderNumber { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCForWharehouseManagement.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public string OrderNumber { get; set; }

        public DateTime DateTime { get; set; }

        public int ClientID { get; set; }

        public Client Client { get; set; }

        public List<OrderedProducts> OrderedProducts { get; set; }
    }
}

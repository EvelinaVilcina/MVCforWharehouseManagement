using System;
using System.Collections.Generic;

namespace MVCForWharehouseManagement.Models.DataViewModels
{
    public class OrdersViewModel
    {
        public int OrderID { get; set; }

        public string OrderNumber { get; set; }

        public DateTime DateTime { get; set; }

        public int ClientID { get; set; }

        public Client Client { get; set; }

        public List<OrderedProducts> OrderedProducts { get; set; }
    }
}

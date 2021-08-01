using System;
using System.ComponentModel.DataAnnotations;

namespace MVCForWharehouseManagement.Models.WharehouseManagementViewModels
{
    public class OrderDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? DateTime { get; set; }

        public int OrderCount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos
{
    public class OrderViewModel
    {
        public int OrderingId { get; set; }
        public string CustomerName { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}

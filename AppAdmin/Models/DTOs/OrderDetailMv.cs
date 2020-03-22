using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppAdmin.Models.DTOs;

namespace AppAdmin.Models.DTOs
{
    public class OrderDetailMv
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateRequest { get; set; }

        public OrderMv OrderMv { get; set; }

        public ServiceMv ServiceMv { get; set; }
    }
}

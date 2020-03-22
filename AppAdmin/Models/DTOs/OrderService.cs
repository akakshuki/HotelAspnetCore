using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAdmin.Models.DTOs
{
    public class OrderService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  CategoryName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
    }
}

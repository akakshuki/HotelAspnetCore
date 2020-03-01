using System;

namespace Data.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateRequest { get; set; }

        public Order Order { get; set; }
        public Service Service { get; set; }
    }
}
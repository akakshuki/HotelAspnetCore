using Data.Enums;
using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public Payment Payment { get; set; }
        public DateTime DateCreate { get; set; }
        public Guid EmployeeId { get; set; }
        public decimal TotalAmount { get; set; }
        public Booking Booking { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
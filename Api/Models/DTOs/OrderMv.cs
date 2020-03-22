using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Enums;

namespace Api.Models.DTOs
{
    public class OrderMv
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public Payment Payment { get; set; }
        public DateTime DateCreate { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid OrderNo { get; set; }
        public BookingMv Booking { get; set; }
        

        public List<OrderDetailMv> OrderDetailMvs { get; set; }
    }
}

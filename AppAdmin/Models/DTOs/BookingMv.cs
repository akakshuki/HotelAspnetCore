using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAdmin.Models.DTOs;


namespace AppAdmin.Models.DTOs
{
    public class BookingMv
    {
        public int Id { get; set; }
        public int GuestId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int DurationStay { get; set; }
        public string SecretCode { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }

        public List<BookRoomMv> BookRoomMvs { get; set; }
        public GuestMv GuestMv { get; set; }
    }
}

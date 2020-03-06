using System;
using System.Collections.Generic;
using Data.Enums;

namespace Data.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int GuestId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int DurationStay { get; set; }
        public string SecretCode { get; set; }
        public BookedStatus Status { get; set; }
        public decimal Amount { get; set; }

        public List<BookRoom> BookRooms { get; set; }
        public Guest Guest { get; set; }
    }
}
using System;

namespace Data.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int DurationStay { get; set; }
        public string SecretCode { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }

        public Room Room { get; set; }
        public Guest Guest { get; set; }
    }
}
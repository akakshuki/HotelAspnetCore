using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
   public class BookRoom
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int RoomId { get; set; }

        public Booking Booking { get; set; }
        public Room Room { get; set; }
    }
}

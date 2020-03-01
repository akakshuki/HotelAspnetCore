using System.Collections.Generic;

namespace Data.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNo { get; set; }
        public int CategoryRoomId { get; set; }
        public bool Status { get; set; }

        public CategoryRoom CategoryRoom { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
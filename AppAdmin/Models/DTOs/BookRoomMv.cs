using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAdmin.Models.DTOs;

namespace AppAdmin.Models.DTOs
{
    public class BookRoomMv
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int RoomId { get; set; }

        public BookingMv Booking { get; set; }
        
        public RoomMv Room { get; set; }
    }
}

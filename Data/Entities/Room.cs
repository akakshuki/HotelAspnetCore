    using System.Collections.Generic;

namespace Data.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public int CategoryRoomId { get; set; }
        public bool Status { get; set; }

        public CategoryRoom CategoryRoom { get; set; }
        public List<BookRoom> BookRooms { get; set; }
    }
}
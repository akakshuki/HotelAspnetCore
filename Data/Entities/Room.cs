    using System.Collections.Generic;
    using Data.Enums;

    namespace Data.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public int CategoryRoomId { get; set; }
        public Status Status { get; set; }

        public CategoryRoom CategoryRoom { get; set; }
        public List<BookRoom> BookRooms { get; set; }
    }
}
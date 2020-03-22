using Data.Enums;

namespace Api.Models.DTOs
{
    public class RoomMv
    {
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public int CategoryRoomId { get; set; }
        public Status Status { get; set; }

        public CategoryRoomMv CategoryRoomMv { get; set; }
    }
}
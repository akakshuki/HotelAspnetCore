namespace Api.Models.DTOs
{
    public class RoomMv
    {
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public int CategoryRoomId { get; set; }
        public bool Status { get; set; }
    }
}
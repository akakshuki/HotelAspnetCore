using System.Collections.Generic;

namespace Api.Models.DTOs
{
    public class CategoryRoomMv
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

    public class ListRoom
    {
        public List<RoomMv> RoomMvs { get; set; }
    }
}
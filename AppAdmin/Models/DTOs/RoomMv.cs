﻿namespace AppAdmin.Models.DTOs
{
    public class RoomMv
    {
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public int CategoryRoomId { get; set; }
        public int Status { get; set; }

        public CategoryRoomMv CategoryRoomMv { get; set; }
    }
}
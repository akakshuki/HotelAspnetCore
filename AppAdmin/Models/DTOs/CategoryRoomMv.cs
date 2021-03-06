﻿using System.ComponentModel.DataAnnotations;

namespace AppAdmin.Models.DTOs
{
    public class CategoryRoomMv
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
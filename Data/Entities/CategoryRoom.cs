﻿using System.Collections.Generic;

namespace Data.Entities
{
    public class CategoryRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
﻿using System;

namespace Api.Models.DTOs
{
    public class BookMv
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string IdentityNo { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
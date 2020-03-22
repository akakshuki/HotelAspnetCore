using System;
using System.ComponentModel.DataAnnotations;

namespace AppAdmin.Models.DTOs
{
    public class BookMv
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Not null")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Not null")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Not null")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Not null")]
        public string IdentityNo { get; set; }

        [Required(ErrorMessage = "Not null")]
        public DateTime CheckIn { get; set; }
        [Required(ErrorMessage = "Not null")]
        public DateTime CheckOut { get; set; }
        [Required]
        public string RoomIds { get; set; }
        public int[] ListRoomIds { get; set; }
    }
}
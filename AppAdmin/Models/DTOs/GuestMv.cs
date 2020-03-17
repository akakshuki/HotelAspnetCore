using System.Collections.Generic;
using AppAdmin.Models.DTOs;

namespace AppAdmin.Models.DTOs
{
    public class GuestMv
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string IdentityNo { get; set; }

        public List<BookingMv> BookingMvs { get; set; }
    }
}
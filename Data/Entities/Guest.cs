using System.Collections.Generic;

namespace Data.Entities
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string IdentityNo { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
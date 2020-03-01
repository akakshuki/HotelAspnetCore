using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Data.Entities
{
    internal class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string IdentityNo { get; set; }

        public List<Order> Orders { get; set; }
    }
}
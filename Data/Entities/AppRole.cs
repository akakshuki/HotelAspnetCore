using Microsoft.AspNetCore.Identity;
using System;

namespace Data.Entities
{
    internal class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
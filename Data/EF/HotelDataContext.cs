using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Data.EF
{
    public class HotelDataContext : DbContext
    {
        public HotelDataContext(DbContextOptions options) : base(options)
        {

        }
    }
}

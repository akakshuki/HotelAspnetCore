using System;
using System.Collections.Generic;
using System.Text;


namespace Data.Entities
{
    public class CategoryService
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public List<Service> Services { get; set; }
    }
}

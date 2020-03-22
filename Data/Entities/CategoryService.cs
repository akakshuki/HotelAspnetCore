using System.Collections.Generic;

namespace Data.Entities
{
    public class CategoryService
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Service> Services { get; set; }
    }
}
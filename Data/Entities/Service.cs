using System.Collections.Generic;

namespace Data.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryServiceId { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }

        public CategoryService CategoryService { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
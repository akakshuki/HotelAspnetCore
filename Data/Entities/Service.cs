using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
   public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryServiceId { get; set; }
        public bool Status { get; set; }

        public CategoryService CategoryService { get; set; }
    }
}

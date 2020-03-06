using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.DTOs
{
    public class ServiceMv
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryServiceId { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
    }
}

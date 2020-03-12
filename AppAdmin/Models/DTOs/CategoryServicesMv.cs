using System.Collections.Generic;

namespace AppAdmin.Models.DTOs
{
    public class CategoryServicesMv
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ServiceMv> ServicesMv { get; set; }
    }
}
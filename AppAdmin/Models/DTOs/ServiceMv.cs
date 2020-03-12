namespace AppAdmin.Models.DTOs
{
    public class ServiceMv
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryServiceId { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }

        public CategoryServicesMv CategoryServicesMv { get; set; }
    }
}
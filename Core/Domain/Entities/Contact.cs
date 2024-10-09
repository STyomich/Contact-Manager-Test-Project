namespace Core.Domain.Entities
{
    public class Contact
    {
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Married { get; set; } = false;
        public string? Phone { get; set; }
        public decimal? Salary { get; set; }
    }
}
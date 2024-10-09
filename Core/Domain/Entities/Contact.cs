using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }
        public bool Married { get; set; } = false;
        [Required(ErrorMessage = "Phone is required")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        public decimal? Salary { get; set; }
    }
}
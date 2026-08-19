using System.ComponentModel.DataAnnotations;

namespace ValidationApi.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Name Is Required.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email Is Required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string? Email { get; set; }

        [Range(18,60,ErrorMessage = "Age must be between 18 and 60")]
        public int Age { get; set; }
    }
}

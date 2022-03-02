using System.ComponentModel.DataAnnotations;

namespace tutor_8_solution.Models.DTOs.Responses
{
    public class DoctorDTO {
        [Required]
        public int IdDoctor { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
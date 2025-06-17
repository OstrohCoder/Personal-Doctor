using System.ComponentModel.DataAnnotations;

namespace Personal_Doctor.Data
{
    public class Consultation
    {
        public int Id { get; set; }

        public string DoctorId { get; set; }
        [Required]
        public ApplicationUser Doctor { get; set; }

        public string? PatientId { get; set; }
        public ApplicationUser? Patient { get; set; }

        [Required]
        public DateOnly DayDate { get; set; }

        [Required]
        public TimeOnly BeginningTime { get; set; }

        [Required]
        public TimeOnly EndTime { get; set; }

        [Required]
        public float Price { get; set; }

        public byte? Rating { get; set; }
    }
}

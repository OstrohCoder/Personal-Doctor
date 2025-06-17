using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Personal_Doctor.Data
{
    public enum Sex { Male, Female }

    public class ApplicationUser : IdentityUser
    {
        [Required]
        public Sex Sex { get; set; }

        [Required]
        public string Name { get; set; }

        public byte[] Picture { get; set; } = File.ReadAllBytes("wwwroot/img/user-avatar-default.svg");

        public int? ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        public ICollection<Specialty> Specialties { get; set; }

        public ICollection<Consultation> DoctorConsultations { get; set; }
        public ICollection<Consultation> PatientConsultations { get; set; }
    }

}

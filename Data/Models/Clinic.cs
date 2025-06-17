using System.ComponentModel.DataAnnotations;

namespace Personal_Doctor.Data
{
    public class Clinic
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public byte[] Picture { get; set; } = File.ReadAllBytes("wwwroot/img/clinic-avatar-default.svg");

        public ICollection<ApplicationUser> Doctors { get; set; }
    }
}

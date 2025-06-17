using System.ComponentModel.DataAnnotations;

namespace Personal_Doctor.Data
{
    public class Specialty
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<ApplicationUser> Doctors { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Personal_Doctor.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Specialty> Specialties { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Consultation>()
                .HasOne(c => c.Doctor)
                .WithMany(u => u.DoctorConsultations)
                .HasForeignKey(c => c.DoctorId);

            builder.Entity<Consultation>()
                .HasOne(c => c.Patient)
                .WithMany(u => u.PatientConsultations)
                .HasForeignKey(c => c.PatientId);
        }
    }
}

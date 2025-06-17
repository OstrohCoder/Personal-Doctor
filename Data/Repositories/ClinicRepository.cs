using Microsoft.EntityFrameworkCore;

namespace Personal_Doctor.Data
{
    public class ClinicRepository
    {
        private readonly ApplicationDbContext _context;

        public ClinicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Clinic clinic)
        {
            await _context.Clinics.AddAsync(clinic);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Clinic clinic)
        {
            _context.Clinics.Update(clinic);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Clinic clinic)
        {
            _context.Clinics.Remove(clinic);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Clinic>> GetAllAsync()
        {
            return await _context.Clinics
                .Include(c => c.Doctors)
                .ToListAsync();
        }

        public async Task<Clinic?> GetByIdAsync(int id)
        {
            return await _context.Clinics
                .Include(c => c.Doctors)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

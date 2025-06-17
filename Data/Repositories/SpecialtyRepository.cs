using Microsoft.EntityFrameworkCore;

namespace Personal_Doctor.Data
{
    public class SpecialtyRepository
    {
        private readonly ApplicationDbContext _context;

        public SpecialtyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Specialty specialty)
        {
            await _context.Specialties.AddAsync(specialty);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Specialty specialty)
        {
            _context.Specialties.Update(specialty);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Specialty specialty)
        {
            _context.Specialties.Remove(specialty);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Specialty>> GetAllAsync()
        {
            return await _context.Specialties
                .Include(s => s.Doctors)
                .ToListAsync();
        }

        public async Task<Specialty?> GetByIdAsync(int id)
        {
            return await _context.Specialties
                .Include(s => s.Doctors)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}

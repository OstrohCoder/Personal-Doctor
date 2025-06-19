using Microsoft.EntityFrameworkCore;

namespace Personal_Doctor.Data
{
    public class ConsultationRepository
    {
        private readonly ApplicationDbContext _context;

        public ConsultationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Consultation consultation)
        {
            await _context.Consultations.AddAsync(consultation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Consultation consultation)
        {
            _context.Consultations.Update(consultation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Consultation consultation)
        {
            _context.Consultations.Remove(consultation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Consultation>> GetAllAsync()
        {
            return await _context.Consultations
                .Include(c => c.Doctor)
                .Include(c => c.Patient)
                .ToListAsync();
        }

        public async Task<Consultation?> GetByIdAsync(int id)
        {
            return await _context.Consultations
                .Include(c => c.Doctor)
                .Include(c => c.Patient)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Consultation>> GetByDoctorIdAsync(string doctorId)
        {
            return await _context.Consultations
                .Include(c => c.Patient)
                .Where(c => c.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<List<Consultation>> GetByPatientIdAsync(string patientId)
        {
            return await _context.Consultations
                .Include(c => c.Doctor)
                .Where(c => c.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<Dictionary<DateOnly, List<Consultation>>> GetByDoctorIdGroupedByDateAsync(string doctorId)
        {
            var consultations = await _context.Consultations
                .Include(c => c.Patient)
                .Where(c => c.DoctorId == doctorId)
                .ToListAsync();

            return consultations
                .GroupBy(c => c.DayDate)
                .ToDictionary(
                    g => g.Key,
                    g => g.OrderBy(c => c.BeginningTime).ToList()
                );
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Personal_Doctor.Data
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ApplicationUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ApplicationUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ApplicationUser user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ApplicationUser>> GetAllAsync()
        {
            return await _context.Users
                .Include(u => u.Specialties)
                .Include(u => u.DoctorConsultations)
                .Include(u => u.PatientConsultations)
                .ToListAsync();
        }

        public async Task<ApplicationUser?> GetByIdAsync(string id)
        {
            return await _context.Users
                .Include(u => u.Specialties)
                .Include(u => u.DoctorConsultations)
                .Include(u => u.PatientConsultations)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public float? GetUserRatingAsync(ApplicationUser user)
        {
            var consultations = user.DoctorConsultations;
            float? summaryRating = 0;
            int ratingsNumber = 0;

            foreach (var consultation in consultations)
            {
                if (consultation.Rating is not null)
                {
                    summaryRating += consultation.Rating;
                    ratingsNumber++;
                }
            }

            if (ratingsNumber == 0) return 0;
            else return summaryRating / ratingsNumber;
        }
    }
}

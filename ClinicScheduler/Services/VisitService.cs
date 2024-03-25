using ClinicScheduler.Entities;
using ClinicScheduler.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ClinicScheduler.Services
{
    public class VisitService : IVisitService
    {
        private readonly ClinicDbContext _dbContext;
        private DoctorService _doctorService;

        public VisitService(ClinicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Visit>> GetAllVisitsAsync() =>
            await _dbContext.Visits.Include(x => x.Doctor).Include(y => y.Patient).ToListAsync();

        public async Task<Visit> GetVistByIdAsync(int id)
        {
            var dbVisit = await _dbContext.Visits
                .Include(x => x.Doctor)
                .Include(y => y.Patient)
                .Where(z => z.Id == id)
                .FirstOrDefaultAsync();
            return dbVisit;
        }

        public async Task AddVisitAsync(Visit visit)
        {
            _dbContext.Add(visit);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateVisitAsync(Visit visit, int id)
        {
            var dbVisit = await _dbContext.Visits
                .Include(x => x.Doctor)
                .Include(y => y.Patient)
                .Where(z => z.Id == id)
                .FirstOrDefaultAsync();
            
            if (dbVisit != null)
            {
                dbVisit.DoctorId = visit.DoctorId;
                dbVisit.PatientId = visit.PatientId;
                dbVisit.DateOfVisit = visit.DateOfVisit;
                dbVisit.PrescriptionNumber = visit.PrescriptionNumber;
                dbVisit.IsConfirmed = visit.IsConfirmed;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteVisitAsync(int id)
        {
            var dbVisit = await _dbContext.Visits.AsNoTracking()
                .Where(z => z.Id == id)
                .FirstOrDefaultAsync();
            if (dbVisit != null)
            {
                _dbContext.Remove(dbVisit);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

using ClinicScheduler.Entities;
using ClinicScheduler.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicScheduler.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ClinicDbContext _dbContext;
        
        public DoctorService(ClinicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync() => await _dbContext.Doctors.ToListAsync();
        
        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            var doctor = await _dbContext.Doctors.Where(x => x.Id == id).FirstOrDefaultAsync();
            return doctor;
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            _doctors.Add(doctor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDoctorAsync(Doctor doctor, int id)
        {
            var dbDoctor = await _dbContext.Doctors.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (dbDoctor != null)
            {
                dbDoctor.Name = doctor.Name;
                dbDoctor.LastName = doctor.LastName;
                dbDoctor.Specialization = doctor.Specialization;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var dbDoctor = await _dbContext.Doctors.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (dbDoctor != null)
            {
                _dbContext.Remove(dbDoctor);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

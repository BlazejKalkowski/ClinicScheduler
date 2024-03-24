using ClinicScheduler.Entities;
using ClinicScheduler.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicScheduler.Services
{
    public class PatientService : IPatientService
    {
        private readonly ClinicDbContext _dbContext;
        
        public PatientService(ClinicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Patient>> GetAllPatientsAsync() => await _dbContext.Patients.ToListAsync();

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            var patient = await _dbContext.Patients.Where(x => x.Id == id).FirstOrDefaultAsync();
            return patient;
        }

        public async Task AddPatientAsync(Patient patient)
        {
            _dbContext.Add(patient);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePatientAsync(Patient patient, int id)
        {
            var dbPatient = await _dbContext.Patients.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (dbPatient != null)
            {
                dbPatient.Name = patient.Name;
                dbPatient.LastName = patient.LastName;
                dbPatient.PESEL = patient.PESEL;
                dbPatient.DateOfBirth = patient.DateOfBirth;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeletePatientAsync(int id)
        {
            var dbPatient = await _dbContext.Patients.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (dbPatient != null)
            {
                _dbContext.Remove(dbPatient);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

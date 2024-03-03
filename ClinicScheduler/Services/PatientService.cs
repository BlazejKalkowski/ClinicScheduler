using ClinicScheduler.Interfaces;
using ClinicScheduler.Models;

namespace ClinicScheduler.Services
{
    public class PatientService : IPatientService
    {

        public Task<List<Patient>> GetAllPatients()
        {
            throw new NotImplementedException();
        }

        public Task<Doctor> GetPatientByGuid()
        {
            throw new NotImplementedException();
        }

        public void UpdatePatient()
        {
            throw new NotImplementedException();
        }

        public void DeletePatient()
        {
            throw new NotImplementedException();
        }
    }
}

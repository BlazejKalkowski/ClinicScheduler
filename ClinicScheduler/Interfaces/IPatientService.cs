using ClinicScheduler.Models;

namespace ClinicScheduler.Interfaces
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllPatients();
        Task<Doctor> GetPatientByGuid();
        void UpdatePatient();
        void DeletePatient();
    }
}

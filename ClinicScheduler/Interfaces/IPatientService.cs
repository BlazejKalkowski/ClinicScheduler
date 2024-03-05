using ClinicScheduler.Models;

namespace ClinicScheduler.Interfaces
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task UpdatePatientAsync(Patient patient, int id);
        Task DeletePatientAsync(int id);
    }
}

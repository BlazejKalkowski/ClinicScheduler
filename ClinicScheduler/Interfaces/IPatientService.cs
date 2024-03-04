using ClinicScheduler.Models;

namespace ClinicScheduler.Interfaces
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByGuidAsync(Guid guid);
        Task UpdatePatientAsync(Patient patient,Guid guid);
        Task DeletePatientAsync(Guid guid);
    }
}

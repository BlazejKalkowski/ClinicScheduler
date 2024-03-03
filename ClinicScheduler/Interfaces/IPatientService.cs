using ClinicScheduler.Models;

namespace ClinicScheduler.Interfaces
{
    public interface IPatientService
    {
        List<Patient> GetAllPatients();
        Patient GetPatientByGuid(Guid guid);
        void UpdatePatient(Patient patient,Guid guid);
        void DeletePatient(Guid guid);
    }
}

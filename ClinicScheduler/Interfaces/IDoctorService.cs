using ClinicScheduler.Models;

namespace ClinicScheduler.Interfaces
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetAllDoctors();
        Task<Doctor> GetDoctorByGuid();
        void UpdateDoctor();
        void DeleteDoctor();
    }
}

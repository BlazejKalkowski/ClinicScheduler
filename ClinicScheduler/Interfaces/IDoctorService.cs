using ClinicScheduler.Models;

namespace ClinicScheduler.Interfaces
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> GetDoctorByGuidAsync(Guid guid);
        Task UpdateDoctorAsync(Doctor doctor, Guid guid);
        Task DeleteDoctorAsync(Guid guid);
    }
}

using ClinicScheduler.Entities;

namespace ClinicScheduler.Interfaces
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(int id);

        Task AddDoctorAsync(Doctor doctor);
        Task UpdateDoctorAsync(Doctor doctor, int id);
        Task DeleteDoctorAsync(int id);
    }
}

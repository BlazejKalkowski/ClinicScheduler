using ClinicScheduler.Models;

namespace ClinicScheduler.Interfaces
{
    public interface IDoctorService
    {
        List<Doctor> GetAllDoctors();
        Doctor GetDoctorByGuid(Guid guid);
        void UpdateDoctor(Doctor doctor, Guid guid);
        void DeleteDoctor(Guid guid);
    }
}

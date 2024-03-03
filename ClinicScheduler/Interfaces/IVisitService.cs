using ClinicScheduler.Models;

namespace ClinicScheduler.Interfaces
{
    public interface IVisitService
    {
        Task<List<Visit>> GetAllVisits();
        Task<Doctor> GetVistByGuid();
        void UpdateVisit();
        void DeleteVisit();
    }
}

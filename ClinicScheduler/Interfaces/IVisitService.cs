using ClinicScheduler.Entities;

namespace ClinicScheduler.Interfaces
{
    public interface IVisitService
    {
        Task<List<Visit>> GetAllVisitsAsync();
        Task<Visit> GetVistByIdAsync(int id);

        Task AddVisitAsync(Visit visit);
        Task UpdateVisitAsync(Visit visit, int id);
        Task DeleteVisitAsync(int id);
    }
}

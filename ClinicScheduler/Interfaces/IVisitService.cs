using ClinicScheduler.Models;

namespace ClinicScheduler.Interfaces
{
    public interface IVisitService
    {
        Task<List<Visit>> GetAllVisitsAsync();
        Task<Visit> GetVistByIdAsync(int id);
        Task UpdateVisitAsync(Visit visit, int id);
        Task DeleteVisitAsync(int id);
    }
}

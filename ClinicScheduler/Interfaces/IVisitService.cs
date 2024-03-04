using ClinicScheduler.Models;

namespace ClinicScheduler.Interfaces
{
    public interface IVisitService
    {
        Task<List<Visit>> GetAllVisitsAsync();
        Task<Visit> GetVistByGuidAsync(Guid guid);
        Task UpdateVisitAsync(Visit visit, Guid guid);
        Task DeleteVisitAsync(Guid guid);
    }
}

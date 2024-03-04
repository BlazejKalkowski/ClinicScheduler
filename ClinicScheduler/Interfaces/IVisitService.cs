using ClinicScheduler.Models;

namespace ClinicScheduler.Interfaces
{
    public interface IVisitService
    {
        List<Visit> GetAllVisits();
        Visit GetVistByGuid(Guid guid);
        void UpdateVisit(Visit visit, Guid guid);
        void DeleteVisit(Guid guid);
    }
}

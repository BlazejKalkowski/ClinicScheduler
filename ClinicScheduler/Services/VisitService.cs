using ClinicScheduler.Interfaces;
using ClinicScheduler.Models;

namespace ClinicScheduler.Services
{
    public class VisitService : IVisitService
    {
        private static List<Visit> _visits = new List<Visit>
        {
            new Visit(){Guid = Guid.NewGuid(),
                Patient = new Patient(){Guid = Guid.NewGuid(), Name= "Jan", LastName = "Kowalski", PESEL = "55110479461", DateOfBirth = new DateTime(1955,11,04)},
                Doctor = new Doctor(){Guid = Guid.NewGuid(), Name = "Artur", LastName = "Jablonski", Specialization = "Cardiologist"},
                PrescriptionNumber = 1234, IsConfirmed = false,DateOfVisit = new DateTime(2024,08,01) },

            new Visit(){Guid = Guid.NewGuid(),
                Patient = new Patient(){Guid = Guid.NewGuid(), Name= "Alina", LastName = "Mleczarska", PESEL = "88062109178", DateOfBirth = new DateTime(1988,06,21)},
                Doctor = new Doctor(){Guid = Guid.NewGuid(), Name = "Jerzy", LastName = "Mineralski", Specialization = "Dermatologist"},
                PrescriptionNumber = 1234, IsConfirmed = true,DateOfVisit = new DateTime(2024,07,28) },

            new Visit(){Guid = Guid.NewGuid(),
                Patient = new Patient(){Guid = Guid.NewGuid(), Name= "Czesław", LastName = "Radkowski", PESEL = "60012001123", DateOfBirth = new DateTime(1960,01,20)},
                Doctor = new Doctor(){Guid = Guid.NewGuid(), Name = "Natalia", LastName = "Almanska", Specialization = "Pediatrician"},
                PrescriptionNumber = 1234, IsConfirmed = true,DateOfVisit = new DateTime(2024,06,16) },
        };


        public async Task<List<Visit>> GetAllVisitsAsync()
        {
            await Task.Delay(100);
            return _visits;
        }

        public async Task<Visit> GetVistByGuidAsync(Guid guid)
        {
            await Task.Delay(100);
            var visit = _visits.Where(x => x.Guid == guid).FirstOrDefault();
            return visit;
        }

        public async Task UpdateVisitAsync(Visit visit, Guid guid)
        {
            await Task.Delay(100);
            var dbVisit = _visits.Where(x => x.Guid == guid).FirstOrDefault();
            if (dbVisit != null)
            {
                dbVisit.Doctor = visit.Doctor;
                dbVisit.Patient = visit.Patient;
                dbVisit.DateOfVisit = visit.DateOfVisit;
                dbVisit.PrescriptionNumber = visit.PrescriptionNumber;
                dbVisit.IsConfirmed = visit.IsConfirmed;
            }
        }

        public async Task DeleteVisitAsync(Guid guid)
        {
            await Task.Delay(100);
            var dbVisit = _visits.Where(x => x.Guid == guid).FirstOrDefault();
            if (dbVisit != null)
            {
                _visits.Remove(dbVisit);
            }
        }
    }
}

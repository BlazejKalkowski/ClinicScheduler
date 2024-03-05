using ClinicScheduler.Interfaces;
using ClinicScheduler.Models;

namespace ClinicScheduler.Services
{
    public class VisitService : IVisitService
    {
        private static List<Visit> _visits = new List<Visit>
        {
            new Visit(){Id = 1,
                Patient = new Patient(){Id = 1, Name= "Jan", LastName = "Kowalski", PESEL = "55110479461", DateOfBirth = new DateTime(1955,11,04)},
                Doctor = new Doctor(){Id = 1, Name = "Artur", LastName = "Jablonski", Specialization = "Cardiologist"},
                PrescriptionNumber = 1234, IsConfirmed = false,DateOfVisit = new DateTime(2024,08,01) },

            new Visit(){Id = 2,
                Patient = new Patient(){Id = 2, Name= "Alina", LastName = "Mleczarska", PESEL = "88062109178", DateOfBirth = new DateTime(1988,06,21)},
                Doctor = new Doctor(){Id = 2, Name = "Jerzy", LastName = "Mineralski", Specialization = "Dermatologist"},
                PrescriptionNumber = 1234, IsConfirmed = true,DateOfVisit = new DateTime(2024,07,28) },

            new Visit(){Id = 3,
                Patient = new Patient(){Id = 3, Name= "Czesław", LastName = "Radkowski", PESEL = "60012001123", DateOfBirth = new DateTime(1960,01,20)},
                Doctor = new Doctor(){Id = 3, Name = "Natalia", LastName = "Almanska", Specialization = "Pediatrician"},
                PrescriptionNumber = 1234, IsConfirmed = true,DateOfVisit = new DateTime(2024,06,16) },
        };


        public async Task<List<Visit>> GetAllVisitsAsync()
        {
            await Task.Delay(100);
            return _visits;
        }

        public async Task<Visit> GetVistByIdAsync(int id)
        {
            await Task.Delay(100);
            var visit = _visits.Where(x => x.Id == id).FirstOrDefault();
            return visit;
        }

        public async Task UpdateVisitAsync(Visit visit, int id)
        {
            await Task.Delay(100);
            var dbVisit = _visits.Where(x => x.Id == id).FirstOrDefault();
            if (dbVisit != null)
            {
                dbVisit.Doctor = visit.Doctor;
                dbVisit.Patient = visit.Patient;
                dbVisit.DateOfVisit = visit.DateOfVisit;
                dbVisit.PrescriptionNumber = visit.PrescriptionNumber;
                dbVisit.IsConfirmed = visit.IsConfirmed;
            }
        }

        public async Task DeleteVisitAsync(int id)
        {
            await Task.Delay(100);
            var dbVisit = _visits.Where(x => x.Id == id).FirstOrDefault();
            if (dbVisit != null)
            {
                _visits.Remove(dbVisit);
            }
        }
    }
}

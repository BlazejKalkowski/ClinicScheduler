using ClinicScheduler.Entities;
using ClinicScheduler.Interfaces;


namespace ClinicScheduler.Services
{
    public class VisitService : IVisitService
    {
        private DoctorService _doctorService;
        public static List<Visit> _visits = new List<Visit>
        {
            new Visit(){Id = 1,
                PatientId = 1,
                DoctorId = 1,
                Doctor = new Doctor(){Id = 1, Name = "Artur", LastName = "Jablonski", Specialization = "Cardiologist"},
                PrescriptionNumber = 1234, IsConfirmed = false,DateOfVisit = new DateTime(2024,08,01) },

            new Visit(){Id = 2,
                PatientId = 2,
                DoctorId = 2,
                Doctor = new Doctor(){Id = 2, Name = "Jerzy", LastName = "Mineralski", Specialization = "Dermatologist"},
                PrescriptionNumber = 1234, IsConfirmed = true,DateOfVisit = new DateTime(2024,07,28) },

            new Visit(){Id = 3,
                PatientId = 3,
                DoctorId = 3,
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

        public async Task AddVisitAsync(Visit visit)
        {
            await Task.Delay(100);
            _visits.Add(visit);
        }

        public async Task UpdateVisitAsync(Visit visit, int id)
        {
            await Task.Delay(100);
            var dbVisit = _visits.Where(x => x.Id == id).FirstOrDefault();
            
            
            if (dbVisit != null)
            {
                var doctors = DoctorService._doctors;
                var doctor = doctors.Where(x => x.Id == visit.DoctorId).FirstOrDefault();
                
                var patients = PatientService._patients;
                var patient = patients.Where(x => x.Id == visit.DoctorId).FirstOrDefault();
                dbVisit.Doctor = doctor;
                dbVisit.Patient = patient;
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

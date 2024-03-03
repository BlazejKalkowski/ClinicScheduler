using ClinicScheduler.Interfaces;
using ClinicScheduler.Models;
using System;

namespace ClinicScheduler.Services
{
    public class DoctorService : IDoctorService
    {
        private static List<Doctor> _doctors = new List<Doctor> 
        {
            new Doctor(){Guid = Guid.NewGuid(), Name = "Artur", LastName = "Jablonski", Specialization = "Cardiologist"},
            new Doctor(){Guid = Guid.NewGuid(), Name = "Jerzy", LastName = "Mineralski", Specialization = "Dermatologist"},
            new Doctor(){Guid = Guid.NewGuid(), Name = "Natalia", LastName = "Almanska", Specialization = "Pediatrician"},
        };

        public List<Doctor> GetAllDoctors() => _doctors;


        public Doctor GetDoctorByGuid(Guid guid)
        {
            var doctor = _doctors.Where(x => x.Guid == guid).FirstOrDefault();
            return doctor;
        }

        public void UpdateDoctor(Doctor doctor, Guid guid)
        {
            var dbDoctor = _doctors.Where(x => x.Guid == guid).FirstOrDefault();
            if (dbDoctor != null)
            {
                dbDoctor.Name = doctor.Name;
                dbDoctor.LastName = doctor.LastName;
                dbDoctor.Specialization = doctor.Specialization;
            }
        }

        public void DeleteDoctor(Guid guid)
        {
            var dbDoctor = _doctors.Where(x => x.Guid == guid).FirstOrDefault();
            if (dbDoctor != null)
            {
                _doctors.Remove(dbDoctor);
            }
        }
    }
}

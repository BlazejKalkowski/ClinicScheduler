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

        public async Task<List<Doctor>> GetAllDoctorsAsync() 
        {
            await Task.Delay(100);
            return _doctors;
        }


        public async Task<Doctor> GetDoctorByGuidAsync(Guid guid)
        {
            await Task.Delay(100);
            var doctor =  _doctors.Where(x => x.Guid == guid).FirstOrDefault();
            return doctor;
        }

        public async Task UpdateDoctorAsync(Doctor doctor, Guid guid)
        {
            await Task.Delay(100);
            var dbDoctor = _doctors.Where(x => x.Guid == guid).FirstOrDefault();
            if (dbDoctor != null)
            {
                dbDoctor.Name = doctor.Name;
                dbDoctor.LastName = doctor.LastName;
                dbDoctor.Specialization = doctor.Specialization;
            }
        }

        public async Task DeleteDoctorAsync(Guid guid)
        {
            await Task.Delay(100);
            var dbDoctor = _doctors.Where(x => x.Guid == guid).FirstOrDefault();
            if (dbDoctor != null)
            {
                _doctors.Remove(dbDoctor);
            }
        }
    }
}

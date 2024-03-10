using ClinicScheduler.Interfaces;
using ClinicScheduler.Models;
using System;

namespace ClinicScheduler.Services
{
    public class DoctorService : IDoctorService
    {
        public static List<Doctor> _doctors = new List<Doctor> 
        {
            new Doctor(){Id = 1, Name = "Artur", LastName = "Jablonski", Specialization = "Cardiologist"},
            new Doctor(){Id = 2, Name = "Jerzy", LastName = "Mineralski", Specialization = "Dermatologist"},
            new Doctor(){Id = 3, Name = "Natalia", LastName = "Almanska", Specialization = "Pediatrician"},
        };

        public async Task<List<Doctor>> GetAllDoctorsAsync() 
        {
            await Task.Delay(100);
            return _doctors;
        }


        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            await Task.Delay(100);
            var doctor =  _doctors.Where(x => x.Id == id).FirstOrDefault();
            return doctor;
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            await Task.Delay(100);
            _doctors.Add(doctor);
        }

        public async Task UpdateDoctorAsync(Doctor doctor, int id)
        {
            await Task.Delay(100);
            var dbDoctor = _doctors.Where(x => x.Id == id).FirstOrDefault();
            if (dbDoctor != null)
            {
                dbDoctor.Name = doctor.Name;
                dbDoctor.LastName = doctor.LastName;
                dbDoctor.Specialization = doctor.Specialization;
            }
        }

        public async Task DeleteDoctorAsync(int id)
        {
            await Task.Delay(100);
            var dbDoctor = _doctors.Where(x => x.Id == id).FirstOrDefault();
            if (dbDoctor != null)
            {
                _doctors.Remove(dbDoctor);
            }
        }
    }
}

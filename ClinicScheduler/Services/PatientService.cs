using ClinicScheduler.Interfaces;
using ClinicScheduler.Models;

namespace ClinicScheduler.Services
{
    public class PatientService : IPatientService
    {
        private static List<Patient> _patients = new List<Patient>
        {
           new Patient(){Id = 1, Name= "Jan", LastName = "Kowalski", PESEL = "55110479461", DateOfBirth = new DateTime(1955,11,04)},
           new Patient(){Id = 2, Name= "Alina", LastName = "Mleczarska", PESEL = "88062109178", DateOfBirth = new DateTime(1988,06,21)},
           new Patient(){Id = 3, Name= "Czesław", LastName = "Radkowski", PESEL = "60012001123", DateOfBirth = new DateTime(1960,01,20)},
           new Patient(){Id = 4, Name= "Natalia", LastName = "Mroczkowska", PESEL = "59012001987", DateOfBirth = new DateTime(1959,01,20)},
        };

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            await Task.Delay(100);
            return _patients;
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            await Task.Delay(100);
            var patient = _patients.Where(x => x.Id == id).FirstOrDefault();
            return patient;
        }

        public async Task AddPatientAsync(Patient patient)
        {
            await Task.Delay(100);
            _patients.Add(patient);
        }

        public async Task UpdatePatientAsync(Patient patient, int id)
        {
            await Task.Delay(100);
            var dbPatient = _patients.Where(x => x.Id == id).FirstOrDefault();
            if (dbPatient != null)
            {
                dbPatient.Name = patient.Name;
                dbPatient.LastName = patient.LastName;
                dbPatient.PESEL = patient.PESEL;
                dbPatient.DateOfBirth = patient.DateOfBirth;
            }
        }

        public async Task DeletePatientAsync(int id)
        {
            await Task.Delay(100);
            var dbPatient = _patients.Where(x => x.Id == id).FirstOrDefault();
            if (dbPatient != null)
            {
                _patients.Remove(dbPatient);
            }
        }
    }
}

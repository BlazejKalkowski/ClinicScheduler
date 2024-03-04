using ClinicScheduler.Interfaces;
using ClinicScheduler.Models;

namespace ClinicScheduler.Services
{
    public class PatientService : IPatientService
    {
        private static List<Patient> _patients = new List<Patient>
        {
           new Patient(){Guid = Guid.NewGuid(), Name= "Jan", LastName = "Kowalski", PESEL = "55110479461", DateOfBirth = new DateTime(1955,11,04)},
           new Patient(){Guid = Guid.NewGuid(), Name= "Alina", LastName = "Mleczarska", PESEL = "88062109178", DateOfBirth = new DateTime(1988,06,21)},
           new Patient(){Guid = Guid.NewGuid(), Name= "Czesław", LastName = "Radkowski", PESEL = "60012001123", DateOfBirth = new DateTime(1960,01,20)},
           new Patient(){Guid = Guid.NewGuid(), Name= "Natalia", LastName = "Mroczkowska", PESEL = "59012001987", DateOfBirth = new DateTime(1959,01,20)},
        };

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            await Task.Delay(100);
            return _patients;
        }

        public async Task<Patient> GetPatientByGuidAsync(Guid guid)
        {
            await Task.Delay(100);
            var patient = _patients.Where(x => x.Guid == guid).FirstOrDefault();
            return patient;
        }

        public async Task UpdatePatientAsync(Patient patient, Guid guid)
        {
            await Task.Delay(100);
            var dbPatient = _patients.Where(x => x.Guid == guid).FirstOrDefault();
            if (dbPatient != null)
            {
                dbPatient.Name = patient.Name;
                dbPatient.LastName = patient.LastName;
                dbPatient.PESEL = patient.PESEL;
                dbPatient.DateOfBirth = patient.DateOfBirth;
            }
        }

        public async Task DeletePatientAsync(Guid guid)
        {
            await Task.Delay(100);
            var dbPatient = _patients.Where(x => x.Guid == guid).FirstOrDefault();
            if (dbPatient != null)
            {
                _patients.Remove(dbPatient);
            }
        }
    }
}

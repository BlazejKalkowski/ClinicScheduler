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

        public List<Patient> GetAllPatients() => _patients;

        public Patient GetPatientByGuid(Guid guid)
        {
            var patient = _patients.Where(x => x.Guid == guid).FirstOrDefault();
            return patient;
        }

        public void UpdatePatient(Patient patient, Guid guid)
        {
            var dbPatient = _patients.Where(x => x.Guid == guid).FirstOrDefault();
            if (dbPatient != null)
            {
                dbPatient.Name = patient.Name;
                dbPatient.LastName = patient.LastName;
                dbPatient.PESEL = patient.PESEL;
                dbPatient.DateOfBirth = patient.DateOfBirth;
            }
        }

        public void DeletePatient(Guid guid)
        {
            var dbPatient = _patients.Where(x => x.Guid == guid).FirstOrDefault();
            if (dbPatient != null)
            {
                _patients.Remove(dbPatient);
            }
        }
    }
}

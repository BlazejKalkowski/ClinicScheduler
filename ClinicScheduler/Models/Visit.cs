using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicScheduler.Models
{
    public class Visit
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Doctor Doctor { get; set; }
        
        public int DoctorId { get; set; }
        [Required]
        public Patient Patient { get; set; }
        
        public int PatientId { get; set; }
        [Required]
        public DateTime DateOfVisit { get; set; }
        public int PrescriptionNumber { get; set; }

        public  bool IsConfirmed { get; set; }
    }
}

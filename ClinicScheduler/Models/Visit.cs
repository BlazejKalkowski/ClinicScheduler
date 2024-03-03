using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicScheduler.Models
{
    public class Visit
    {
        [Required]
        public Guid Guid { get; set; }
        [Required]
        public Doctor Doctor { get; set; }
        [Required]
        public Patient Patient { get; set; }
        [Required]
        public DateTime DateOfVisit { get; set; }
        public int PrescriptionNumber { get; set; }

        public  bool IsConfirmed { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ClinicScheduler.Models
{
    public class Doctor
    {
        [Required]
        public Guid Guid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Specialization { get; set; }
    }
}

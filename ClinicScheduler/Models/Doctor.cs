using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public string FullName
        {
            get => $"{Name} {LastName}";
        }

        [Required]
        public string Specialization { get; set; }
    }
}

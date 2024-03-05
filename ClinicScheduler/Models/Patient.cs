using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicScheduler.Models
{
    public class Patient
    {
        [Required]
        public int Id { get; set; }
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
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Wrong number of PESEL")]
        public string PESEL {  get; set; }
        [Required]
        public DateTime DateOfBirth {  get; set; }
    }
}

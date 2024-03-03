using System.ComponentModel.DataAnnotations;

namespace ClinicScheduler.Models
{
    public class Patient
    {
        [Required]
        public Guid Guid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Wrong number of PESEL")]
        public string PESEL {  get; set; }
        [Required]
        public DateTime DateOfBirth {  get; set; }
    }
}

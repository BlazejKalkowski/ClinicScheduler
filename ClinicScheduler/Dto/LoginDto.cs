using System.ComponentModel.DataAnnotations;

namespace ClinicScheduler.Dto;

public class LoginDto
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
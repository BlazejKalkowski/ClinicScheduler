using System.ComponentModel.DataAnnotations;

namespace ClinicScheduler.Dto;

public class UserDto
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public Dictionary<string,string> Claims { get; set; }
}
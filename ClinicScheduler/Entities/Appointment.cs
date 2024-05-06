namespace ClinicScheduler.Entities;

public class Appointment
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Text { get; set; }
}
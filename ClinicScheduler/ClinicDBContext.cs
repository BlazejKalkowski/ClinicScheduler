using ClinicScheduler.Entieties;
using Microsoft.EntityFrameworkCore;

namespace ClinicScheduler;

public class ClinicDbContext(DbContextOptions<ClinicDbContext> options) : DbContext(options)
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Visit> Visits { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity()
    // }
}
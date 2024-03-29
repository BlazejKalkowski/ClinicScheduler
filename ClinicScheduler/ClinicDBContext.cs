using ClinicScheduler.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicScheduler;

public class ClinicDbContext : IdentityDbContext
{
    public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Visit> Visits { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>()
            .HasMany(e => e.Visits)
            .WithOne(x => x.Doctor)
            .HasForeignKey(f => f.DoctorId);
        
        modelBuilder.Entity<Patient>()
            .HasMany(e => e.Visits)
            .WithOne(x => x.Patient)
            .HasForeignKey(f => f.PatientId);
        
        modelBuilder.Entity<Visit>()
            .HasOne(e => e.Doctor)
            .WithMany(x => x.Visits)
            .HasForeignKey(f => f.DoctorId);
        
        modelBuilder.Entity<Visit>()
            .HasOne(e => e.Patient)
            .WithMany(x => x.Visits)
            .HasForeignKey(f => f.PatientId);
        
        base.OnModelCreating(modelBuilder);
    }
}
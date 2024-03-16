using ClinicScheduler.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicScheduler;

public class ClinicDbContext : IdentityDbContext<ApplicationUser>
{
    public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Visit> Visits { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        // modelBuilder.Entity<Doctor>().HasData(
        //     new Doctor() { Id = 1, Name = "Artur", LastName = "Jablonski", Specialization = "Cardiologist" }
        //     , new Doctor() { Id = 2, Name = "Jerzy", LastName = "Mineralski", Specialization = "Dermatologist" }
        //     , new Doctor() { Id = 3, Name = "Natalia", LastName = "Almanska", Specialization = "Pediatrician" });
        //
        // modelBuilder.Entity<Patient>().HasData(           
        //     new Patient(){Id = 1, Name= "Jan", LastName = "Kowalski", PESEL = "55110479461", DateOfBirth = new DateTime(1955,11,04).ToLocalTime()},
        //     new Patient(){Id = 2, Name= "Alina", LastName = "Mleczarska", PESEL = "88062109178", DateOfBirth = new DateTime(1988,06,21).ToLocalTime()},
        //     new Patient(){Id = 3, Name= "Czesław", LastName = "Radkowski", PESEL = "60012001123", DateOfBirth = new DateTime(1960,01,20).ToLocalTime()},
        //     new Patient(){Id = 4, Name= "Natalia", LastName = "Mroczkowska", PESEL = "59012001987", DateOfBirth = new DateTime(1959,01,20).ToLocalTime()});
        //
        // modelBuilder.Entity<Visit>().HasData(
        //     new Visit()
        //     {
        //         Id = 1,
        //         PatientId = 1,
        //         DoctorId = 1,
        //         PrescriptionNumber = 1234, IsConfirmed = false, DateOfVisit = new DateTime(2024, 08, 01).ToLocalTime()
        //     },
        //
        //     new Visit()
        //     {
        //         Id = 2,
        //         PatientId = 2,
        //         DoctorId = 2,
        //         PrescriptionNumber = 1234, IsConfirmed = true, DateOfVisit = new DateTime(2024, 07, 28).ToLocalTime()
        //     },
        //
        //     new Visit()
        //     {
        //         Id = 3,
        //         PatientId = 3,
        //         DoctorId = 3,
        //         PrescriptionNumber = 1234, IsConfirmed = true, DateOfVisit = new DateTime(2024, 06, 16).ToLocalTime()
        //     });
        
        base.OnModelCreating(modelBuilder);
    }
}
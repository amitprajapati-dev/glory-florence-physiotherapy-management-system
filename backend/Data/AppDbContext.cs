using Microsoft.EntityFrameworkCore;
using SampleProject.Models;

namespace SampleProject.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<TreatmentType> TreatmentTypes { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<PatientMedicalHistory> PatientMedicalHistories { get; set; }
    public DbSet<PatientDocument> PatientDocuments { get; set; }
    public DbSet<AppointmentType> AppointmentTypes { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<TreatmentSession> TreatmentSessions { get; set; }
    public DbSet<PatientAssessment> PatientAssessments { get; set; }
    public DbSet<TreatmentPlan> TreatmentPlans { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .Property(e => e.Salary)
            .HasPrecision(10, 2);

        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .HasMaxLength(150);

        modelBuilder.Entity<User>()
            .Property(u => u.PasswordHash)
            .HasMaxLength(500);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Role>()
            .HasIndex(r => r.Name)
            .IsUnique();

        modelBuilder.Entity<UserRole>()
            .HasIndex(ur => new { ur.UserId, ur.RoleId })
            .IsUnique();
        
        modelBuilder.Entity<State>()
            .HasOne<Country>()
            .WithMany()
            .HasForeignKey(s => s.CountryId);

        modelBuilder.Entity<City>()
            .HasOne<State>()
            .WithMany()
            .HasForeignKey(c => c.StateId);

        modelBuilder.Entity<Address>()
            .HasOne<Country>()
            .WithMany()
            .HasForeignKey(a => a.CountryId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Address>()
            .HasOne<State>()
            .WithMany()
            .HasForeignKey(a => a.StateId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Address>()
            .HasOne<City>()
            .WithMany()
            .HasForeignKey(a => a.CityId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Address>()
            .Property(a => a.Latitude)
            .HasPrecision(10, 7);

        modelBuilder.Entity<Address>()
            .Property(a => a.Longitude)
            .HasPrecision(10, 7);

        modelBuilder.Entity<UserProfile>()
            .HasOne<User>()
            .WithOne()
            .HasForeignKey<UserProfile>(up => up.UserId);

        modelBuilder.Entity<UserProfile>()
            .HasOne<Address>()
            .WithMany()
            .HasForeignKey(up => up.AddressId);

        modelBuilder.Entity<Patient>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .IsRequired(false);

        modelBuilder.Entity<Patient>()
            .HasOne<Address>()
            .WithMany()
            .HasForeignKey(p => p.AddressId);

        modelBuilder.Entity<Patient>()
            .HasIndex(p => p.PatientNumber)
            .IsUnique();

        modelBuilder.Entity<TreatmentType>()
            .HasOne<Category>()
            .WithMany()
            .HasForeignKey(t => t.CategoryId);

        modelBuilder.Entity<TreatmentType>()
            .Property(t => t.DefaultPrice)
            .HasPrecision(12, 2);
        
        modelBuilder.Entity<Exercise>()
            .HasOne<Category>()
            .WithMany()
            .HasForeignKey(e => e.CategoryId);

        modelBuilder.Entity<PatientMedicalHistory>()
            .HasOne<Patient>()
            .WithMany()
            .HasForeignKey(h => h.PatientId);

        modelBuilder.Entity<PatientDocument>()
            .HasOne<Patient>()
            .WithMany()
            .HasForeignKey(d => d.PatientId);

        modelBuilder.Entity<PatientDocument>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(d => d.UploadedBy);  
    }
}
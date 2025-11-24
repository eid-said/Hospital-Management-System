using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Billing> Billings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // حل مشكلة Cascade Cycle
            builder.Entity<Billing>()
                .HasOne(b => b.Appointment)
                .WithMany(a => a.Billings)
                .HasForeignKey(b => b.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict); // لا تعمل cascade delete عند حذف appointment
        }
    }
}

using tutor_8_solution.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace tutor_8_solution.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
        {

        }
        public MainDbContext(DbContextOptions opt) : base(opt)
        {

        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionsMedicaments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s21353;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DoctorEntityConfig());
            modelBuilder.ApplyConfiguration(new PatientEntityConfig());
            modelBuilder.ApplyConfiguration(new MedicamentEntityConfig());
            modelBuilder.ApplyConfiguration(new PrescriptionEntityConfig());
            modelBuilder.ApplyConfiguration(new PrescriptionMedicamentEntityConfig());

            modelBuilder.Seed();
        }
    }
}
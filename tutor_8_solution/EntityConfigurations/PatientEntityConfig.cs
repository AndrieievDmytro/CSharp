using tutor_8_solution.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace tutor_8_solution.EntityConfigurations
{
    public class PatientEntityConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> opt)
        {
            opt.HasKey(p => p.IdPatient);
            opt.Property(p => p.IdPatient).ValueGeneratedOnAdd();
            opt.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            opt.Property(p => p.LastName).IsRequired().HasMaxLength(100);
            opt.Property(p => p.Birthdate).IsRequired();
        }
    }
}
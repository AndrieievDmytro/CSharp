using tutor_8_solution.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace tutor_8_solution.EntityConfigurations
{
    public class PrescriptionEntityConfig : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(pr => pr.IdPrescription);
            builder.Property(pr => pr.IdPrescription).ValueGeneratedOnAdd();
            builder.Property(pr => pr.Date).IsRequired();
            builder.Property(pr => pr.DueDate).IsRequired();

            builder.HasOne( d => d.Doctor)
                    .WithMany(pr => pr.Prescriptions)
                    .HasForeignKey(d => d.IdDoctor);

            builder.HasOne( p => p.Patient)
                    .WithMany(pr => pr.Prescriptions)
                    .HasForeignKey(p => p.idPatient);
        }
    }
}
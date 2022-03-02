using tutor_8_solution.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace tutor_8_solution.EntityConfigurations
{
    public class PrescriptionMedicamentEntityConfig : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.HasKey(pm => new{pm.IdMedicament, pm.IdPrescription});
            builder.Property(pm => pm.Dose);
            builder.Property(pm => pm.Details).IsRequired().HasMaxLength(100);

            builder.HasOne(m => m.Medicament)
                    .WithMany(pm => pm.PrescriptionMedicaments)
                    .HasForeignKey(pm => pm.IdMedicament);
                    
            builder.HasOne(pr => pr.Prescription)
                    .WithMany(pm => pm.PrescriptionMedicaments)
                    .HasForeignKey(pm => pm.IdPrescription);
        }

    }
}
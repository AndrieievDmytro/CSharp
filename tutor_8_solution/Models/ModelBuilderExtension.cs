using System;
using Microsoft.EntityFrameworkCore;

namespace tutor_8_solution.Models
{

    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor 
                {
                    IdDoctor = 1,
                    FirstName = "DoctorFirstName1",
                    LastName = "DoctorLastName1",
                    Email = "doctorEmail1"    
                }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor 
                {
                    IdDoctor = 2,
                    FirstName = "DoctorFirstName2",
                    LastName = "DoctorLastName2",
                    Email = "doctorEmail2"    
                }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    IdPatient = 1,
                    FirstName = "PatientFirstName1",
                    LastName = "PatientLastName1",
                    Birthdate = DateTime.Now
                }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    IdPatient = 2,
                    FirstName = "PatientFirstName2",
                    LastName = "PatientLastName2",
                    Birthdate = DateTime.Now
                }
            );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription 
                {
                    IdPrescription = 1,
                    IdDoctor = 1,
                    idPatient = 1,
                    Date = new DateTime(2020, 5, 1),
                    DueDate = new DateTime(2021, 5, 1)
                }
            );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription 
                {
                    IdPrescription = 2,
                    IdDoctor = 2,
                    idPatient = 2,
                    Date = new DateTime(2019, 5, 1),
                    DueDate = new DateTime(2020, 5, 1)
                }
            );

            modelBuilder.Entity<Medicament>().HasData(
                new Medicament 
                {
                    IdMedicament = 1,
                    Name = "MedicamentName1",
                    Description = "MedicamentDescription1",
                    Type = "Type1"
                }
            );

            modelBuilder.Entity<Medicament>().HasData(
                new Medicament 
                {
                    IdMedicament = 2,
                    Name = "MedicamentName2",
                    Description = "MedicamentDescription2",
                    Type = "Type2"
                }
            );
            
            modelBuilder.Entity<PrescriptionMedicament>().HasData(
                new PrescriptionMedicament 
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Dose = 5,
                    Details = "Deteils1"
                }
            );

            modelBuilder.Entity<PrescriptionMedicament>().HasData(
                new PrescriptionMedicament 
                {
                    IdMedicament = 2,
                    IdPrescription = 2,
                    Dose = 10,
                    Details = "Deteils2"
                }
            );

        }
    }
}
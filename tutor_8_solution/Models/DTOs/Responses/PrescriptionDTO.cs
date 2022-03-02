using System;
using System.Collections.Generic;

namespace tutor_8_solution.Models.DTOs.Responses
{
    public class PrescriptionDTO
    {
        public int IdPrescription { get; set; }
        public IEnumerable<DoctorDTO> Doctor { get; set; }
        public IEnumerable<PatientDTO> Patient { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public IEnumerable<MedicamentDTO> Medicaments { get; set; }
        public IEnumerable<PrescriptionMedicamentDTO> PrescriptionMedicaments { get; set; }
    }

    public class MedicamentDTO
    {
        public int IdMedicament { get; set; }
        public string MedicamentName { get; set; }
        public string MedicamentDescription { get; set; }
        public string MedicamentType { get; set; }
    }
    public class PatientDTO
    {
        public int IdPatient { get; set; }
        public string FirstNamePatient { get; set; }
        public string LastNamePatient { get; set; }
        public DateTime Birthdate { get; set; }
    }

    public class PrescriptionMedicamentDTO
    {
        public int IdPrescription { get; set; }
        public int? Dose { get; set; }
        public string Details { get; set; }
    }
}


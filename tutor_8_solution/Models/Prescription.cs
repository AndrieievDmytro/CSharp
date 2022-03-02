using System;
using System.Collections.Generic;

namespace tutor_8_solution.Models
{
    public class Prescription
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdDoctor { get; set; }
        public int idPatient { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    }
}
using System.Collections.Generic;

namespace tutor_8_solution.Models
{
    public class Doctor
    {
        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }

    }
}


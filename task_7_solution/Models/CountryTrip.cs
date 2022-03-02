using System;
using System.Collections.Generic;

#nullable disable

namespace task_7_solution.Models
{
    public partial class CountryTrip
    {
        public int IdCountry { get; set; }
        public int IdTrip { get; set; }

        public virtual Country IdCountryNavigation { get; set; }
        public virtual Trip IdTripNavigation { get; set; }
    }
}

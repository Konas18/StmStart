using System;
using System.Collections.Generic;

#nullable disable

namespace StmBibl
{
    public partial class Klinika
    {
        public Klinika()
        {
            Personals = new HashSet<Personal>();
            Raspisanies = new HashSet<Raspisanie>();
            Uslugis = new HashSet<Uslugi>();
        }

        public string Adres { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Personal> Personals { get; set; }
        public virtual ICollection<Raspisanie> Raspisanies { get; set; }
        public virtual ICollection<Uslugi> Uslugis { get; set; }
    }
}

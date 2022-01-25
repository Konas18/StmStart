using System;
using System.Collections.Generic;

#nullable disable

namespace StmBibl
{
    public partial class Materiali
    {
        public Materiali()
        {
            Uslugis = new HashSet<Uslugi>();
        }

        public int IdMaterial { get; set; }
        public string Name { get; set; }
        public DateTime DatePokupki { get; set; }
        public DateTime SrokGodnosti { get; set; }

        public virtual ICollection<Uslugi> Uslugis { get; set; }
    }
}

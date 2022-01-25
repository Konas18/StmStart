using System;
using System.Collections.Generic;

#nullable disable

namespace StmBibl
{
    public partial class Klient
    {
        public Klient()
        {
            DogovorFkIdMedKnigNavigations = new HashSet<Dogovor>();
            DogovorFkPasportNavigations = new HashSet<Dogovor>();
            RaspisanieFkIdMedKnigiNavigations = new HashSet<Raspisanie>();
            RaspisanieFkPasportNavigations = new HashSet<Raspisanie>();
            ZubFkIdMedKnigNavigations = new HashSet<Zub>();
            ZubFkPasportNavigations = new HashSet<Zub>();
        }

        public string Pasport { get; set; }
        public int IdMedKnig { get; set; }
        public string F { get; set; }
        public string I { get; set; }
        public string O { get; set; }
        public DateTime DateRozhd { get; set; }
        public bool Pol { get; set; }
        public string Adres { get; set; }
        public string DrugieZabolevaniya { get; set; }
        public string RezvitieNastoyaschegoZabol { get; set; }

        public virtual ICollection<Dogovor> DogovorFkIdMedKnigNavigations { get; set; }
        public virtual ICollection<Dogovor> DogovorFkPasportNavigations { get; set; }
        public virtual ICollection<Raspisanie> RaspisanieFkIdMedKnigiNavigations { get; set; }
        public virtual ICollection<Raspisanie> RaspisanieFkPasportNavigations { get; set; }
        public virtual ICollection<Zub> ZubFkIdMedKnigNavigations { get; set; }
        public virtual ICollection<Zub> ZubFkPasportNavigations { get; set; }
    }
}

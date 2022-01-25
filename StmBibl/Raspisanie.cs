using System;
using System.Collections.Generic;

#nullable disable

namespace StmBibl
{
    public partial class Raspisanie
    {
        public Raspisanie()
        {
            PriemFkTimePNavigations = new HashSet<Priem>();
        }

        public DateTime DateP { get; set; }
        public TimeSpan TimeP { get; set; }
        public int FkIdPerson { get; set; }
        public int FkIdMedKnigi { get; set; }
        public string FkPasport { get; set; }
        public string FkAdres { get; set; }

        public virtual Klinika FkAdresNavigation { get; set; }
        public virtual Klient FkIdMedKnigiNavigation { get; set; }
        public virtual Personal FkIdPersonNavigation { get; set; }
        public virtual Klient FkPasportNavigation { get; set; }
        public virtual Priem PriemFkDatePNavigation { get; set; }
        public virtual ICollection<Priem> PriemFkTimePNavigations { get; set; }
    }
}

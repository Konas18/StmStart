using System;
using System.Collections.Generic;

#nullable disable

namespace StmBibl
{
    public partial class Zub
    {
        public int Zub1 { get; set; }
        public int FkIdMedKnig { get; set; }
        public string FkPasport { get; set; }

        public virtual Klient FkIdMedKnigNavigation { get; set; }
        public virtual Klient FkPasportNavigation { get; set; }
        public virtual ZubHistory ZubHistory { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace StmBibl
{
    public partial class Dogovor
    {
        public int IdDogovor { get; set; }
        public int FkIdMedKnig { get; set; }
        public string FkPasport { get; set; }
        public int FkIdPerson { get; set; }

        public virtual Klient FkIdMedKnigNavigation { get; set; }
        public virtual Personal FkIdPersonNavigation { get; set; }
        public virtual Klient FkPasportNavigation { get; set; }
    }
}

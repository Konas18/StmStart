using System;
using System.Collections.Generic;

#nullable disable

namespace StmBibl
{
    public partial class ZubHistory
    {
        public int Zub { get; set; }
        public int FkIdUslugi { get; set; }
        public int FkIdPriema { get; set; }
        public DateTime FkDateP { get; set; }

        public virtual Priem FkDatePNavigation { get; set; }
        public virtual Priem FkIdPriemaNavigation { get; set; }
        public virtual Uslugi FkIdUslugiNavigation { get; set; }
        public virtual Zub ZubNavigation { get; set; }
    }
}

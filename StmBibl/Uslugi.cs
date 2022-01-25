using System;
using System.Collections.Generic;

#nullable disable

namespace StmBibl
{
    public partial class Uslugi
    {
        public Uslugi()
        {
            ZubHistories = new HashSet<ZubHistory>();
        }

        public int IdUslugi { get; set; }
        public string Name { get; set; }
        public int ColZatrMateriala { get; set; }
        public string FkAdres { get; set; }
        public int FkIdMateriala { get; set; }

        public virtual Klinika FkAdresNavigation { get; set; }
        public virtual Materiali FkIdMaterialaNavigation { get; set; }
        public virtual ICollection<ZubHistory> ZubHistories { get; set; }
    }
}

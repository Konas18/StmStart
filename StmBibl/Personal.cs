using System;
using System.Collections.Generic;

#nullable disable

namespace StmBibl
{
    public partial class Personal
    {
        public Personal()
        {
            Dogovors = new HashSet<Dogovor>();
            Priems = new HashSet<Priem>();
            Raspisanies = new HashSet<Raspisanie>();
        }

        public int IdPerson { get; set; }
        public string F { get; set; }
        public string I { get; set; }
        public string O { get; set; }
        public int Stazh { get; set; }
        public string MestoZhitelstva { get; set; }
        public int Rol { get; set; }
        public string FkAdres { get; set; }

        public virtual Klinika FkAdresNavigation { get; set; }
        public virtual ICollection<Dogovor> Dogovors { get; set; }
        public virtual ICollection<Priem> Priems { get; set; }
        public virtual ICollection<Raspisanie> Raspisanies { get; set; }
    }
}

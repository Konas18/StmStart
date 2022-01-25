using System;
using System.Collections.Generic;

#nullable disable

namespace StmBibl
{
    public partial class Priem
    {
        public Priem()
        {
            ZubHistoryFkDatePNavigations = new HashSet<ZubHistory>();
            ZubHistoryFkIdPriemaNavigations = new HashSet<ZubHistory>();
        }

        public int IdPriema { get; set; }
        public DateTime FkDateP { get; set; }
        public int FkIdPerson { get; set; }
        public TimeSpan FkTimeP { get; set; }
        public string Zhalobi { get; set; }
        public string DannieVneshnegoOsmotra { get; set; }
        public string DannieRentgenOsmotra { get; set; }
        public string Konsultatsii { get; set; }
        public string PlanLecheniya { get; set; }

        public virtual Raspisanie FkDatePNavigation { get; set; }
        public virtual Personal FkIdPersonNavigation { get; set; }
        public virtual Raspisanie FkTimePNavigation { get; set; }
        public virtual ICollection<ZubHistory> ZubHistoryFkDatePNavigations { get; set; }
        public virtual ICollection<ZubHistory> ZubHistoryFkIdPriemaNavigations { get; set; }
    }
}

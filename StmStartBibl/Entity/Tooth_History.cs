using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StmStartBibl
{
    public class Tooth_History
    {
        public int ID { get; set; }

        private int toothNumber;
        public int ToothNumber { get { return toothNumber; } set { toothNumber = value; } }

        private decimal sum;
        public decimal Sum { get { return sum; } set { sum = value; } }

        public DateTime DateTimeService { get; set; }
        public virtual Client Client { get; set; }
        public virtual Services Services { get; set; }
        public virtual Reception Reception { get; set; }

        private static ApplicationContext db = Context.Db;
        public static void Add(Tooth_History Tooth_History)
        {
            db.Add(Tooth_History);
            db.SaveChanges();
        }
    }
}

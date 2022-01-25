using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StmStartBibl
{
    public class Schedule
    {
        public int ID { get; set; }
        private DateTime date_of_admission;
        public DateTime Date_of_admission { get { return date_of_admission; } set { date_of_admission = value; } }

        private DateTime reception_time;
        public DateTime Reception_time { get { return reception_time; } set { reception_time = value; } }
        public virtual Client Client { get; set; }
        public virtual Clinic Clinic { get; set; }

        private static ApplicationContext db = Context.Db;
        public static void Add(Schedule Schedule)
        {
            db.Add(Schedule);
            db.SaveChanges();
        }
    }
}

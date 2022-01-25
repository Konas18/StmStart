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
        public string GetDateOfAppointment
        {
            get
            {
                return DateTimeService.ToString("d");
            }
        }
        public static List<Tooth_History> GetAll()
        {
            return db.Tooth_History.ToList();
        }
        public class Tooth_HistoryInfo
        {
            public int ID { get; set; }
            public int ToothNumber { get; set; }
            public string FIOClienta { get; set; }
        }
        public static List<Tooth_HistoryInfo> GetTooth_HistoryInfo()
        {
            return (from th in db.Tooth_History
                    join c in db.Client on th.Client.ID equals c.ID
                    select new Tooth_HistoryInfo()
                    {
                        ID = th.ID,
                        ToothNumber = th.ToothNumber,
                        FIOClienta = c.GetFullName,
                    }).ToList();
        }
        public Tooth_History GetTooth_HistoryById(int id)
        {
            return (from th in db.Tooth_History
                    where th.ID == id
                    select th).FirstOrDefault();
        }
    }
}

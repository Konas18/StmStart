using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StmStartBibl
{
    public class Reception
    {
        public int ID { get; set; }

        private decimal sum;
        public decimal Sum { get { return sum; } set { sum = value; } }
        public DateTime DateTimeService { get; set; }

        private string complaints;
        public string Complaints { get { return complaints; } set { complaints = value; } }

        private string external_inspection_data;
        public string External_inspection_data { get { return external_inspection_data; } set { external_inspection_data = value; } }

        private string treatment_plan;
        public string Treatment_plan { get { return treatment_plan; } set { treatment_plan = value; } }
        public virtual Personal Personal { get; set; }
        public virtual Client Client { get; set; }
        public virtual Schedule Schedule { get; set; }

        private static ApplicationContext db = Context.Db;
        public static void Add(Reception Reception)
        {
            db.Add(Reception);
            db.SaveChanges();
        }
        public static List<Reception> GetAll()
        {
            return db.Reception.ToList();
        }
        public string GetDateOfAppointment
        {
            get
            {
                return DateTimeService.ToString("d");
            }
        }
        public string GetTimeOfAppointment
        {
            get
            {
                return DateTimeService.ToString("t");
            }
        }
        public Reception GetReceptionById(int id)
        {
            return (from r in db.Reception
                    where r.ID == id
                    select r).FirstOrDefault();
        }
        
    }
}

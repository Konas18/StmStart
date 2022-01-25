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
        private string complaints;
        public string Complaints { get { return complaints; } set { complaints = value; } }

        private string external_inspection_data;
        public string External_inspection_data { get { return external_inspection_data; } set { external_inspection_data = value; } }

        private string treatment_plan;
        public string Treatment_plan { get { return treatment_plan; } set { treatment_plan = value; } }
        public virtual Personal Personal { get; set; }
        public virtual Schedule Schedule { get; set; }

        private static ApplicationContext db = Context.Db;
        public static void Add(Reception Reception)
        {
            db.Add(Reception);
            db.SaveChanges();
        }
    }
}

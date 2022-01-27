using System;

namespace StmStartBibl
{
    public class Clinic
    {
        private static ApplicationContext db = Context.Db;
        public int ID { get; set; }

        private string address_name;
        public string Address { get { return address_name; } set { address_name = value; } }

        private string clinic_name;
        public string Clinic_name { get { return clinic_name; } set { clinic_name = value; } }
        public static void Add(Clinic Clinic)
        {
            db.Add(Clinic);
            db.SaveChanges();
        }
    }
}

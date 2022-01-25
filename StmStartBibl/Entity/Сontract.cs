using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StmStartBibl
{
    public class Сontract
    {
        public int ID { get; set; }
        private string number_contract;
        public string Number_contract { get { return number_contract; } set { number_contract = value; } }

        private DateTime date_contract;
        public DateTime Date_contract { get { return date_contract; } set { date_contract = value; } }
        public virtual Client Client { get; set; }
        public virtual Personal Personal { get; set; }

        private static ApplicationContext db = Context.Db;
        public static void Add(Сontract Сontract)
        {
            db.Add(Сontract);
            db.SaveChanges();
        }
    }
}

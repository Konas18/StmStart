using System;

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

        public Сontract()
        { }
        public Сontract (string Number_contract, DateTime Date_contract, Client Client, Personal Personal)
        {
            this.Number_contract = Number_contract;
            this.Date_contract = Date_contract;
            this.Client = Client;
            this.Personal = Personal;
        }
        public static void Add(Сontract Сontract)
        {
            db.Add(Сontract);
            db.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StmStartBibl
{
    public class Client : User
    {
        private static ApplicationContext db = Context.Db;
        public int ID { get; set; }

        private string phone;
        public string Phone { get { return phone; } set { phone = value; } }

        private string surname;
        public string Surname { get { return surname; } set { surname = value; } }

        private string name;
        public string Name { get { return name; } set { name = value; } }

        private string lastname;
        public string Lastname { get { return lastname; } set { lastname = value; } }

        private string pasport;
        public string Pasport { get { return pasport; } set { pasport = value; } }

        private DateTime date_of_birth;
        public DateTime Date_of_birth { get { return date_of_birth; } set { date_of_birth = value; } }

        private string addres;
        public string Addres { get { return addres; } set { addres = value; } }

        private string medical_history;
        public string Medical_history { get { return medical_history; } set { medical_history = value; } }

        public virtual List<Tooth_History> ToothHistory { get; set; } = new List<Tooth_History>();

        public static void Add(Client client)
        {
            db.Client.Add(client);
            db.SaveChanges();
        }
        public static List<Client> GetAll()
        {
            return db.Client.ToList(); 
        }
        public string GetDate_of_birth
        {
            get
            {
                return Date_of_birth.ToString("d");
            }
        }
        public static void Save() => db.SaveChanges();

    }
}

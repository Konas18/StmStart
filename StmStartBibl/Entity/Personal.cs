using System;
using System.Collections.Generic;
using System.Linq;

namespace StmStartBibl
{
    public class Personal : User
    {
        public int ID { get; set; }

        private string phone;
        public string Phone { get { return phone; } set { phone = value; } }

        private string login;
        public string Login { get { return login; } set { login = value; } }

        private string password;
        public string Password { get { return password; } set { password = value; } }

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

        private int experience;
        public int Experience { get { return experience; } set { experience = value; } }

        private string postName;
        public string PostName { get { return postName; } set { postName = value; } }
        public virtual Clinic Clinic { get; set; }
        public virtual Post Post { get; set; }

        private static ApplicationContext db = Context.Db;
        public static void Add(Personal Personal)
        {
            db.Add(Personal);
            db.SaveChanges();
        }
        public static List<Personal> GetAll()
        {
            return db.Personal.ToList();
        }
        public string GetDate_of_birth
        {
            get
            {
                return Date_of_birth.ToString("d");
            }
        }
        public static Personal GetPerson(string Login, string Password)
        {
            return db.Personal.Where(a => a.Login == Login && a.Password == Password).FirstOrDefault();
        }

        public static void Save() => db.SaveChanges();
    }
}

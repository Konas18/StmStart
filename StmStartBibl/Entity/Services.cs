using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StmStartBibl
{
    public class Services
    {
        public int ID { get; set; }
        private string services_name;
        public string Services_name { get { return services_name; } set { services_name = value; } }

        private decimal price;
        public decimal Price { get { return price; } set { price = value; } }

        public virtual Material Material { get; set; }
        public virtual Clinic Clinic { get; set; }

        private static ApplicationContext db = Context.Db;
        public static void Add(Services Services)
        {
            db.Add(Services);
            db.SaveChanges();
        }
        public static List<Services> GetAll()
        {
            return db.Services.ToList();
        }
    }
}

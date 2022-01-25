using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StmStartBibl
{
    public class Material
    {
        public int ID { get; set; }
        private string material_name;
        public string Material_name { get { return material_name; } set { material_name = value; } }

        private DateTime date_of_purchase;
        public DateTime Date_of_purchase { get { return date_of_purchase; } set { date_of_purchase = value; } }

        private DateTime expiration_date;
        public DateTime Expiration_date { get { return expiration_date; } set { expiration_date = value; } }

        private int quantity;
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public virtual Deliveries Deliveries { get; set; }

        private static ApplicationContext db = Context.Db;
        public static void Add(Material Material)
        {
            db.Add(Material);
            db.SaveChanges();
        }
    }
}

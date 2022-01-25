using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StmStartBibl
{
    public class Deliveries
    {
        public int ID { get; set; }
        private DateTime delivery_date;
        public DateTime Delivery_date { get { return delivery_date; } set { delivery_date = value; } }

        private decimal amount_spent;
        public decimal Amount_spent { get { return amount_spent; } set { amount_spent = value; } }

        private string product_name;
        public string Product_name { get { return product_name; } set { product_name = value; } }

        private static ApplicationContext db = Context.Db;
        public static void Add(Deliveries Deliveries)
        {
            db.Add(Deliveries);
            db.SaveChanges();
        }
    }
}

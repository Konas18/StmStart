using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StmStartBibl
{
    public class Post
    {
        public int ID { get; set; }
        private string post_name;
        public string Post_name { get { return post_name; } set { post_name = value; } }

        private string description;
        public string Description { get { return description; } set { description = value; } }

        private int access_level;
        public int Access_level { get { return access_level; } set { access_level = value; } }

        private static ApplicationContext db = Context.Db;
        public static void Add(Post Post)
        {
            db.Add(Post);
            db.SaveChanges();
        }
    }
}

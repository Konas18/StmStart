using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StmStartBibl
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext (DbContextOptions<ApplicationContext> options):base(options)
        {
            Database.Migrate();
            Context.AddDb(this);
        }
        
        public DbSet<Client> Client { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<Deliveries> Deliveries { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Reception> Reception { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Tooth_History> Tooth_History { get; set; }
        public DbSet<Сontract> Сontract { get; set; }

        public static DbContextOptions<ApplicationContext> GetDb()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            return optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Host=localhost;Port=5433;Database=stm;Username=postgres;Password=21052508").Options;
        }
    }
}

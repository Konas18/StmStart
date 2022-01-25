using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StmBibl
{
    public partial class StmContext : DbContext
    {
        public StmContext()
        {
        }

        public StmContext(DbContextOptions<StmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dogovor> Dogovors { get; set; }
        public virtual DbSet<Klient> Klients { get; set; }
        public virtual DbSet<Klinika> Klinikas { get; set; }
        public virtual DbSet<Materiali> Materialis { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<Priem> Priems { get; set; }
        public virtual DbSet<Raspisanie> Raspisanies { get; set; }
        public virtual DbSet<Uslugi> Uslugis { get; set; }
        public virtual DbSet<Zub> Zubs { get; set; }
        public virtual DbSet<ZubHistory> ZubHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=Stm;Username=postgres;Password=21052508");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Dogovor>(entity =>
            {
                entity.HasKey(e => e.IdDogovor)
                    .HasName("dogovor_pkey");

                entity.ToTable("dogovor");

                entity.Property(e => e.IdDogovor).HasColumnName("id_dogovor");

                entity.Property(e => e.FkIdMedKnig)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("fk_id_med_knig");

                entity.Property(e => e.FkIdPerson)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("fk_id_person");

                entity.Property(e => e.FkPasport)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("fk_pasport");

                entity.HasOne(d => d.FkIdMedKnigNavigation)
                    .WithMany(p => p.DogovorFkIdMedKnigNavigations)
                    .HasPrincipalKey(p => p.IdMedKnig)
                    .HasForeignKey(d => d.FkIdMedKnig)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_med_knigi");

                entity.HasOne(d => d.FkIdPersonNavigation)
                    .WithMany(p => p.Dogovors)
                    .HasForeignKey(d => d.FkIdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_person");

                entity.HasOne(d => d.FkPasportNavigation)
                    .WithMany(p => p.DogovorFkPasportNavigations)
                    .HasPrincipalKey(p => p.Pasport)
                    .HasForeignKey(d => d.FkPasport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pasport");
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => new { e.Pasport, e.IdMedKnig })
                    .HasName("klient_pkey");

                entity.ToTable("klient");

                entity.HasIndex(e => new { e.IdMedKnig, e.Pasport }, "klienti")
                    .IsUnique();

                entity.HasIndex(e => e.IdMedKnig, "kniga")
                    .IsUnique();

                entity.HasIndex(e => e.Pasport, "pasport")
                    .IsUnique();

                entity.Property(e => e.Pasport)
                    .HasMaxLength(30)
                    .HasColumnName("pasport");

                entity.Property(e => e.IdMedKnig)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_med_knig");

                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("adres");

                entity.Property(e => e.DateRozhd)
                    .HasColumnType("date")
                    .HasColumnName("date_rozhd");

                entity.Property(e => e.DrugieZabolevaniya)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("drugie_zabolevaniya");

                entity.Property(e => e.F)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("f");

                entity.Property(e => e.I)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("i");

                entity.Property(e => e.O)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("o");

                entity.Property(e => e.Pol).HasColumnName("pol");

                entity.Property(e => e.RezvitieNastoyaschegoZabol)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("rezvitie_nastoyaschego_zabol");
            });

            modelBuilder.Entity<Klinika>(entity =>
            {
                entity.HasKey(e => e.Adres)
                    .HasName("klinika_pkey");

                entity.ToTable("klinika");

                entity.Property(e => e.Adres)
                    .HasMaxLength(100)
                    .HasColumnName("adres");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Materiali>(entity =>
            {
                entity.HasKey(e => e.IdMaterial)
                    .HasName("materiali_pkey");

                entity.ToTable("materiali");

                entity.Property(e => e.IdMaterial).HasColumnName("id_material");

                entity.Property(e => e.DatePokupki)
                    .HasColumnType("date")
                    .HasColumnName("date_pokupki");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.SrokGodnosti)
                    .HasColumnType("date")
                    .HasColumnName("srok_godnosti");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.HasKey(e => e.IdPerson)
                    .HasName("personal_pkey");

                entity.ToTable("personal");

                entity.Property(e => e.IdPerson).HasColumnName("id_person");

                entity.Property(e => e.F)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("f");

                entity.Property(e => e.FkAdres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("fk_adres");

                entity.Property(e => e.I)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("i");

                entity.Property(e => e.MestoZhitelstva)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("mesto_zhitelstva");

                entity.Property(e => e.O)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("o");

                entity.Property(e => e.Rol).HasColumnName("rol");

                entity.Property(e => e.Stazh).HasColumnName("stazh");

                entity.HasOne(d => d.FkAdresNavigation)
                    .WithMany(p => p.Personals)
                    .HasForeignKey(d => d.FkAdres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_adres");
            });

            modelBuilder.Entity<Priem>(entity =>
            {
                entity.HasKey(e => e.IdPriema)
                    .HasName("id_priema_pkey");

                entity.ToTable("priem");

                entity.HasIndex(e => e.FkDateP, "priem_m")
                    .IsUnique();

                entity.Property(e => e.IdPriema).HasColumnName("id_priema");

                entity.Property(e => e.DannieRentgenOsmotra)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("dannie_rentgen_osmotra");

                entity.Property(e => e.DannieVneshnegoOsmotra)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("dannie_vneshnego_osmotra");

                entity.Property(e => e.FkDateP)
                    .HasColumnType("date")
                    .HasColumnName("fk_date_p");

                entity.Property(e => e.FkIdPerson)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("fk_id_person");

                entity.Property(e => e.FkTimeP)
                    .HasColumnType("time without time zone")
                    .HasColumnName("fk_time_p");

                entity.Property(e => e.Konsultatsii)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("konsultatsii");

                entity.Property(e => e.PlanLecheniya)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("plan_lecheniya");

                entity.Property(e => e.Zhalobi)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("zhalobi");

                entity.HasOne(d => d.FkDatePNavigation)
                    .WithOne(p => p.PriemFkDatePNavigation)
                    .HasPrincipalKey<Raspisanie>(p => p.DateP)
                    .HasForeignKey<Priem>(d => d.FkDateP)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_date_p");

                entity.HasOne(d => d.FkIdPersonNavigation)
                    .WithMany(p => p.Priems)
                    .HasForeignKey(d => d.FkIdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_person");

                entity.HasOne(d => d.FkTimePNavigation)
                    .WithMany(p => p.PriemFkTimePNavigations)
                    .HasPrincipalKey(p => p.TimeP)
                    .HasForeignKey(d => d.FkTimeP)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_time_p");
            });

            modelBuilder.Entity<Raspisanie>(entity =>
            {
                entity.HasKey(e => new { e.DateP, e.TimeP })
                    .HasName("respisanie_pkey");

                entity.ToTable("raspisanie");

                entity.HasIndex(e => e.DateP, "priem1")
                    .IsUnique();

                entity.HasIndex(e => e.TimeP, "priem2")
                    .IsUnique();

                entity.Property(e => e.DateP)
                    .HasColumnType("date")
                    .HasColumnName("date_p");

                entity.Property(e => e.TimeP)
                    .HasColumnType("time without time zone")
                    .HasColumnName("time_p");

                entity.Property(e => e.FkAdres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("fk_adres");

                entity.Property(e => e.FkIdMedKnigi)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("fk_id_med_knigi");

                entity.Property(e => e.FkIdPerson)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("fk_id_person");

                entity.Property(e => e.FkPasport)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("fk_pasport");

                entity.HasOne(d => d.FkAdresNavigation)
                    .WithMany(p => p.Raspisanies)
                    .HasForeignKey(d => d.FkAdres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_adres");

                entity.HasOne(d => d.FkIdMedKnigiNavigation)
                    .WithMany(p => p.RaspisanieFkIdMedKnigiNavigations)
                    .HasPrincipalKey(p => p.IdMedKnig)
                    .HasForeignKey(d => d.FkIdMedKnigi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_kniga");

                entity.HasOne(d => d.FkIdPersonNavigation)
                    .WithMany(p => p.Raspisanies)
                    .HasForeignKey(d => d.FkIdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_person");

                entity.HasOne(d => d.FkPasportNavigation)
                    .WithMany(p => p.RaspisanieFkPasportNavigations)
                    .HasPrincipalKey(p => p.Pasport)
                    .HasForeignKey(d => d.FkPasport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pasport");
            });

            modelBuilder.Entity<Uslugi>(entity =>
            {
                entity.HasKey(e => e.IdUslugi)
                    .HasName("uslugi_pkey");

                entity.ToTable("uslugi");

                entity.Property(e => e.IdUslugi).HasColumnName("id_uslugi");

                entity.Property(e => e.ColZatrMateriala).HasColumnName("col_zatr_materiala");

                entity.Property(e => e.FkAdres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("fk_adres");

                entity.Property(e => e.FkIdMateriala)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("fk_id_materiala");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.HasOne(d => d.FkAdresNavigation)
                    .WithMany(p => p.Uslugis)
                    .HasForeignKey(d => d.FkAdres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_adres");

                entity.HasOne(d => d.FkIdMaterialaNavigation)
                    .WithMany(p => p.Uslugis)
                    .HasForeignKey(d => d.FkIdMateriala)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_material");
            });

            modelBuilder.Entity<Zub>(entity =>
            {
                entity.HasKey(e => e.Zub1)
                    .HasName("zub_pkey");

                entity.ToTable("zub");

                entity.Property(e => e.Zub1)
                    .ValueGeneratedNever()
                    .HasColumnName("zub");

                entity.Property(e => e.FkIdMedKnig)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("fk_id_med_knig");

                entity.Property(e => e.FkPasport)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("fk_pasport");

                entity.HasOne(d => d.FkIdMedKnigNavigation)
                    .WithMany(p => p.ZubFkIdMedKnigNavigations)
                    .HasPrincipalKey(p => p.IdMedKnig)
                    .HasForeignKey(d => d.FkIdMedKnig)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_med_knig");

                entity.HasOne(d => d.FkPasportNavigation)
                    .WithMany(p => p.ZubFkPasportNavigations)
                    .HasPrincipalKey(p => p.Pasport)
                    .HasForeignKey(d => d.FkPasport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pasport");
            });

            modelBuilder.Entity<ZubHistory>(entity =>
            {
                entity.HasKey(e => e.Zub)
                    .HasName("zub_history_pkey");

                entity.ToTable("zub_history");

                entity.Property(e => e.Zub)
                    .ValueGeneratedNever()
                    .HasColumnName("zub");

                entity.Property(e => e.FkDateP)
                    .HasColumnType("date")
                    .HasColumnName("fk_date_p");

                entity.Property(e => e.FkIdPriema)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("fk_id_priema");

                entity.Property(e => e.FkIdUslugi)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("fk_id_uslugi");

                entity.HasOne(d => d.FkDatePNavigation)
                    .WithMany(p => p.ZubHistoryFkDatePNavigations)
                    .HasPrincipalKey(p => p.FkDateP)
                    .HasForeignKey(d => d.FkDateP)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_date");

                entity.HasOne(d => d.FkIdPriemaNavigation)
                    .WithMany(p => p.ZubHistoryFkIdPriemaNavigations)
                    .HasForeignKey(d => d.FkIdPriema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_priema");

                entity.HasOne(d => d.FkIdUslugiNavigation)
                    .WithMany(p => p.ZubHistories)
                    .HasForeignKey(d => d.FkIdUslugi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_uslugi");

                entity.HasOne(d => d.ZubNavigation)
                    .WithOne(p => p.ZubHistory)
                    .HasForeignKey<ZubHistory>(d => d.Zub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_zub");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

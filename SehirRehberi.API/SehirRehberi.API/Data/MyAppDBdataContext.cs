using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Data
{
    public class MyAppDatabaseContext : DbContext
    {
        public MyAppDatabaseContext(DbContextOptions<MyAppDatabaseContext> options) : base(options)
        {

        }

        #region yeni
        public DbSet<Kisiler> Kisiler { get; set; }

        public DbSet<KisiOgretmenler> KisiOgretmenler { get; set; }
        public DbSet<KisiOgrenciler> KisiOgrenciler { get; set; }
        public DbSet<KisiAdminler> KisiAdminler { get; set; }

        public DbSet<KisiAdresler> KisiAdresler { get; set; }
        public DbSet<KisiTelefonlar> KisiTelefonlar { get; set; }

        public DbSet<Dersler> Dersler { get; set; }
        public DbSet<DersDetaylar> DersDetaylar { get; set; }

        public DbSet<Takvimler> Takvimler { get; set; }
        public DbSet<Icerikler> Icerikler { get; set; }


        public DbSet<Kisiler_Dersler> Kisiler_Dersler { get; set; }
        public DbSet<Kisiler_Icerikler> Kisiler_Icerikler { get; set; }
        public DbSet<Kisiler_Takvimler> Kisiler_Takvimler { get; set; }

        public DbSet<LoginTracker> LoginTracker { get; set; }
        public DbSet<TestTuzel1> TestTuzel1 { get; set; }
        public DbSet<TestTuzel2> TestTuzel2 { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region yeni
            // --------------------------------------------
            // tüm     PK 1->1 ilişkiler
            // Kisiler(IdE) -> KisiOgretmenler(OgretmenIdE)
            // Kisiler(IdE) -> KisiOgrenciler (OgrenciIdE)
            // Kisiler(IdE) -> KisiAdminler   (AdminIdE)
            // https://www.learnentityframeworkcore.com/configuration/one-to-one-relationship-configuration
            modelBuilder.Entity<Kisiler>().HasOne(a => a.KisiOgretmenler).WithOne(b => b.Kisiler).HasForeignKey<KisiOgretmenler>(b => b.OgretmenIdE);// 1:1 hasone:withone
            modelBuilder.Entity<Kisiler>().HasOne(a => a.KisiOgrenciler).WithOne(b => b.Kisiler).HasForeignKey<KisiOgrenciler>(b => b.OgrenciIdE);// 1:1 hasone:withone
            modelBuilder.Entity<Kisiler>().HasOne(a => a.KisiAdminler).WithOne(b => b.Kisiler).HasForeignKey<KisiAdminler>(b => b.AdminIdE);// 1:1 hasone:withone

            // tüm     PK 1->N ilişkiler
            // Kisiler(IdE) -> KisiAdresler   (KisiIdE)
            // Kisiler(IdE) -> KisiTelefonlar (KisiIdE)
            // https://www.learnentityframeworkcore.com/configuration/one-to-many-relationship-configuration
            //modelBuilder.Entity<Kisiler>().HasMany(c => c.Adresleri).WithOne(e => e.Kisiler);// N:1 hasmany:withone  // gerek olmayabilir
            //modelBuilder.Entity<Kisiler>().HasMany(c => c.Telefonlari).WithOne(e => e.Kisiler);// N:1 hasmany:withone  // gerek olmayabilir
            //modelBuilder.Entity<Dersler>().HasMany(c => c.DersDetaylar).WithOne(e => e.Dersler);// N:1 hasmany:withone  // gerek olmayabilir


            // tüm     PK N->N ilişkiler (???????)
            //http://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx
            //http://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-ef-core.aspx
            //modelBuilder.Entity<Kisiler_Takvimler>().HasMany(c=>c.Kisiler.KisiOgretmenler.OgretmenIdE);

            // --------------------------------------------

            // diğerl...
            modelBuilder.Entity<Kisiler>().HasIndex(u => u.Username).IsUnique(true);
            modelBuilder.Entity<Kisiler>().HasIndex(u => u.Email).IsUnique(true);

            modelBuilder.Entity<KisiTelefonlar>().HasIndex(u => new { u.UlkeKodu, u.Telefonu }).IsUnique(true);

            modelBuilder.Entity<Icerikler>().HasIndex(u => u.BelgeAdi).IsUnique();
            modelBuilder.Entity<Icerikler>().HasIndex(u => u.BelgeLink).IsUnique();

            modelBuilder.Entity<Dersler>().HasIndex(u => u.Title).IsUnique();

            modelBuilder.Entity<Kisiler_Takvimler>().HasIndex(KT => new { KT.KisilerIdE, KT.TakvimlerIdE }).IsUnique(true); // süper oldu
            modelBuilder.Entity<Kisiler_Dersler>().HasIndex(KT => new { KT.KisilerIdE, KT.DerslerIdE }).IsUnique(true);
            modelBuilder.Entity<Kisiler_Icerikler>().HasIndex(KT => new { KT.KisilerIdE, KT.IceriklerIdE }).IsUnique(true);


            // https://stackoverflow.com/questions/41246614/entity-framework-core-add-unique-constraint-code-first
            #endregion
        }
    }
}

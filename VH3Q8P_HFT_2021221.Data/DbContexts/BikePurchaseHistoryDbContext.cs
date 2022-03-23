using Microsoft.EntityFrameworkCore;
using VH3Q8P_HFT_2021221.Models;
using VH3Q8P_HFT_2021221.Models.Entities;

namespace VH3Q8P_HFT_2021221.Data.DbContexts
{
    public class BikePurchaseHistoryDbContext : DbContext
    {
        public virtual DbSet<Manufacture> Manufactures { get; set; }
        public virtual DbSet<Bike> Bikes { get; set; }
        public virtual DbSet<Rider> Riders { get; set; }

        public BikePurchaseHistoryDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BikeDb.mdf;Integrated Security=true;MultipleActiveResultSets=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set relation
            modelBuilder.Entity<Bike>(e =>
                e.HasOne(b => b.Manufacture)
                .WithMany(m => m.Bikes)
                .HasForeignKey(b => b.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
            );

            modelBuilder.Entity<Bike>(e =>
                e.HasOne(b => b.Rider)
                .WithMany(m => m.Bikes)
                .HasForeignKey(b => b.RiderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
            );

            //Seed
            //Manufactures
            var trek = new Manufacture() { Id = 1, Name = "Trek Bicycle Corporation", Establishment_year = 1975, Income = 60000 };
            var devinci = new Manufacture() { Id = 2, Name = "Cycles Devinci", Establishment_year = 1987, Income = 1300 };
            var yt = new Manufacture() { Id = 3, Name = "YT Industries", Establishment_year = 2008, Income = 3500 };
            var specialized = new Manufacture() { Id = 4, Name = "Specialized Bicycles", Establishment_year = 1974, Income = 50000 };

            //Bikes
            var bike1 = new Bike() { Id = 1, Model_Name = "Spartan 2015 CF", Price = 5, BrandId = 2, RiderId = 1,Fix=true };
            var bike2 = new Bike() { Id = 2, Model_Name = "Troy 2017 CF", Price = 4, BrandId = 2, RiderId = 2,Fix=false};
            var bike3 = new Bike() { Id = 3, Model_Name = "Session 2016 9 X01", Price = 7, BrandId = 1, RiderId = 3,Fix=false };
            var bike4 = new Bike() { Id = 4, Model_Name = "Remedy 2018 X01", Price = 7, BrandId = 1, RiderId = 2 , Fix = false };
            var bike5 = new Bike() { Id = 5, Model_Name = "Capra 2018 CF", Price = 6, BrandId = 3, RiderId = 2, Fix = true };
            var bike6 = new Bike() { Id = 6, Model_Name = "Tues 2017 AL", Price = 4, BrandId = 3, RiderId = 2, Fix = false };
            var bike7 = new Bike() { Id = 7, Model_Name = "Enduro 2019 CF", Price = 9, BrandId = 4, RiderId = 3, Fix = false };
            var bike8 = new Bike() { Id = 8, Model_Name = "RockHopper 2016 CF", Price = 2, BrandId = 4, RiderId = 3, Fix = false };
            var bike9 = new Bike() { Id = 9, Model_Name = "TURBO LEVO SL", Price = 14, BrandId = 4, RiderId = 2, Fix = true };

            //Riders
            var rider1 = new Rider() { Id = 1, Name = "Merész Patrik", Age = 22 };
            var rider2 = new Rider() { Id = 2, Name = "Kis János", Age = 12 };
            var rider3 = new Rider() { Id = 3, Name = "Nagy Laci", Age = 32 };

            modelBuilder.Entity<Manufacture>().HasData(trek, devinci, yt, specialized);
            modelBuilder.Entity<Bike>().HasData(bike1, bike2, bike3, bike4, bike5, bike6, bike7, bike8, bike9);
            modelBuilder.Entity<Rider>().HasData(rider1, rider2, rider3);






        }
    }
}

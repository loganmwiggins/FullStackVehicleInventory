using Microsoft.EntityFrameworkCore;

namespace VehicleInventoryProj.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Color> Colors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString:
                "Server=localhost;Port=5432;User Id=postgres;Password=password;Database=vehicle-inventory;Include Error Detail=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// Tell EF core to use the ratings table as an association table between movies and users
            //modelBuilder.Entity<Movie>()
            //    .HasMany(m => m.Users)
            //    .WithMany(u => u.Movies)
            //    .UsingEntity<Rating>();

            base.OnModelCreating(modelBuilder);

            // Manually seed Colors table   
            modelBuilder.Entity<Color>().HasData(
                new Color { ColorId = 1, Name = "Midnight Black" },
                new Color { ColorId = 2, Name = "Ruby Flare Pearl" },
                new Color { ColorId = 3, Name = "Blueprint" },
                new Color { ColorId = 4, Name = "Cypress" },
                new Color { ColorId = 5, Name = "Magentic Gray" },
                new Color { ColorId = 6, Name = "Wind Chill Pearl" }
            );

            // Manually seed Vehicles table   
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { VehicleId = 1, Make = "Toyota", Model = "Corolla", Year = 2025, Build = "Sedan", FuelType = "Gas", MSRP = 22175, CityMPG = 32, HwyMPG = 41, InStock = true, ColorId = 1 },
                new Vehicle { VehicleId = 2, Make = "Toyota", Model = "Tacoma", Year = 2024, Build = "Truck", FuelType = "Gas", MSRP = 31500, CityMPG = 21, HwyMPG = 26, InStock = true, ColorId = 2 },
                new Vehicle { VehicleId = 3, Make = "Toyota", Model = "Prius", Year = 2024, Build = "Sedan", FuelType = "Hybrid", MSRP = 27950, CityMPG = 57, HwyMPG = 56, InStock = false, ColorId = 3 },
                new Vehicle { VehicleId = 4, Make = "Toyota", Model = "Tundra", Year = 2024, Build = "Truck", FuelType = "Gas", MSRP = 40090, CityMPG = 18, HwyMPG = 23, InStock = false, ColorId = 4 },
                new Vehicle { VehicleId = 5, Make = "Toyota", Model = "Highlander Hybrid", Year = 2024, Build = "SUV", FuelType = "Hyrbid", MSRP = 40970, CityMPG = 36, HwyMPG = 35, InStock = true, ColorId = 6 }
            );
        }
    }
}
using Microsoft.EntityFrameworkCore;

namespace VehicleInventoryProj.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

        // Tables
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Color> Colors { get; set; }

        // Configuration
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
                new Vehicle { 
                    VehicleId = 1, 
                    Make = "Toyota", 
                    Model = "Corolla", 
                    Year = 2025, 
                    Build = "Sedan", 
                    FuelType = "Gas", 
                    MSRP = 22175, 
                    ImgPath = "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2025/corolla/base.png?bg=fff&fmt=webp&qlt=90&wid=345",
                    CityMPG = 32, 
                    HwyMPG = 41, 
                    InStock = true, 
                    ColorId = 1 
                },
                new Vehicle { 
                    VehicleId = 2, 
                    Make = "Toyota", 
                    Model = "Tacoma", 
                    Year = 2024, 
                    Build = "Truck", 
                    FuelType = "Gas", 
                    MSRP = 31500, 
                    ImgPath = "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2024/tacoma/base.png?bg=fff&fmt=webp&qlt=90&wid=345",
                    CityMPG = 21, 
                    HwyMPG = 26, 
                    InStock = true, 
                    ColorId = 2 
                },
                new Vehicle { 
                    VehicleId = 3, 
                    Make = "Toyota", 
                    Model = "Prius", 
                    Year = 2024, 
                    Build = "Sedan", 
                    FuelType = "Hybrid", 
                    MSRP = 27950, 
                    ImgPath= "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2024/prius/base.png?bg=fff&fmt=webp&qlt=90&wid=345",
                    CityMPG = 57,
                    HwyMPG = 56, 
                    InStock = false, 
                    ColorId = 3 
                },
                new Vehicle { 
                    VehicleId = 4, 
                    Make = "Toyota", 
                    Model = "Tundra", 
                    Year = 2024, 
                    Build = "Truck", 
                    FuelType = "Gas", 
                    MSRP = 40090, 
                    ImgPath = "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2024/tundra/base.png?bg=fff&fmt=webp&qlt=90&wid=345",
                    CityMPG = 18, 
                    HwyMPG = 23, 
                    InStock = false, 
                    ColorId = 4 
                },
                new Vehicle { 
                    VehicleId = 5, 
                    Make = "Toyota", 
                    Model = "Highlander Hybrid", 
                    Year = 2024, 
                    Build = "SUV", 
                    FuelType = "Hyrbid",
                    MSRP = 40970,
                    ImgPath = "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2024/highlanderhybrid/base.png?bg=fff&fmt=webp&qlt=90&wid=345",
                    CityMPG = 36, 
                    HwyMPG = 35, 
                    InStock = true, 
                    ColorId = 6 
                },
                new Vehicle
                {
                    VehicleId = 6,
                    Make = "Toyota",
                    Model = "bZ4X",
                    Year = 2024,
                    Build = "SUV",
                    FuelType = "Electric",
                    MSRP = 43070,
                    ImgPath = "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2024/bz4x/base.png?bg=fff&fmt=webp&qlt=90&wid=345",
                    InStock = true,
                    ColorId = 3
                },
                new Vehicle
                {
                    VehicleId = 7,
                    Make = "Toyota",
                    Model = "GR86",
                    Year = 2024,
                    Build = "Sedan",
                    FuelType = "Gas",
                    MSRP = 29300,
                    ImgPath = "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2024/gr86/base.png?bg=fff&fmt=webp&qlt=90&wid=345",
                    CityMPG = 20,
                    HwyMPG = 26,
                    InStock = true,
                    ColorId = 1
                },
                new Vehicle
                {
                    VehicleId = 8,
                    Make = "Toyota",
                    Model = "GR Supra",
                    Year = 2025,
                    Build = "Sedan",
                    FuelType = "Gas",
                    MSRP = 56250,
                    ImgPath = "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2025/grsupra/base.png?bg=fff&fmt=webp&qlt=90&wid=345",
                    CityMPG = 23,
                    HwyMPG = 31,
                    InStock = false,
                    ColorId = 3
                },
                new Vehicle
                {
                    VehicleId = 9,
                    Make = "Toyota",
                    Model = "Mirai",
                    Year = 2025,
                    Build = "Sedan",
                    FuelType = "Hydrogen",
                    MSRP = 50190,
                    ImgPath = "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2024/mirai/base.png?bg=fff&fmt=webp&qlt=90&wid=345",
                    CityMPG = 76,
                    HwyMPG = 71,
                    InStock = true,
                    ColorId = 4
                },
                new Vehicle
                {
                    VehicleId = 10,
                    Make = "Toyota",
                    Model = "Venza",
                    Year = 2024,
                    Build = "SUV",
                    FuelType = "Hybrid",
                    MSRP = 35070,
                    ImgPath = "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2024/venza/base.png?bg=fff&fmt=webp&qlt=90&wid=345",
                    CityMPG = 40,
                    HwyMPG = 37,
                    InStock = true,
                    ColorId = 3
                },
                new Vehicle
                {
                    VehicleId = 11,
                    Make = "Toyota",
                    Model = "Crown",
                    Year = 2025,
                    Build = "Sedan",
                    FuelType = "Hybrid",
                    MSRP = 41440,
                    ImgPath = "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2025/toyotacrown/base.png?bg=fff&fmt=webp&qlt=90&wid=345",
                    CityMPG = 42,
                    HwyMPG = 41,
                    InStock = true,
                    ColorId = 5
                },
                new Vehicle
                {
                    VehicleId = 12,
                    Make = "Toyota",
                    Model = "Land Cruiser",
                    Year = 2025,
                    Build = "SUV",
                    FuelType = "Hybrid",
                    MSRP = 56450,
                    ImgPath = "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2025/landcruiser/base.png?bg=fff&fmt=webp&qlt=90&wid=345",
                    CityMPG = 22,
                    HwyMPG = 25,
                    InStock = true,
                    ColorId = 2
                }
            );
        }
    }
}
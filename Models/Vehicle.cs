using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleInventoryProj.Models
{
    [Table("vehicles")]
    public class Vehicle
    {
        [Column("vehicle_id")]
        public required int VehicleId { get; set; }

        [Column("make", TypeName="varchar(25)")]
        public required string Make { get; set; }

        [Column("model", TypeName = "varchar(100)")]
        public required string Model { get; set; }

        [Column("year")]
        public required int Year { get; set; }

        [Column("build", TypeName = "varchar(50)")]
        public required string Build { get; set; } // Sedan, Truck, SUV, Crossover, Minivan

        [Column("fuel_type", TypeName = "varchar(50)")]
        public required string FuelType { get; set; } // Gas, EV, Hybrid, Hydrogen

        [Column("msrp")]
        public required int MSRP { get; set; }

        [Column("img_path")]
        public string? ImgPath { get; set; }

        [Column("city_mpg")]
        public int? CityMPG { get; set; }

        [Column("hwy_mpg")]
        public int? HwyMPG { get; set; }

        [Column("in_stock")]
        public required bool InStock { get; set; }


        [ForeignKey("Color")]
        [Column("color_id")]
        public int ColorId { get; set; }
        public Color Color { get; set; } = null!;
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleInventoryProj.Models
{
    [Table("colors")]
    public class Color
    {
        [Column("color")]
        public required int ColorId { get; set; }

        [Column("name", TypeName = "varchar(100)")]
        public required string Name { get; set; }

        public List<Vehicle> Vehicles { get;  } = [];
    }
}
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleInventoryProj.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreSeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 6,
                columns: new[] { "city_mpg", "color_id", "fuel_type", "hwy_mpg", "img_path", "msrp" },
                values: new object[] { null, 3, "Electric", null, "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2024/bz4x/base.png?bg=fff&fmt=webp&qlt=90&wid=345", 43070 });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "vehicle_id", "build", "city_mpg", "color_id", "fuel_type", "hwy_mpg", "img_path", "in_stock", "msrp", "make", "model", "year" },
                values: new object[,]
                {
                    { 7, "Sedan", 20, 1, "Gas", 26, "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2024/gr86/base.png?bg=fff&fmt=webp&qlt=90&wid=345", true, 29300, "Toyota", "GR86", 2024 },
                    { 8, "Sedan", 23, 3, "Gas", 31, "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2025/grsupra/base.png?bg=fff&fmt=webp&qlt=90&wid=345", false, 56250, "Toyota", "GR Supra", 2025 },
                    { 9, "Sedan", 76, 4, "Hydrogen", 71, "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2024/mirai/base.png?bg=fff&fmt=webp&qlt=90&wid=345", true, 50190, "Toyota", "Mirai", 2025 },
                    { 10, "SUV", 40, 3, "Hybrid", 37, "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2024/venza/base.png?bg=fff&fmt=webp&qlt=90&wid=345", true, 35070, "Toyota", "Venza", 2024 },
                    { 11, "Sedan", 42, 5, "Hybrid", 41, "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2025/toyotacrown/base.png?bg=fff&fmt=webp&qlt=90&wid=345", true, 41440, "Toyota", "Crown", 2025 },
                    { 12, "SUV", 22, 2, "Hybrid", 25, "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2025/landcruiser/base.png?bg=fff&fmt=webp&qlt=90&wid=345", true, 56450, "Toyota", "Land Cruiser", 2025 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 6,
                columns: new[] { "city_mpg", "color_id", "fuel_type", "hwy_mpg", "img_path", "msrp" },
                values: new object[] { 0, 6, "Hyrbid", 0, "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2024/highlanderhybrid/base.png?bg=fff&fmt=webp&qlt=90&wid=345", 40970 });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleInventoryProj.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "colors",
                columns: table => new
                {
                    color = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colors", x => x.color);
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    vehicle_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    make = table.Column<string>(type: "varchar(25)", nullable: false),
                    model = table.Column<string>(type: "varchar(100)", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    build = table.Column<string>(type: "varchar(50)", nullable: false),
                    fuel_type = table.Column<string>(type: "varchar(50)", nullable: false),
                    msrp = table.Column<int>(type: "integer", nullable: false),
                    img_path = table.Column<string>(type: "text", nullable: true),
                    city_mpg = table.Column<int>(type: "integer", nullable: false),
                    hwy_mpg = table.Column<int>(type: "integer", nullable: false),
                    in_stock = table.Column<bool>(type: "boolean", nullable: false),
                    color_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.vehicle_id);
                    table.ForeignKey(
                        name: "FK_vehicles_colors_color_id",
                        column: x => x.color_id,
                        principalTable: "colors",
                        principalColumn: "color",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "colors",
                columns: new[] { "color", "name" },
                values: new object[,]
                {
                    { 1, "Midnight Black" },
                    { 2, "Ruby Flare Pearl" },
                    { 3, "Blueprint" },
                    { 4, "Cypress" },
                    { 5, "Magentic Gray" },
                    { 6, "Wind Chill Pearl" }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "vehicle_id", "build", "city_mpg", "color_id", "fuel_type", "hwy_mpg", "img_path", "in_stock", "msrp", "make", "model", "year" },
                values: new object[,]
                {
                    { 1, "Sedan", 32, 1, "Gas", 41, null, true, 22175, "Toyota", "Corolla", 2025 },
                    { 2, "Truck", 21, 2, "Gas", 26, null, true, 31500, "Toyota", "Tacoma", 2024 },
                    { 3, "Sedan", 57, 3, "Hybrid", 56, null, false, 27950, "Toyota", "Prius", 2024 },
                    { 4, "Truck", 18, 4, "Gas", 23, null, false, 40090, "Toyota", "Tundra", 2024 },
                    { 5, "SUV", 36, 6, "Hyrbid", 35, null, true, 40970, "Toyota", "Highlander Hybrid", 2024 },
                    { 6, "SUV", null, 3, "Electric", null, null, true, 43070, "Toyota", "bZ4X", 2024 },
                    { 7, "Sedan", 20, 1, "Gas", 26, null, true, 29300, "Toyota", "GR86", 2024 },
                    { 8, "Sedan", 23, 3, "Gas", 31, null, false, 56250, "Toyota", "GR Supra", 2025 },
                    { 9, "Sedan", 76, 4, "Hydrogen", 71, null, true, 50190, "Toyota", "Mirai", 2025 },
                    { 10, "SUV", 40, 3, "Hyrbid", 37, null, true, 35070, "Toyota", "Venza", 2024 },
                    { 11, "Sedan", 42, 5, "Hybrid", 41, null, true, 41440, "Toyota", "Crown", 2025 },
                    { 12, "SUV", 22, 2, "Hybrid", 25, null, true, 56450, "Toyota", "Land Cruiser", 2025 },
                });

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_color_id",
                table: "vehicles",
                column: "color_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "colors");
        }
    }
}

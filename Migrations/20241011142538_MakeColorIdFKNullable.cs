using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleInventoryProj.Migrations
{
    /// <inheritdoc />
    public partial class MakeColorIdFKNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_colors_color_id",
                table: "vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "color_id",
                table: "vehicles",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_colors_color_id",
                table: "vehicles",
                column: "color_id",
                principalTable: "colors",
                principalColumn: "color");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_colors_color_id",
                table: "vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "color_id",
                table: "vehicles",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_colors_color_id",
                table: "vehicles",
                column: "color_id",
                principalTable: "colors",
                principalColumn: "color",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

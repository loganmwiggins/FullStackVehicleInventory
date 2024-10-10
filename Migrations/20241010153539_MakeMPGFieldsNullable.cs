using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleInventoryProj.Migrations
{
    /// <inheritdoc />
    public partial class MakeMPGFieldsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "hwy_mpg",
                table: "vehicles",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "city_mpg",
                table: "vehicles",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 1,
                column: "img_path",
                value: "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2025/corolla/base.png?bg=fff&fmt=webp&qlt=90&wid=345");

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 2,
                column: "img_path",
                value: "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2024/tacoma/base.png?bg=fff&fmt=webp&qlt=90&wid=345");

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 3,
                column: "img_path",
                value: "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2024/prius/base.png?bg=fff&fmt=webp&qlt=90&wid=345");

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 4,
                column: "img_path",
                value: "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2024/tundra/base.png?bg=fff&fmt=webp&qlt=90&wid=345");

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 5,
                column: "img_path",
                value: "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2024/highlanderhybrid/base.png?bg=fff&fmt=webp&qlt=90&wid=345");

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "vehicle_id", "build", "city_mpg", "color_id", "fuel_type", "hwy_mpg", "img_path", "in_stock", "msrp", "make", "model", "year" },
                values: new object[] { 6, "SUV", 0, 6, "Hyrbid", 0, "https://tmna.aemassets.toyota.com/is/image/toyota/toyota/jellies/relative/2024/highlanderhybrid/base.png?bg=fff&fmt=webp&qlt=90&wid=345", true, 40970, "Toyota", "bZ4X", 2024 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 6);

            migrationBuilder.AlterColumn<int>(
                name: "hwy_mpg",
                table: "vehicles",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "city_mpg",
                table: "vehicles",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 1,
                column: "img_path",
                value: null);

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 2,
                column: "img_path",
                value: null);

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 3,
                column: "img_path",
                value: null);

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 4,
                column: "img_path",
                value: null);

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "vehicle_id",
                keyValue: 5,
                column: "img_path",
                value: null);
        }
    }
}

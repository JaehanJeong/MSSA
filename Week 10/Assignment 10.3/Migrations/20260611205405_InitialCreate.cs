using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment_10._3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    VIN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.VIN);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "VIN", "Make", "Model", "Price", "Year" },
                values: new object[,]
                {
                    { 1234, "Toyota", "Prius", 20000.0, 2020 },
                    { 2345, "Honda", "Civic", 25000.0, 2023 },
                    { 3456, "Tesla", "Cyber Truck", 50000.0, 2024 },
                    { 4567, "Hyundai", "Ioniq", 40000.0, 2026 },
                    { 5678, "Ford", "F150", 40000.0, 2026 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}

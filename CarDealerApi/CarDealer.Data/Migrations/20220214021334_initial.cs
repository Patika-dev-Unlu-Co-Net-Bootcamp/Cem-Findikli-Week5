using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealer.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Km = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarFeatures_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Brand", "CreatedDate", "UpdatedDate" },
                values: new object[] { 1, "Sedan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Brand", "CreatedDate", "UpdatedDate" },
                values: new object[] { 2, "Suv", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Brand", "CreatedDate", "UpdatedDate" },
                values: new object[] { 3, "Cabrio", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "CategoryId", "CreatedDate", "Model", "Price", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Xc90", 1, new DateTime(2022, 2, 14, 5, 13, 34, 19, DateTimeKind.Local).AddTicks(8202), "Volvo", 800000m, null },
                    { 2, "Mercedes", 1, new DateTime(2022, 2, 14, 5, 13, 34, 20, DateTimeKind.Local).AddTicks(6648), "A180", 550000m, null },
                    { 3, "3.20i", 1, new DateTime(2022, 2, 14, 5, 13, 34, 20, DateTimeKind.Local).AddTicks(6665), "Bmw", 600000m, null },
                    { 4, "Focus", 2, new DateTime(2022, 2, 14, 5, 13, 34, 20, DateTimeKind.Local).AddTicks(6668), "Ford", 600000m, null },
                    { 5, "Kuga", 2, new DateTime(2022, 2, 14, 5, 13, 34, 20, DateTimeKind.Local).AddTicks(6670), "Ford", 660000m, null }
                });

            migrationBuilder.InsertData(
                table: "CarFeatures",
                columns: new[] { "Id", "CarId", "Color", "Km", "Year" },
                values: new object[] { 1, 1, "Kırmızı", 100000, 2009 });

            migrationBuilder.InsertData(
                table: "CarFeatures",
                columns: new[] { "Id", "CarId", "Color", "Km", "Year" },
                values: new object[] { 2, 2, "Siyah", 320000, 2016 });

            migrationBuilder.CreateIndex(
                name: "IX_CarFeatures_CarId",
                table: "CarFeatures",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarFeatures");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

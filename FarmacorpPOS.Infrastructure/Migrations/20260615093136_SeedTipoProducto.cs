using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FarmacorpPOS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedTipoProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TipoProducto",
                columns: new[] { "IdTipoProducto", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Medicamento" },
                    { 2, "Cosmético" },
                    { 3, "Higiene" },
                    { 4, "Suplemento" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TipoProducto",
                keyColumn: "IdTipoProducto",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoProducto",
                keyColumn: "IdTipoProducto",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoProducto",
                keyColumn: "IdTipoProducto",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipoProducto",
                keyColumn: "IdTipoProducto",
                keyValue: 4);
        }
    }
}

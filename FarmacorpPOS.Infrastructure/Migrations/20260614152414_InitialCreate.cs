using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmacorpPOS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdCategoriaPadre = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                    table.ForeignKey(
                        name: "FK_Categoria_Categoria_IdCategoriaPadre",
                        column: x => x.IdCategoriaPadre,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoProducto",
                columns: table => new
                {
                    IdTipoProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProducto", x => x.IdTipoProducto);
                });

            migrationBuilder.CreateTable(
                name: "ExpProducto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTipoProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpProducto", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_ExpProducto_TipoProducto_IdTipoProducto",
                        column: x => x.IdTipoProducto,
                        principalTable: "TipoProducto",
                        principalColumn: "IdTipoProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CodigoBarra",
                columns: table => new
                {
                    IdCodigoBarra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueCodigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigoBarra", x => x.IdCodigoBarra);
                    table.ForeignKey(
                        name: "FK_CodigoBarra_ExpProducto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "ExpProducto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErpProducto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UniqueCodigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpProducto", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_ErpProducto_ExpProducto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "ExpProducto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoCategoria",
                columns: table => new
                {
                    IdDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoCategoria", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK_ProductoCategoria_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoCategoria_ExpProducto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "ExpProducto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VentaExpress",
                columns: table => new
                {
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cliente = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    UniqueCodigoProducto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaExpress", x => x.IdVenta);
                    table.ForeignKey(
                        name: "FK_VentaExpress_ExpProducto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "ExpProducto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_IdCategoriaPadre",
                table: "Categoria",
                column: "IdCategoriaPadre");

            migrationBuilder.CreateIndex(
                name: "IX_CodigoBarra_IdProducto",
                table: "CodigoBarra",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_CodigoBarra_UniqueCodigo",
                table: "CodigoBarra",
                column: "UniqueCodigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ErpProducto_UniqueCodigo",
                table: "ErpProducto",
                column: "UniqueCodigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpProducto_IdTipoProducto",
                table: "ExpProducto",
                column: "IdTipoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCategoria_IdCategoria",
                table: "ProductoCategoria",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCategoria_IdProducto",
                table: "ProductoCategoria",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_VentaExpress_IdProducto",
                table: "VentaExpress",
                column: "IdProducto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodigoBarra");

            migrationBuilder.DropTable(
                name: "ErpProducto");

            migrationBuilder.DropTable(
                name: "ProductoCategoria");

            migrationBuilder.DropTable(
                name: "VentaExpress");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "ExpProducto");

            migrationBuilder.DropTable(
                name: "TipoProducto");
        }
    }
}

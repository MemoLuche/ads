using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiProyectoPortable.Migrations
{
    /// <inheritdoc />
    public partial class CorregirFechasEnSeedPropiedades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Propiedades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    TipoOperacion = table.Column<string>(type: "TEXT", nullable: false),
                    TipoPropiedad = table.Column<string>(type: "TEXT", nullable: false),
                    Ubicacion = table.Column<string>(type: "TEXT", nullable: false),
                    Habitaciones = table.Column<int>(type: "INTEGER", nullable: true),
                    Banos = table.Column<int>(type: "INTEGER", nullable: true),
                    MetrosCuadrados = table.Column<int>(type: "INTEGER", nullable: true),
                    Cocheras = table.Column<int>(type: "INTEGER", nullable: true),
                    RutaImagenPrincipal = table.Column<string>(type: "TEXT", nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EsDestacada = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propiedades", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Propiedades",
                columns: new[] { "Id", "Banos", "Cocheras", "Descripcion", "EsDestacada", "FechaPublicacion", "Habitaciones", "MetrosCuadrados", "Precio", "RutaImagenPrincipal", "TipoOperacion", "TipoPropiedad", "Titulo", "Ubicacion" },
                values: new object[,]
                {
                    { 1, 2, 2, "Hermosa casa con acabados de lujo y amplio jardín.", false, new DateTime(2024, 5, 10, 12, 0, 0, 0, DateTimeKind.Utc), 3, 250, 4500000m, "/images/propiedad-ejemplo-1.jpg", "Venta", "Casa", "Casa Moderna en Juriquilla", "Juriquilla, Querétaro" },
                    { 2, 1, 1, "Luminoso departamento de 2 recámaras cerca de todos los servicios.", false, new DateTime(2024, 5, 15, 15, 30, 0, 0, DateTimeKind.Utc), 2, 90, 12000m, "/images/propiedad-ejemplo-2.jpg", "Renta", "Departamento", "Departamento Céntrico Ideal para Inversión", "Centro, Querétaro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Propiedades");
        }
    }
}

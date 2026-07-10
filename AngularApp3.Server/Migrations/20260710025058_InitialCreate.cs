using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AngularApp3.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreEmpresa = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Contacto = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Disenadores",
                columns: table => new
                {
                    DisenadorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Especialidad = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disenadores", x => x.DisenadorId);
                });

            migrationBuilder.CreateTable(
                name: "Campanas",
                columns: table => new
                {
                    CampanaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Presupuesto = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanas", x => x.CampanaId);
                    table.ForeignKey(
                        name: "FK_Campanas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entregables",
                columns: table => new
                {
                    EntregableId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CampanaId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisenadorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregables", x => x.EntregableId);
                    table.ForeignKey(
                        name: "FK_Entregables_Campanas_CampanaId",
                        column: x => x.CampanaId,
                        principalTable: "Campanas",
                        principalColumn: "CampanaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entregables_Disenadores_DisenadorId",
                        column: x => x.DisenadorId,
                        principalTable: "Disenadores",
                        principalColumn: "DisenadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Contacto", "Email", "NombreEmpresa", "Telefono" },
                values: new object[,]
                {
                    { 1, "Ana Torres", "ana@cafecentral.com", "Café Central", "0991234567" },
                    { 2, "Luis Mora", "luis@deportesandinos.com", "Deportes Andinos", "0987654321" },
                    { 3, "María López", "maria@clinicavida.com", "Clínica Vida", "0974455667" },
                    { 4, "Carlos Ruiz", "carlos@ecohogar.com", "EcoHogar", "0961122334" }
                });

            migrationBuilder.InsertData(
                table: "Disenadores",
                columns: new[] { "DisenadorId", "Email", "Especialidad", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "sofia@agencia.com", "Diseño gráfico", "Sofía Vega", "0995551100" },
                    { 2, "mateo@agencia.com", "Diseño web", "Mateo Paz", "0985552200" },
                    { 3, "valentina@agencia.com", "Ilustración", "Valentina Cruz", "0975553300" },
                    { 4, "diego@agencia.com", "Contenido audiovisual", "Diego León", "0965554400" }
                });

            migrationBuilder.InsertData(
                table: "Campanas",
                columns: new[] { "CampanaId", "ClienteId", "FechaInicio", "Nombre", "Presupuesto" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sabor de temporada", 8500m },
                    { 2, 2, new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corre Ecuador", 15000m },
                    { 3, 3, new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chequeo a tiempo", 12000m },
                    { 4, 4, new DateTime(2026, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hogar sostenible", 9750m }
                });

            migrationBuilder.InsertData(
                table: "Entregables",
                columns: new[] { "EntregableId", "CampanaId", "DisenadorId", "FechaEntrega", "Tipo" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Identidad visual" },
                    { 2, 1, 3, new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Publicaciones para redes" },
                    { 3, 2, 4, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Video promocional" },
                    { 4, 3, 2, new DateTime(2026, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Página de campaña" },
                    { 5, 4, 1, new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Catálogo digital" },
                    { 6, 2, 3, new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afiches" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campanas_ClienteId",
                table: "Campanas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Entregables_CampanaId",
                table: "Entregables",
                column: "CampanaId");

            migrationBuilder.CreateIndex(
                name: "IX_Entregables_DisenadorId",
                table: "Entregables",
                column: "DisenadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entregables");

            migrationBuilder.DropTable(
                name: "Campanas");

            migrationBuilder.DropTable(
                name: "Disenadores");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}

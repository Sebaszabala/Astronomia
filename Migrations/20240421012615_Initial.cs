using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AstronomiaEjercicio.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instituto",
                columns: table => new
                {
                    Id_Instituto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreInstituto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituto", x => x.Id_Instituto);
                });

            migrationBuilder.CreateTable(
                name: "Telescopios",
                columns: table => new
                {
                    Id_telescopio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTelescopio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diametro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telescopios", x => x.Id_telescopio);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Objeto",
                columns: table => new
                {
                    Id_TiposObjetos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Objeto", x => x.Id_TiposObjetos);
                });

            migrationBuilder.CreateTable(
                name: "Observador",
                columns: table => new
                {
                    Id_Observador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instituto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Instituto = table.Column<int>(type: "int", nullable: false),
                    InstitutosId_Instituto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observador", x => x.Id_Observador);
                    table.ForeignKey(
                        name: "FK_Observador_Instituto_InstitutosId_Instituto",
                        column: x => x.InstitutosId_Instituto,
                        principalTable: "Instituto",
                        principalColumn: "Id_Instituto");
                });

            migrationBuilder.CreateTable(
                name: "Caracteristicas",
                columns: table => new
                {
                    Id_Caracteristicas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caracteristica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_TiposObjetos = table.Column<int>(type: "int", nullable: false),
                    Tipos_ObjetosId_TiposObjetos = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracteristicas", x => x.Id_Caracteristicas);
                    table.ForeignKey(
                        name: "FK_Caracteristicas_Tipo_Objeto_Tipos_ObjetosId_TiposObjetos",
                        column: x => x.Tipos_ObjetosId_TiposObjetos,
                        principalTable: "Tipo_Objeto",
                        principalColumn: "Id_TiposObjetos");
                });

            migrationBuilder.CreateTable(
                name: "Observacion",
                columns: table => new
                {
                    Id_Observacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coordenadas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Magnitud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Telescopio = table.Column<int>(type: "int", nullable: false),
                    TelescopioId_telescopio = table.Column<int>(type: "int", nullable: true),
                    Id_TipoObjeto = table.Column<int>(type: "int", nullable: false),
                    Tipos_ObjetosId_TiposObjetos = table.Column<int>(type: "int", nullable: true),
                    Id_Observador = table.Column<int>(type: "int", nullable: false),
                    ObservadoresId_Observador = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observacion", x => x.Id_Observacion);
                    table.ForeignKey(
                        name: "FK_Observacion_Observador_ObservadoresId_Observador",
                        column: x => x.ObservadoresId_Observador,
                        principalTable: "Observador",
                        principalColumn: "Id_Observador");
                    table.ForeignKey(
                        name: "FK_Observacion_Telescopios_TelescopioId_telescopio",
                        column: x => x.TelescopioId_telescopio,
                        principalTable: "Telescopios",
                        principalColumn: "Id_telescopio");
                    table.ForeignKey(
                        name: "FK_Observacion_Tipo_Objeto_Tipos_ObjetosId_TiposObjetos",
                        column: x => x.Tipos_ObjetosId_TiposObjetos,
                        principalTable: "Tipo_Objeto",
                        principalColumn: "Id_TiposObjetos");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caracteristicas_Tipos_ObjetosId_TiposObjetos",
                table: "Caracteristicas",
                column: "Tipos_ObjetosId_TiposObjetos");

            migrationBuilder.CreateIndex(
                name: "IX_Observacion_ObservadoresId_Observador",
                table: "Observacion",
                column: "ObservadoresId_Observador");

            migrationBuilder.CreateIndex(
                name: "IX_Observacion_TelescopioId_telescopio",
                table: "Observacion",
                column: "TelescopioId_telescopio");

            migrationBuilder.CreateIndex(
                name: "IX_Observacion_Tipos_ObjetosId_TiposObjetos",
                table: "Observacion",
                column: "Tipos_ObjetosId_TiposObjetos");

            migrationBuilder.CreateIndex(
                name: "IX_Observador_InstitutosId_Instituto",
                table: "Observador",
                column: "InstitutosId_Instituto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caracteristicas");

            migrationBuilder.DropTable(
                name: "Observacion");

            migrationBuilder.DropTable(
                name: "Observador");

            migrationBuilder.DropTable(
                name: "Telescopios");

            migrationBuilder.DropTable(
                name: "Tipo_Objeto");

            migrationBuilder.DropTable(
                name: "Instituto");
        }
    }
}

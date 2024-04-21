using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AstronomiaEjercicio.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caracteristica_Tipo_Objeto_Tipos_ObjetosId_TiposObjetos",
                table: "Caracteristica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Caracteristica",
                table: "Caracteristica");

            migrationBuilder.RenameTable(
                name: "Caracteristica",
                newName: "Caracteristicas");

            migrationBuilder.RenameIndex(
                name: "IX_Caracteristica_Tipos_ObjetosId_TiposObjetos",
                table: "Caracteristicas",
                newName: "IX_Caracteristicas_Tipos_ObjetosId_TiposObjetos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Caracteristicas",
                table: "Caracteristicas",
                column: "Id_Caracteristicas");

            migrationBuilder.AddForeignKey(
                name: "FK_Caracteristicas_Tipo_Objeto_Tipos_ObjetosId_TiposObjetos",
                table: "Caracteristicas",
                column: "Tipos_ObjetosId_TiposObjetos",
                principalTable: "Tipo_Objeto",
                principalColumn: "Id_TiposObjetos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caracteristicas_Tipo_Objeto_Tipos_ObjetosId_TiposObjetos",
                table: "Caracteristicas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Caracteristicas",
                table: "Caracteristicas");

            migrationBuilder.RenameTable(
                name: "Caracteristicas",
                newName: "Caracteristica");

            migrationBuilder.RenameIndex(
                name: "IX_Caracteristicas_Tipos_ObjetosId_TiposObjetos",
                table: "Caracteristica",
                newName: "IX_Caracteristica_Tipos_ObjetosId_TiposObjetos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Caracteristica",
                table: "Caracteristica",
                column: "Id_Caracteristicas");

            migrationBuilder.AddForeignKey(
                name: "FK_Caracteristica_Tipo_Objeto_Tipos_ObjetosId_TiposObjetos",
                table: "Caracteristica",
                column: "Tipos_ObjetosId_TiposObjetos",
                principalTable: "Tipo_Objeto",
                principalColumn: "Id_TiposObjetos");
        }
    }
}

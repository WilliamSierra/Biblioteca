using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaV4.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autor_IdAutor",
                table: "Libros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Autor",
                table: "Autor");

            migrationBuilder.RenameTable(
                name: "Autor",
                newName: "Autores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autores",
                table: "Autores",
                column: "IdAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_IdAutor",
                table: "Libros",
                column: "IdAutor",
                principalTable: "Autores",
                principalColumn: "IdAutor",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_IdAutor",
                table: "Libros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Autores",
                table: "Autores");

            migrationBuilder.RenameTable(
                name: "Autores",
                newName: "Autor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autor",
                table: "Autor",
                column: "IdAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autor_IdAutor",
                table: "Libros",
                column: "IdAutor",
                principalTable: "Autor",
                principalColumn: "IdAutor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

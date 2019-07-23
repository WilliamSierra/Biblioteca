using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaV4.Migrations
{
    public partial class categorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Categorias_CategoriaId",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_IdAutor",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_IdAutor",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "IdAutor",
                table: "Libros");

            migrationBuilder.RenameColumn(
                name: "IdCategoria",
                table: "Libros",
                newName: "AutorId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Libros",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_AutorId",
                table: "Libros",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_AutorId",
                table: "Libros",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "IdAutor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Categorias_CategoriaId",
                table: "Libros",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_AutorId",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Categorias_CategoriaId",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_AutorId",
                table: "Libros");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Libros",
                newName: "IdCategoria");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Libros",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IdAutor",
                table: "Libros",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_IdAutor",
                table: "Libros",
                column: "IdAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Categorias_CategoriaId",
                table: "Libros",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_IdAutor",
                table: "Libros",
                column: "IdAutor",
                principalTable: "Autores",
                principalColumn: "IdAutor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

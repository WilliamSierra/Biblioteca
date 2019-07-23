using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaV4.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Libros",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_CategoriaId",
                table: "Libros",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Categorias_CategoriaId",
                table: "Libros",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Categorias_CategoriaId",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_CategoriaId",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Libros");
        }
    }
}

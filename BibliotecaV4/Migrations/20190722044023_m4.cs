using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaV4.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categorias",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Descripcion",
                table: "Categorias",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

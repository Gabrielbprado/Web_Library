using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Library.Migrations
{
    /// <inheritdoc />
    public partial class AddingLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Livro",
                table: "Emprestimos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Livro",
                table: "Emprestimos");
        }
    }
}

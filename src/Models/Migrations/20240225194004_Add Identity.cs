using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Library.Migrations;

/// <inheritdoc />
public partial class AddIdentity : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "FuncionarioId",
            table: "Emprestimos",
            type: "TEXT",
            nullable: false,
            defaultValue: "");

        migrationBuilder.CreateIndex(
            name: "IX_Emprestimos_FuncionarioId",
            table: "Emprestimos",
            column: "FuncionarioId");

        migrationBuilder.AddForeignKey(
            name: "FK_Emprestimos_AspNetUsers_FuncionarioId",
            table: "Emprestimos",
            column: "FuncionarioId",
            principalTable: "AspNetUsers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Emprestimos_AspNetUsers_FuncionarioId",
            table: "Emprestimos");

        migrationBuilder.DropIndex(
            name: "IX_Emprestimos_FuncionarioId",
            table: "Emprestimos");

        migrationBuilder.DropColumn(
            name: "FuncionarioId",
            table: "Emprestimos");
    }
}

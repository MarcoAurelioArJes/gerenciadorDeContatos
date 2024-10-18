using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeContatos.API.Migrations
{
    /// <inheritdoc />
    public partial class MelhorandoRelacionamentoDasTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ContatoID",
                table: "Telefone",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioID",
                table: "Contato",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contato_UsuarioID",
                table: "Contato",
                column: "UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Usuario_UsuarioID",
                table: "Contato",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Contato_ContatoID",
                table: "Telefone",
                column: "ContatoID",
                principalTable: "Contato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Usuario_UsuarioID",
                table: "Contato");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Contato_ContatoID",
                table: "Telefone");

            migrationBuilder.DropIndex(
                name: "IX_Contato_UsuarioID",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "UsuarioID",
                table: "Contato");

            migrationBuilder.RenameColumn(
                name: "ContatoID",
                table: "Telefone",
                newName: "ContatoId");

            migrationBuilder.RenameIndex(
                name: "IX_Telefone_ContatoID",
                table: "Telefone",
                newName: "IX_Telefone_ContatoId");

            migrationBuilder.AlterColumn<int>(
                name: "ContatoId",
                table: "Telefone",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ContatoID",
                table: "Telefone",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_ContatoID",
                table: "Telefone",
                column: "ContatoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Contato_ContatoID",
                table: "Telefone",
                column: "ContatoID",
                principalTable: "Contato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Contato_ContatoId",
                table: "Telefone",
                column: "ContatoId",
                principalTable: "Contato",
                principalColumn: "Id");
        }
    }
}

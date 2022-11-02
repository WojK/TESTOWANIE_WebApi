using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestowanieWebApi.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_ShoppingHistory_Id",
                table: "Client");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Client",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingHistory_ClientForeignKey",
                table: "ShoppingHistory",
                column: "ClientForeignKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingHistory_Client_ClientForeignKey",
                table: "ShoppingHistory",
                column: "ClientForeignKey",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingHistory_Client_ClientForeignKey",
                table: "ShoppingHistory");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingHistory_ClientForeignKey",
                table: "ShoppingHistory");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Client",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_ShoppingHistory_Id",
                table: "Client",
                column: "Id",
                principalTable: "ShoppingHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

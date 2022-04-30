#nullable disable

namespace PetsFriends.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ReciverPetId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ReciverPetId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ReciverPetId",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "ReciverId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReciverId",
                table: "Messages",
                column: "ReciverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ReciverId",
                table: "Messages",
                column: "ReciverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ReciverId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ReciverId",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "ReciverId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ReciverPetId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReciverPetId",
                table: "Messages",
                column: "ReciverPetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ReciverPetId",
                table: "Messages",
                column: "ReciverPetId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

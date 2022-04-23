using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetsFriends.Data.Migrations
{
    public partial class AddMessagesGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyGroups_Groups_GroupId",
                table: "MyGroups");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "MyGroups",
                newName: "GroupIdId");

            migrationBuilder.RenameIndex(
                name: "IX_MyGroups_GroupId",
                table: "MyGroups",
                newName: "IX_MyGroups_GroupIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyGroups_Groups_GroupIdId",
                table: "MyGroups",
                column: "GroupIdId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyGroups_Groups_GroupIdId",
                table: "MyGroups");

            migrationBuilder.RenameColumn(
                name: "GroupIdId",
                table: "MyGroups",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_MyGroups_GroupIdId",
                table: "MyGroups",
                newName: "IX_MyGroups_GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyGroups_Groups_GroupId",
                table: "MyGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

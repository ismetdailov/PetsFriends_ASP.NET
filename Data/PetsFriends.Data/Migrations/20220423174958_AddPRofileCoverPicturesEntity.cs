using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetsFriends.Data.Migrations
{
    public partial class AddPRofileCoverPicturesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoverPictureLeft_AspNetUsers_UserId",
                table: "CoverPictureLeft");

            migrationBuilder.DropForeignKey(
                name: "FK_CoverPictureRight_AspNetUsers_UserId",
                table: "CoverPictureRight");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfilePicture_AspNetUsers_UserId",
                table: "ProfilePicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfilePicture",
                table: "ProfilePicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoverPictureRight",
                table: "CoverPictureRight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoverPictureLeft",
                table: "CoverPictureLeft");

            migrationBuilder.RenameTable(
                name: "ProfilePicture",
                newName: "ProfilePictures");

            migrationBuilder.RenameTable(
                name: "CoverPictureRight",
                newName: "CoverPictureRights");

            migrationBuilder.RenameTable(
                name: "CoverPictureLeft",
                newName: "CoverPictureLefts");

            migrationBuilder.RenameIndex(
                name: "IX_ProfilePicture_UserId",
                table: "ProfilePictures",
                newName: "IX_ProfilePictures_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfilePicture_IsDeleted",
                table: "ProfilePictures",
                newName: "IX_ProfilePictures_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_CoverPictureRight_UserId",
                table: "CoverPictureRights",
                newName: "IX_CoverPictureRights_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CoverPictureRight_IsDeleted",
                table: "CoverPictureRights",
                newName: "IX_CoverPictureRights_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_CoverPictureLeft_UserId",
                table: "CoverPictureLefts",
                newName: "IX_CoverPictureLefts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CoverPictureLeft_IsDeleted",
                table: "CoverPictureLefts",
                newName: "IX_CoverPictureLefts_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfilePictures",
                table: "ProfilePictures",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoverPictureRights",
                table: "CoverPictureRights",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoverPictureLefts",
                table: "CoverPictureLefts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoverPictureLefts_AspNetUsers_UserId",
                table: "CoverPictureLefts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoverPictureRights_AspNetUsers_UserId",
                table: "CoverPictureRights",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilePictures_AspNetUsers_UserId",
                table: "ProfilePictures",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoverPictureLefts_AspNetUsers_UserId",
                table: "CoverPictureLefts");

            migrationBuilder.DropForeignKey(
                name: "FK_CoverPictureRights_AspNetUsers_UserId",
                table: "CoverPictureRights");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfilePictures_AspNetUsers_UserId",
                table: "ProfilePictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfilePictures",
                table: "ProfilePictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoverPictureRights",
                table: "CoverPictureRights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoverPictureLefts",
                table: "CoverPictureLefts");

            migrationBuilder.RenameTable(
                name: "ProfilePictures",
                newName: "ProfilePicture");

            migrationBuilder.RenameTable(
                name: "CoverPictureRights",
                newName: "CoverPictureRight");

            migrationBuilder.RenameTable(
                name: "CoverPictureLefts",
                newName: "CoverPictureLeft");

            migrationBuilder.RenameIndex(
                name: "IX_ProfilePictures_UserId",
                table: "ProfilePicture",
                newName: "IX_ProfilePicture_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfilePictures_IsDeleted",
                table: "ProfilePicture",
                newName: "IX_ProfilePicture_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_CoverPictureRights_UserId",
                table: "CoverPictureRight",
                newName: "IX_CoverPictureRight_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CoverPictureRights_IsDeleted",
                table: "CoverPictureRight",
                newName: "IX_CoverPictureRight_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_CoverPictureLefts_UserId",
                table: "CoverPictureLeft",
                newName: "IX_CoverPictureLeft_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CoverPictureLefts_IsDeleted",
                table: "CoverPictureLeft",
                newName: "IX_CoverPictureLeft_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfilePicture",
                table: "ProfilePicture",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoverPictureRight",
                table: "CoverPictureRight",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoverPictureLeft",
                table: "CoverPictureLeft",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoverPictureLeft_AspNetUsers_UserId",
                table: "CoverPictureLeft",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoverPictureRight_AspNetUsers_UserId",
                table: "CoverPictureRight",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilePicture_AspNetUsers_UserId",
                table: "ProfilePicture",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

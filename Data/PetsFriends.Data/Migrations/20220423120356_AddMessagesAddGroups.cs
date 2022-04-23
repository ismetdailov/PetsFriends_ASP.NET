using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetsFriends.Data.Migrations
{
    public partial class AddMessagesAddGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MyGroups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyGroups", x => new { x.PetId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_MyGroups_AspNetUsers_PetId",
                        column: x => x.PetId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MyGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId1 = table.Column<int>(type: "int", nullable: true),
                    PetId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReciverId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReciverPetId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SendedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserMessagesMessageId = table.Column<int>(type: "int", nullable: true),
                    UserMessagesPetId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_PetId",
                        column: x => x.PetId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ReciverPetId",
                        column: x => x.ReciverPetId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Groups_GroupId1",
                        column: x => x.GroupId1,
                        principalTable: "Groups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserMessages",
                columns: table => new
                {
                    PetId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMessages", x => new { x.PetId, x.MessageId });
                    table.ForeignKey(
                        name: "FK_UserMessages_AspNetUsers_PetId",
                        column: x => x.PetId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMessages_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ApplicationUserId",
                table: "Groups",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_IsDeleted",
                table: "Groups",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_GroupId1",
                table: "Messages",
                column: "GroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_IsDeleted",
                table: "Messages",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_PetId",
                table: "Messages",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReciverPetId",
                table: "Messages",
                column: "ReciverPetId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserMessagesPetId_UserMessagesMessageId",
                table: "Messages",
                columns: new[] { "UserMessagesPetId", "UserMessagesMessageId" });

            migrationBuilder.CreateIndex(
                name: "IX_MyGroups_GroupId",
                table: "MyGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_IsDeleted",
                table: "UserMessages",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_MessageId",
                table: "UserMessages",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_PetId",
                table: "UserMessages",
                column: "PetId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_UserMessages_UserMessagesPetId_UserMessagesMessageId",
                table: "Messages",
                columns: new[] { "UserMessagesPetId", "UserMessagesMessageId" },
                principalTable: "UserMessages",
                principalColumns: new[] { "PetId", "MessageId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Groups_GroupId1",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_UserMessages_UserMessagesPetId_UserMessagesMessageId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "MyGroups");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "UserMessages");

            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieReview.Database.Migrations
{
    public partial class thirdyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Titles_IdTitle",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_IdUser",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorsTitles",
                table: "ActorsTitles");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Reviews",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdTitle",
                table: "Reviews",
                newName: "TitleId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_IdUser",
                table: "Reviews",
                newName: "IX_Reviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_IdTitle",
                table: "Reviews",
                newName: "IX_Reviews_TitleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorsTitles",
                table: "ActorsTitles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ActorsTitles_ActorId",
                table: "ActorsTitles",
                column: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Titles_TitleId",
                table: "Reviews",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Titles_TitleId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorsTitles",
                table: "ActorsTitles");

            migrationBuilder.DropIndex(
                name: "IX_ActorsTitles_ActorId",
                table: "ActorsTitles");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reviews",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "TitleId",
                table: "Reviews",
                newName: "IdTitle");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                newName: "IX_Reviews_IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_TitleId",
                table: "Reviews",
                newName: "IX_Reviews_IdTitle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorsTitles",
                table: "ActorsTitles",
                columns: new[] { "ActorId", "TitleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Titles_IdTitle",
                table: "Reviews",
                column: "IdTitle",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_IdUser",
                table: "Reviews",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

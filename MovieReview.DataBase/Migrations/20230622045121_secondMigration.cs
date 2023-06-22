using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieReview.Database.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorsTitles_Actors_IdActor",
                table: "ActorsTitles");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorsTitles_Titles_IdTitle",
                table: "ActorsTitles");

            migrationBuilder.DropForeignKey(
                name: "FK_Titles_Directors_IdDirector",
                table: "Titles");

            migrationBuilder.RenameColumn(
                name: "IdDirector",
                table: "Titles",
                newName: "DirectorId");

            migrationBuilder.RenameIndex(
                name: "IX_Titles_IdDirector",
                table: "Titles",
                newName: "IX_Titles_DirectorId");

            migrationBuilder.RenameColumn(
                name: "IdTitle",
                table: "ActorsTitles",
                newName: "TitleId");

            migrationBuilder.RenameColumn(
                name: "IdActor",
                table: "ActorsTitles",
                newName: "ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorsTitles_IdTitle",
                table: "ActorsTitles",
                newName: "IX_ActorsTitles_TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsTitles_Actors_ActorId",
                table: "ActorsTitles",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsTitles_Titles_TitleId",
                table: "ActorsTitles",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_Directors_DirectorId",
                table: "Titles",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorsTitles_Actors_ActorId",
                table: "ActorsTitles");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorsTitles_Titles_TitleId",
                table: "ActorsTitles");

            migrationBuilder.DropForeignKey(
                name: "FK_Titles_Directors_DirectorId",
                table: "Titles");

            migrationBuilder.RenameColumn(
                name: "DirectorId",
                table: "Titles",
                newName: "IdDirector");

            migrationBuilder.RenameIndex(
                name: "IX_Titles_DirectorId",
                table: "Titles",
                newName: "IX_Titles_IdDirector");

            migrationBuilder.RenameColumn(
                name: "TitleId",
                table: "ActorsTitles",
                newName: "IdTitle");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "ActorsTitles",
                newName: "IdActor");

            migrationBuilder.RenameIndex(
                name: "IX_ActorsTitles_TitleId",
                table: "ActorsTitles",
                newName: "IX_ActorsTitles_IdTitle");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsTitles_Actors_IdActor",
                table: "ActorsTitles",
                column: "IdActor",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsTitles_Titles_IdTitle",
                table: "ActorsTitles",
                column: "IdTitle",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_Directors_IdDirector",
                table: "Titles",
                column: "IdDirector",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

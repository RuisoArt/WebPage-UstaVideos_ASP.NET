using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ustaVideosA.Migrations
{
    /// <inheritdoc />
    public partial class MyAppInitThree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Movies_Actor_ActorId",
                table: "Actors_Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Movies_Movie_MovieId",
                table: "Actors_Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors_Movies",
                table: "Actors_Movies");

            migrationBuilder.RenameTable(
                name: "Actors_Movies",
                newName: "Actor_Movies");

            migrationBuilder.RenameIndex(
                name: "IX_Actors_Movies_MovieId",
                table: "Actor_Movies",
                newName: "IX_Actor_Movies_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Actors_Movies_ActorId",
                table: "Actor_Movies",
                newName: "IX_Actor_Movies_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actor_Movies",
                table: "Actor_Movies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Actor_Movies_Actor_ActorId",
                table: "Actor_Movies",
                column: "ActorId",
                principalTable: "Actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Actor_Movies_Movie_MovieId",
                table: "Actor_Movies",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actor_Movies_Actor_ActorId",
                table: "Actor_Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Actor_Movies_Movie_MovieId",
                table: "Actor_Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actor_Movies",
                table: "Actor_Movies");

            migrationBuilder.RenameTable(
                name: "Actor_Movies",
                newName: "Actors_Movies");

            migrationBuilder.RenameIndex(
                name: "IX_Actor_Movies_MovieId",
                table: "Actors_Movies",
                newName: "IX_Actors_Movies_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Actor_Movies_ActorId",
                table: "Actors_Movies",
                newName: "IX_Actors_Movies_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors_Movies",
                table: "Actors_Movies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Movies_Actor_ActorId",
                table: "Actors_Movies",
                column: "ActorId",
                principalTable: "Actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Movies_Movie_MovieId",
                table: "Actors_Movies",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace the_squad_server.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class updateApplicationSchemaStreamingServiceUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Creators_CreatorId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "Creators");

            migrationBuilder.DropColumn(
                name: "GithubUrl",
                table: "Creators");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Creators");

            migrationBuilder.DropColumn(
                name: "KickUrl",
                table: "Creators");

            migrationBuilder.DropColumn(
                name: "TikTokUrl",
                table: "Creators");

            migrationBuilder.DropColumn(
                name: "TwitchUrl",
                table: "Creators");

            migrationBuilder.DropColumn(
                name: "YoutubeUrl",
                table: "Creators");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "StreamingServices",
                newName: "Generic");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StreamingServices",
                newName: "StreamingServiceId");

            migrationBuilder.AddColumn<string>(
                name: "ServiceUrl",
                table: "StreamingServices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "StreamingServices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Games",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Creators_CreatorId",
                table: "Games",
                column: "CreatorId",
                principalTable: "Creators",
                principalColumn: "CreatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Creators_CreatorId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ServiceUrl",
                table: "StreamingServices");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "StreamingServices");

            migrationBuilder.RenameColumn(
                name: "Generic",
                table: "StreamingServices",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "StreamingServiceId",
                table: "StreamingServices",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "Creators",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GithubUrl",
                table: "Creators",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Creators",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KickUrl",
                table: "Creators",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TikTokUrl",
                table: "Creators",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitchUrl",
                table: "Creators",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YoutubeUrl",
                table: "Creators",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Creators_CreatorId",
                table: "Games",
                column: "CreatorId",
                principalTable: "Creators",
                principalColumn: "CreatorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

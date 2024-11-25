using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WOD.WebUI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_News",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FootballClubs",
                table: "FootballClubs");

            migrationBuilder.RenameTable(
                name: "FootballClubs",
                newName: "footballclub_info");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "News",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "News",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "News",
                newName: "news_text");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "News",
                newName: "news_image");

            migrationBuilder.RenameColumn(
                name: "Wins",
                table: "footballclub_info",
                newName: "wins");

            migrationBuilder.RenameColumn(
                name: "Ties",
                table: "footballclub_info",
                newName: "ties");

            migrationBuilder.RenameColumn(
                name: "Points",
                table: "footballclub_info",
                newName: "points");

            migrationBuilder.RenameColumn(
                name: "Rank",
                table: "footballclub_info",
                newName: "rank");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "footballclub_info",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Losses",
                table: "footballclub_info",
                newName: "losses");

            migrationBuilder.RenameColumn(
                name: "Logo",
                table: "footballclub_info",
                newName: "logo");

            migrationBuilder.RenameColumn(
                name: "GoalsFor",
                table: "footballclub_info",
                newName: "goalsfor");

            migrationBuilder.RenameColumn(
                name: "GoalsAgainst",
                table: "footballclub_info",
                newName: "goalsagainst");

            migrationBuilder.RenameColumn(
                name: "GoalsDifference",
                table: "footballclub_info",
                newName: "goalsdifference");

            migrationBuilder.RenameColumn(
                name: "Games",
                table: "footballclub_info",
                newName: "games");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "footballclub_info",
                newName: "id");

            migrationBuilder.AlterTable(
                name: "News",
                comment: "Новости\nСодержит: Заголовок, картинку, текст новости и ID.");

            migrationBuilder.AlterTable(
                name: "footballclub_info",
                comment: "Статистика футбольных клубов АПЛ 2024.");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "News",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<byte>(
                name: "wins",
                table: "footballclub_info",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<byte>(
                name: "ties",
                table: "footballclub_info",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<byte>(
                name: "rank",
                table: "footballclub_info",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<byte>(
                name: "losses",
                table: "footballclub_info",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<byte>(
                name: "points",
                table: "footballclub_info",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<byte>(
                name: "goalsfor",
                table: "footballclub_info",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<byte>(
                name: "goalsagainst",
                table: "footballclub_info",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<byte>(
                name: "goalsdifference",
                table: "footballclub_info",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<byte>(
                name: "games",
                table: "footballclub_info",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "footballclub_info",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "footballclub_info",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "news_pkey",
                table: "News",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "EPL_Table_pkey",
                table: "footballclub_info",
                column: "id");

            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    login = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("admins_pkey", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropPrimaryKey(
                name: "news_pkey",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "EPL_Table_pkey",
                table: "footballclub_info");

            migrationBuilder.DropColumn(
                name: "GoalsDifference",
                table: "footballclub_info");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "footballclub_info");

            migrationBuilder.RenameTable(
                name: "footballclub_info",
                newName: "FootballClubs");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "News",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "News",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "news_text",
                table: "News",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "news_image",
                table: "News",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "wins",
                table: "FootballClubs",
                newName: "Wins");

            migrationBuilder.RenameColumn(
                name: "ties",
                table: "FootballClubs",
                newName: "Ties");

            migrationBuilder.RenameColumn(
                name: "rank",
                table: "FootballClubs",
                newName: "Rank");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "FootballClubs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "losses",
                table: "FootballClubs",
                newName: "Losses");

            migrationBuilder.RenameColumn(
                name: "logo",
                table: "FootballClubs",
                newName: "Logo");

            migrationBuilder.RenameColumn(
                name: "goalsfor",
                table: "FootballClubs",
                newName: "GoalsFor");

            migrationBuilder.RenameColumn(
                name: "goalsagainst",
                table: "FootballClubs",
                newName: "GoalsAgainst");

            migrationBuilder.RenameColumn(
                name: "games",
                table: "FootballClubs",
                newName: "Games");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "FootballClubs",
                newName: "Id");

            migrationBuilder.AlterTable(
                name: "News",
                oldComment: "Новости\nСодержит: Заголовок, картинку, текст новости и ID.");

            migrationBuilder.AlterTable(
                name: "FootballClubs",
                oldComment: "Статистика футбольных клубов АПЛ 2024.");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "News",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Wins",
                table: "FootballClubs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "Ties",
                table: "FootballClubs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "Rank",
                table: "FootballClubs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "Losses",
                table: "FootballClubs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "GoalsFor",
                table: "FootballClubs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "GoalsAgainst",
                table: "FootballClubs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "Games",
                table: "FootballClubs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FootballClubs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_News",
                table: "News",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FootballClubs",
                table: "FootballClubs",
                column: "Id");
        }
    }
}

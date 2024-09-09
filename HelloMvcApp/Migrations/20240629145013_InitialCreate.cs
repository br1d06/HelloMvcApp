using System;
using Microsoft.EntityFrameworkCore.Migrations;
using static System.Data.Entity.Migrations.Model.UpdateDatabaseOperation;

namespace WOD.WebUI.Migrations
{
	public partial class InitialCreate : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "News",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					Text = table.Column<string>(type: "string", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Movie", x => x.Id);
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "News");
		}
	}
}

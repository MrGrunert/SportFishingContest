using Microsoft.EntityFrameworkCore.Migrations;

namespace SportFishingContest.Data.Migrations
{
    public partial class updateContest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Species",
                table: "Contests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Species",
                table: "Contests");
        }
    }
}

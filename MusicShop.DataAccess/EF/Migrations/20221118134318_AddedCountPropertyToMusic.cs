using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicShop.DataAccess.EF.Migrations
{
    public partial class AddedCountPropertyToMusic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Music",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Music");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace SehirRehberi.API.Migrations
{
    public partial class _013 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "newcurrent",
                table: "KisiTelefonlar",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "newcurrent",
                table: "KisiAdresler",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "newcurrent",
                table: "KisiTelefonlar");

            migrationBuilder.DropColumn(
                name: "newcurrent",
                table: "KisiAdresler");
        }
    }
}

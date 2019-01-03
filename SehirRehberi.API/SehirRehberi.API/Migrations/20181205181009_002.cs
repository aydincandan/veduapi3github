using Microsoft.EntityFrameworkCore.Migrations;

namespace SehirRehberi.API.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DersDetaylarIdE",
                table: "Takvimler");

            migrationBuilder.DropColumn(
                name: "DerslerIdE",
                table: "Takvimler");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DersDetaylarIdE",
                table: "Takvimler",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DerslerIdE",
                table: "Takvimler",
                nullable: false,
                defaultValue: 0);
        }
    }
}

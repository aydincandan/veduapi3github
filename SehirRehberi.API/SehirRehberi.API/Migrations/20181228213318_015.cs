using Microsoft.EntityFrameworkCore.Migrations;

namespace SehirRehberi.API.Migrations
{
    public partial class _015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "KisiTipi",
                table: "Kisiler",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAnyLogin",
                table: "Kisiler",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAnyLogin",
                table: "Kisiler");

            migrationBuilder.AlterColumn<string>(
                name: "KisiTipi",
                table: "Kisiler",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3);
        }
    }
}

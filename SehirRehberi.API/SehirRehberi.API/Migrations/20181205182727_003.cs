using Microsoft.EntityFrameworkCore.Migrations;

namespace SehirRehberi.API.Migrations
{
    public partial class _003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Kisiler_Dersler_Kisiler_KisilerIdE",
                table: "Kisiler_Dersler",
                column: "KisilerIdE",
                principalTable: "Kisiler",
                principalColumn: "IdE",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kisiler_Icerikler_Kisiler_KisilerIdE",
                table: "Kisiler_Icerikler",
                column: "KisilerIdE",
                principalTable: "Kisiler",
                principalColumn: "IdE",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kisiler_Takvimler_Kisiler_KisilerIdE",
                table: "Kisiler_Takvimler",
                column: "KisilerIdE",
                principalTable: "Kisiler",
                principalColumn: "IdE",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kisiler_Dersler_Kisiler_KisilerIdE",
                table: "Kisiler_Dersler");

            migrationBuilder.DropForeignKey(
                name: "FK_Kisiler_Icerikler_Kisiler_KisilerIdE",
                table: "Kisiler_Icerikler");

            migrationBuilder.DropForeignKey(
                name: "FK_Kisiler_Takvimler_Kisiler_KisilerIdE",
                table: "Kisiler_Takvimler");

            migrationBuilder.DropColumn(
                name: "DersDetaylarIdE",
                table: "Takvimler");

            migrationBuilder.DropColumn(
                name: "DerslerIdE",
                table: "Takvimler");
        }
    }
}

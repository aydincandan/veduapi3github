using Microsoft.EntityFrameworkCore.Migrations;

namespace SehirRehberi.API.Migrations
{
    public partial class _005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Kisiler_Takvimler_TakvimlerIdE",
                table: "Kisiler_Takvimler");

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_Takvimler_TakvimlerIdE",
                table: "Kisiler_Takvimler",
                column: "TakvimlerIdE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Kisiler_Takvimler_TakvimlerIdE",
                table: "Kisiler_Takvimler");

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_Takvimler_TakvimlerIdE",
                table: "Kisiler_Takvimler",
                column: "TakvimlerIdE",
                unique: true);
        }
    }
}

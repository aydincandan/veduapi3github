using Microsoft.EntityFrameworkCore.Migrations;

namespace SehirRehberi.API.Migrations
{
    public partial class ilk01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DersDetaylarIdE",
                table: "DersDetaylar",
                newName: "DersDetaylaraydi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DersDetaylaraydi",
                table: "DersDetaylar",
                newName: "DersDetaylarIdE");
        }
    }
}

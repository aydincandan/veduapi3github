using Microsoft.EntityFrameworkCore.Migrations;

namespace SehirRehberi.API.Migrations
{
    public partial class ilk02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DersDetaylaraydi",
                table: "DersDetaylar",
                newName: "IdE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdE",
                table: "DersDetaylar",
                newName: "DersDetaylaraydi");
        }
    }
}

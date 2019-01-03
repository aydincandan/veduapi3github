﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SehirRehberi.API.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}

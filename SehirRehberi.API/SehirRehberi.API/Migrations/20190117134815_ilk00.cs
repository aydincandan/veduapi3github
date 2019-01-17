using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SehirRehberi.API.Migrations
{
    public partial class ilk00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dersler",
                columns: table => new
                {
                    IdE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 64, nullable: true),
                    Sirano = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dersler", x => x.IdE);
                });

            migrationBuilder.CreateTable(
                name: "Icerikler",
                columns: table => new
                {
                    IdE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BelgeAdi = table.Column<string>(maxLength: 32, nullable: true),
                    BelgeLink = table.Column<string>(maxLength: 128, nullable: true),
                    BelgeAciklama = table.Column<string>(maxLength: 256, nullable: true),
                    DerslerIdE = table.Column<int>(nullable: false),
                    Sirano = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icerikler", x => x.IdE);
                });

            migrationBuilder.CreateTable(
                name: "Kisiler",
                columns: table => new
                {
                    IdE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterDate = table.Column<DateTime>(nullable: true),
                    RegisterDateIP = table.Column<string>(maxLength: 15, nullable: true),
                    ConfirmDate = table.Column<DateTime>(nullable: true),
                    ConfirmDateIP = table.Column<string>(maxLength: 15, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsEmailConfirmed = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(maxLength: 64, nullable: false),
                    Username = table.Column<string>(maxLength: 32, nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Adi = table.Column<string>(maxLength: 32, nullable: true),
                    Soyadi = table.Column<string>(maxLength: 32, nullable: true),
                    TCkimlik = table.Column<string>(maxLength: 11, nullable: true),
                    KisiTipi = table.Column<string>(maxLength: 3, nullable: false),
                    IsAnyLogin = table.Column<bool>(nullable: false),
                    LastLoginDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler", x => x.IdE);
                });

            migrationBuilder.CreateTable(
                name: "Takvimler",
                columns: table => new
                {
                    IdE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DerslerIdE = table.Column<int>(nullable: false),
                    DersDetaylarIdE = table.Column<int>(nullable: false),
                    KursZamani = table.Column<DateTime>(nullable: false),
                    KursAciklama = table.Column<string>(maxLength: 256, nullable: true),
                    Sirano = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takvimler", x => x.IdE);
                });

            migrationBuilder.CreateTable(
                name: "TestTuzel1",
                columns: table => new
                {
                    IdE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterDate = table.Column<DateTime>(nullable: true),
                    RegisterDateIP = table.Column<string>(maxLength: 15, nullable: true),
                    ConfirmDate = table.Column<DateTime>(nullable: true),
                    ConfirmDateIP = table.Column<string>(maxLength: 15, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsEmailConfirmed = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(maxLength: 64, nullable: false),
                    Username = table.Column<string>(maxLength: 32, nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Unvan = table.Column<string>(maxLength: 32, nullable: true),
                    SirketAdi = table.Column<string>(maxLength: 32, nullable: true),
                    VergiDairesi = table.Column<string>(maxLength: 10, nullable: true),
                    VergiNo = table.Column<string>(maxLength: 10, nullable: true),
                    testtuzel1value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTuzel1", x => x.IdE);
                });

            migrationBuilder.CreateTable(
                name: "TestTuzel2",
                columns: table => new
                {
                    IdE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterDate = table.Column<DateTime>(nullable: true),
                    RegisterDateIP = table.Column<string>(maxLength: 15, nullable: true),
                    ConfirmDate = table.Column<DateTime>(nullable: true),
                    ConfirmDateIP = table.Column<string>(maxLength: 15, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsEmailConfirmed = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(maxLength: 64, nullable: false),
                    Username = table.Column<string>(maxLength: 32, nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Unvan = table.Column<string>(maxLength: 32, nullable: true),
                    SirketAdi = table.Column<string>(maxLength: 32, nullable: true),
                    VergiDairesi = table.Column<string>(maxLength: 10, nullable: true),
                    VergiNo = table.Column<string>(maxLength: 10, nullable: true),
                    testtuzel2value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTuzel2", x => x.IdE);
                });

            migrationBuilder.CreateTable(
                name: "DersDetaylar",
                columns: table => new
                {
                    DersDetaylarIdE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitleAciklama = table.Column<string>(maxLength: 255, nullable: true),
                    Sirano = table.Column<int>(nullable: true),
                    DerslerIdE = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersDetaylar", x => x.DersDetaylarIdE);
                    table.ForeignKey(
                        name: "FK_DersDetaylar_Dersler_DerslerIdE",
                        column: x => x.DerslerIdE,
                        principalTable: "Dersler",
                        principalColumn: "IdE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KisiAdminler",
                columns: table => new
                {
                    AdminIdE = table.Column<int>(nullable: false),
                    YetkiSeviye = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisiAdminler", x => x.AdminIdE);
                    table.ForeignKey(
                        name: "FK_KisiAdminler_Kisiler_AdminIdE",
                        column: x => x.AdminIdE,
                        principalTable: "Kisiler",
                        principalColumn: "IdE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KisiAdresler",
                columns: table => new
                {
                    IdE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcikAdres = table.Column<string>(maxLength: 128, nullable: true),
                    Sehir = table.Column<string>(maxLength: 20, nullable: true),
                    Ulke = table.Column<string>(maxLength: 20, nullable: true),
                    newcurrent = table.Column<bool>(nullable: false),
                    KisilerIdE = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisiAdresler", x => x.IdE);
                    table.ForeignKey(
                        name: "FK_KisiAdresler_Kisiler_KisilerIdE",
                        column: x => x.KisilerIdE,
                        principalTable: "Kisiler",
                        principalColumn: "IdE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kisiler_Dersler",
                columns: table => new
                {
                    IdE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KisilerIdE = table.Column<int>(nullable: false),
                    DerslerIdE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler_Dersler", x => x.IdE);
                    table.ForeignKey(
                        name: "FK_Kisiler_Dersler_Dersler_DerslerIdE",
                        column: x => x.DerslerIdE,
                        principalTable: "Dersler",
                        principalColumn: "IdE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kisiler_Dersler_Kisiler_KisilerIdE",
                        column: x => x.KisilerIdE,
                        principalTable: "Kisiler",
                        principalColumn: "IdE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kisiler_Icerikler",
                columns: table => new
                {
                    IdE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KisilerIdE = table.Column<int>(nullable: false),
                    IceriklerIdE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler_Icerikler", x => x.IdE);
                    table.ForeignKey(
                        name: "FK_Kisiler_Icerikler_Icerikler_IceriklerIdE",
                        column: x => x.IceriklerIdE,
                        principalTable: "Icerikler",
                        principalColumn: "IdE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kisiler_Icerikler_Kisiler_KisilerIdE",
                        column: x => x.KisilerIdE,
                        principalTable: "Kisiler",
                        principalColumn: "IdE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KisiOgrenciler",
                columns: table => new
                {
                    OgrenciIdE = table.Column<int>(nullable: false),
                    IlgiAlanlari = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisiOgrenciler", x => x.OgrenciIdE);
                    table.ForeignKey(
                        name: "FK_KisiOgrenciler_Kisiler_OgrenciIdE",
                        column: x => x.OgrenciIdE,
                        principalTable: "Kisiler",
                        principalColumn: "IdE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KisiOgretmenler",
                columns: table => new
                {
                    OgretmenIdE = table.Column<int>(nullable: false),
                    UzmanlikAlanlari = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisiOgretmenler", x => x.OgretmenIdE);
                    table.ForeignKey(
                        name: "FK_KisiOgretmenler_Kisiler_OgretmenIdE",
                        column: x => x.OgretmenIdE,
                        principalTable: "Kisiler",
                        principalColumn: "IdE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KisiTelefonlar",
                columns: table => new
                {
                    IdE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Telefonu = table.Column<string>(maxLength: 10, nullable: true),
                    UlkeKodu = table.Column<string>(maxLength: 2, nullable: true),
                    newcurrent = table.Column<bool>(nullable: false),
                    confirmed = table.Column<bool>(nullable: false),
                    KisilerIdE = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisiTelefonlar", x => x.IdE);
                    table.ForeignKey(
                        name: "FK_KisiTelefonlar_Kisiler_KisilerIdE",
                        column: x => x.KisilerIdE,
                        principalTable: "Kisiler",
                        principalColumn: "IdE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoginTracker",
                columns: table => new
                {
                    IdE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KisiIdE = table.Column<int>(nullable: false),
                    LoginDate = table.Column<DateTime>(nullable: false),
                    LoginDateIP = table.Column<string>(maxLength: 15, nullable: true),
                    KisilerIdE = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginTracker", x => x.IdE);
                    table.ForeignKey(
                        name: "FK_LoginTracker_Kisiler_KisilerIdE",
                        column: x => x.KisilerIdE,
                        principalTable: "Kisiler",
                        principalColumn: "IdE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kisiler_Takvimler",
                columns: table => new
                {
                    IdE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KisilerIdE = table.Column<int>(nullable: false),
                    TakvimlerIdE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler_Takvimler", x => x.IdE);
                    table.ForeignKey(
                        name: "FK_Kisiler_Takvimler_Kisiler_KisilerIdE",
                        column: x => x.KisilerIdE,
                        principalTable: "Kisiler",
                        principalColumn: "IdE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kisiler_Takvimler_Takvimler_TakvimlerIdE",
                        column: x => x.TakvimlerIdE,
                        principalTable: "Takvimler",
                        principalColumn: "IdE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DersDetaylar_DerslerIdE",
                table: "DersDetaylar",
                column: "DerslerIdE");

            migrationBuilder.CreateIndex(
                name: "IX_Dersler_Title",
                table: "Dersler",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Icerikler_BelgeAdi",
                table: "Icerikler",
                column: "BelgeAdi",
                unique: true,
                filter: "[BelgeAdi] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Icerikler_BelgeLink",
                table: "Icerikler",
                column: "BelgeLink",
                unique: true,
                filter: "[BelgeLink] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KisiAdresler_KisilerIdE",
                table: "KisiAdresler",
                column: "KisilerIdE");

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_Email",
                table: "Kisiler",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_Username",
                table: "Kisiler",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_Dersler_DerslerIdE",
                table: "Kisiler_Dersler",
                column: "DerslerIdE");

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_Dersler_KisilerIdE_DerslerIdE",
                table: "Kisiler_Dersler",
                columns: new[] { "KisilerIdE", "DerslerIdE" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_Icerikler_IceriklerIdE",
                table: "Kisiler_Icerikler",
                column: "IceriklerIdE");

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_Icerikler_KisilerIdE_IceriklerIdE",
                table: "Kisiler_Icerikler",
                columns: new[] { "KisilerIdE", "IceriklerIdE" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_Takvimler_TakvimlerIdE",
                table: "Kisiler_Takvimler",
                column: "TakvimlerIdE");

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_Takvimler_KisilerIdE_TakvimlerIdE",
                table: "Kisiler_Takvimler",
                columns: new[] { "KisilerIdE", "TakvimlerIdE" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KisiTelefonlar_KisilerIdE",
                table: "KisiTelefonlar",
                column: "KisilerIdE");

            migrationBuilder.CreateIndex(
                name: "IX_KisiTelefonlar_UlkeKodu_Telefonu",
                table: "KisiTelefonlar",
                columns: new[] { "UlkeKodu", "Telefonu" },
                unique: true,
                filter: "[UlkeKodu] IS NOT NULL AND [Telefonu] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LoginTracker_KisilerIdE",
                table: "LoginTracker",
                column: "KisilerIdE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DersDetaylar");

            migrationBuilder.DropTable(
                name: "KisiAdminler");

            migrationBuilder.DropTable(
                name: "KisiAdresler");

            migrationBuilder.DropTable(
                name: "Kisiler_Dersler");

            migrationBuilder.DropTable(
                name: "Kisiler_Icerikler");

            migrationBuilder.DropTable(
                name: "Kisiler_Takvimler");

            migrationBuilder.DropTable(
                name: "KisiOgrenciler");

            migrationBuilder.DropTable(
                name: "KisiOgretmenler");

            migrationBuilder.DropTable(
                name: "KisiTelefonlar");

            migrationBuilder.DropTable(
                name: "LoginTracker");

            migrationBuilder.DropTable(
                name: "TestTuzel1");

            migrationBuilder.DropTable(
                name: "TestTuzel2");

            migrationBuilder.DropTable(
                name: "Dersler");

            migrationBuilder.DropTable(
                name: "Icerikler");

            migrationBuilder.DropTable(
                name: "Takvimler");

            migrationBuilder.DropTable(
                name: "Kisiler");
        }
    }
}

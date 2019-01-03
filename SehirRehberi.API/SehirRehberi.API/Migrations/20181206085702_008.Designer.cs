﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SehirRehberi.API.Data;

namespace SehirRehberi.API.Migrations
{
    [DbContext(typeof(MyAppDatabaseContext))]
    [Migration("20181206085702_008")]
    partial class _008
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SehirRehberi.API.Models.DersDetaylar", b =>
                {
                    b.Property<int>("IdE")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DerslerIdE");

                    b.Property<int?>("Sirano");

                    b.Property<string>("TitleAciklama")
                        .HasMaxLength(255);

                    b.HasKey("IdE");

                    b.HasIndex("DerslerIdE");

                    b.ToTable("DersDetaylar");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.Dersler", b =>
                {
                    b.Property<int>("IdE")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Sirano");

                    b.Property<string>("Title")
                        .HasMaxLength(64);

                    b.HasKey("IdE");

                    b.HasIndex("Title")
                        .IsUnique()
                        .HasFilter("[Title] IS NOT NULL");

                    b.ToTable("Dersler");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.Icerikler", b =>
                {
                    b.Property<int>("IdE")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BelgeAciklama")
                        .HasMaxLength(256);

                    b.Property<string>("BelgeAdi")
                        .HasMaxLength(32);

                    b.Property<string>("BelgeLink")
                        .HasMaxLength(128);

                    b.Property<int>("DerslerIdE");

                    b.Property<int?>("Sirano");

                    b.HasKey("IdE");

                    b.HasIndex("BelgeAdi")
                        .IsUnique()
                        .HasFilter("[BelgeAdi] IS NOT NULL");

                    b.HasIndex("BelgeLink")
                        .IsUnique()
                        .HasFilter("[BelgeLink] IS NOT NULL");

                    b.ToTable("Icerikler");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.KisiAdminler", b =>
                {
                    b.Property<int>("AdminIdE");

                    b.Property<int?>("YetkiSeviye");

                    b.HasKey("AdminIdE");

                    b.ToTable("KisiAdminler");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.KisiAdresler", b =>
                {
                    b.Property<int>("IdE")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcikAdres")
                        .HasMaxLength(128);

                    b.Property<int?>("KisilerIdE");

                    b.Property<string>("Sehir")
                        .HasMaxLength(20);

                    b.Property<string>("Ulke")
                        .HasMaxLength(20);

                    b.HasKey("IdE");

                    b.HasIndex("KisilerIdE");

                    b.ToTable("KisiAdresler");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.Kisiler", b =>
                {
                    b.Property<int>("IdE")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .HasMaxLength(32);

                    b.Property<DateTime>("ConfirmDate");

                    b.Property<string>("ConfirmDateIP")
                        .HasMaxLength(15);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsEmailConfirmed");

                    b.Property<string>("KisiTipi")
                        .HasMaxLength(3);

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<DateTime>("RegisterDate");

                    b.Property<string>("RegisterDateIP")
                        .HasMaxLength(15);

                    b.Property<string>("Soyadi")
                        .HasMaxLength(32);

                    b.Property<string>("TCkimlik")
                        .HasMaxLength(11);

                    b.Property<string>("Username")
                        .HasMaxLength(32);

                    b.HasKey("IdE");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Kisiler");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.Kisiler_Dersler", b =>
                {
                    b.Property<int>("IdE")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DerslerIdE");

                    b.Property<int>("KisilerIdE");

                    b.HasKey("IdE");

                    b.HasIndex("DerslerIdE");

                    b.HasIndex("KisilerIdE", "DerslerIdE")
                        .IsUnique();

                    b.ToTable("Kisiler_Dersler");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.Kisiler_Icerikler", b =>
                {
                    b.Property<int>("IdE")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IceriklerIdE");

                    b.Property<int>("KisilerIdE");

                    b.HasKey("IdE");

                    b.HasIndex("IceriklerIdE");

                    b.HasIndex("KisilerIdE", "IceriklerIdE")
                        .IsUnique();

                    b.ToTable("Kisiler_Icerikler");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.Kisiler_Takvimler", b =>
                {
                    b.Property<int>("IdE")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KisilerIdE");

                    b.Property<int>("TakvimlerIdE");

                    b.HasKey("IdE");

                    b.HasIndex("TakvimlerIdE");

                    b.HasIndex("KisilerIdE", "TakvimlerIdE")
                        .IsUnique();

                    b.ToTable("Kisiler_Takvimler");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.KisiOgrenciler", b =>
                {
                    b.Property<int>("OgrenciIdE");

                    b.Property<string>("IlgiAlanlari")
                        .HasMaxLength(80);

                    b.HasKey("OgrenciIdE");

                    b.ToTable("KisiOgrenciler");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.KisiOgretmenler", b =>
                {
                    b.Property<int>("OgretmenIdE");

                    b.Property<string>("UzmanlikAlanlari")
                        .HasMaxLength(80);

                    b.HasKey("OgretmenIdE");

                    b.ToTable("KisiOgretmenler");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.KisiTelefonlar", b =>
                {
                    b.Property<int>("IdE")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("KisilerIdE");

                    b.Property<string>("Telefonu")
                        .HasMaxLength(10);

                    b.Property<string>("UlkeKodu")
                        .HasMaxLength(2);

                    b.HasKey("IdE");

                    b.HasIndex("KisilerIdE");

                    b.HasIndex("UlkeKodu", "Telefonu")
                        .IsUnique()
                        .HasFilter("[UlkeKodu] IS NOT NULL AND [Telefonu] IS NOT NULL");

                    b.ToTable("KisiTelefonlar");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.LoginTracker", b =>
                {
                    b.Property<int>("IdE")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KisiIdE");

                    b.Property<int?>("KisilerIdE");

                    b.Property<DateTime>("LoginDate");

                    b.Property<string>("LoginDateIP")
                        .HasMaxLength(15);

                    b.HasKey("IdE");

                    b.HasIndex("KisilerIdE");

                    b.ToTable("LoginTracker");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.Takvimler", b =>
                {
                    b.Property<int>("IdE")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DersDetaylarIdE");

                    b.Property<int>("DerslerIdE");

                    b.Property<string>("KursAciklama")
                        .HasMaxLength(256);

                    b.Property<DateTime>("KursZamani");

                    b.Property<int?>("Sirano");

                    b.HasKey("IdE");

                    b.ToTable("Takvimler");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.TestTuzel1", b =>
                {
                    b.Property<int>("IdE")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ConfirmDate");

                    b.Property<string>("ConfirmDateIP")
                        .HasMaxLength(15);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsEmailConfirmed");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<DateTime>("RegisterDate");

                    b.Property<string>("RegisterDateIP")
                        .HasMaxLength(15);

                    b.Property<string>("SirketAdi")
                        .HasMaxLength(32);

                    b.Property<string>("Unvan")
                        .HasMaxLength(32);

                    b.Property<string>("Username")
                        .HasMaxLength(32);

                    b.Property<string>("VergiDairesi")
                        .HasMaxLength(10);

                    b.Property<string>("VergiNo")
                        .HasMaxLength(10);

                    b.Property<string>("testtuzel1value");

                    b.HasKey("IdE");

                    b.ToTable("TestTuzel1");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.TestTuzel2", b =>
                {
                    b.Property<int>("IdE")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ConfirmDate");

                    b.Property<string>("ConfirmDateIP")
                        .HasMaxLength(15);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsEmailConfirmed");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<DateTime>("RegisterDate");

                    b.Property<string>("RegisterDateIP")
                        .HasMaxLength(15);

                    b.Property<string>("SirketAdi")
                        .HasMaxLength(32);

                    b.Property<string>("Unvan")
                        .HasMaxLength(32);

                    b.Property<string>("Username")
                        .HasMaxLength(32);

                    b.Property<string>("VergiDairesi")
                        .HasMaxLength(10);

                    b.Property<string>("VergiNo")
                        .HasMaxLength(10);

                    b.Property<string>("testtuzel2value");

                    b.HasKey("IdE");

                    b.ToTable("TestTuzel2");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.DersDetaylar", b =>
                {
                    b.HasOne("SehirRehberi.API.Models.Dersler", "Dersler")
                        .WithMany("DersDetaylar")
                        .HasForeignKey("DerslerIdE");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.KisiAdminler", b =>
                {
                    b.HasOne("SehirRehberi.API.Models.Kisiler", "Kisiler")
                        .WithOne("KisiAdminler")
                        .HasForeignKey("SehirRehberi.API.Models.KisiAdminler", "AdminIdE")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SehirRehberi.API.Models.KisiAdresler", b =>
                {
                    b.HasOne("SehirRehberi.API.Models.Kisiler", "Kisiler")
                        .WithMany("Adresleri")
                        .HasForeignKey("KisilerIdE");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.Kisiler_Dersler", b =>
                {
                    b.HasOne("SehirRehberi.API.Models.Dersler")
                        .WithMany("KisininDersleri")
                        .HasForeignKey("DerslerIdE")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SehirRehberi.API.Models.Kisiler")
                        .WithMany("Dersleri")
                        .HasForeignKey("KisilerIdE")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SehirRehberi.API.Models.Kisiler_Icerikler", b =>
                {
                    b.HasOne("SehirRehberi.API.Models.Icerikler")
                        .WithMany("KisininIcerikleri")
                        .HasForeignKey("IceriklerIdE")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SehirRehberi.API.Models.Kisiler")
                        .WithMany("Icerikleri")
                        .HasForeignKey("KisilerIdE")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SehirRehberi.API.Models.Kisiler_Takvimler", b =>
                {
                    b.HasOne("SehirRehberi.API.Models.Kisiler")
                        .WithMany("Takvimleri")
                        .HasForeignKey("KisilerIdE")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SehirRehberi.API.Models.Takvimler")
                        .WithMany("KisininTakvimleri")
                        .HasForeignKey("TakvimlerIdE")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SehirRehberi.API.Models.KisiOgrenciler", b =>
                {
                    b.HasOne("SehirRehberi.API.Models.Kisiler", "Kisiler")
                        .WithOne("KisiOgrenciler")
                        .HasForeignKey("SehirRehberi.API.Models.KisiOgrenciler", "OgrenciIdE")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SehirRehberi.API.Models.KisiOgretmenler", b =>
                {
                    b.HasOne("SehirRehberi.API.Models.Kisiler", "Kisiler")
                        .WithOne("KisiOgretmenler")
                        .HasForeignKey("SehirRehberi.API.Models.KisiOgretmenler", "OgretmenIdE")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SehirRehberi.API.Models.KisiTelefonlar", b =>
                {
                    b.HasOne("SehirRehberi.API.Models.Kisiler", "Kisiler")
                        .WithMany("Telefonlari")
                        .HasForeignKey("KisilerIdE");
                });

            modelBuilder.Entity("SehirRehberi.API.Models.LoginTracker", b =>
                {
                    b.HasOne("SehirRehberi.API.Models.Kisiler", "Kisiler")
                        .WithMany("LoginTrackers")
                        .HasForeignKey("KisilerIdE");
                });
#pragma warning restore 612, 618
        }
    }
}

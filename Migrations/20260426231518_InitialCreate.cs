using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HowToMakeCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    MusteriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriTelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriTcNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriKayıtTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.MusteriId);
                });

            migrationBuilder.CreateTable(
                name: "Oteller",
                columns: table => new
                {
                    OtelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtelAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtelSehir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtelAdres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtelYıldızSayısı = table.Column<int>(type: "int", nullable: false),
                    OtelTelefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oteller", x => x.OtelId);
                });

            migrationBuilder.CreateTable(
                name: "Odalar",
                columns: table => new
                {
                    OdaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdaNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdaKapasite = table.Column<int>(type: "int", nullable: false),
                    OdaFiyat = table.Column<int>(type: "int", nullable: false),
                    OdaDurum = table.Column<bool>(type: "bit", nullable: false),
                    OdaOtel_Id = table.Column<int>(type: "int", nullable: false),
                    OtelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odalar", x => x.OdaId);
                    table.ForeignKey(
                        name: "FK_Odalar_Oteller_OtelId",
                        column: x => x.OtelId,
                        principalTable: "Oteller",
                        principalColumn: "OtelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervasyonlar",
                columns: table => new
                {
                    RezervasyonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RezervasyonGiris = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RezervasyonCikis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RezervasyonTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RezervasyonDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RezervasyonMusteri_Id = table.Column<int>(type: "int", nullable: false),
                    RezervastonOda_Id = table.Column<int>(type: "int", nullable: false),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    OdaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervasyonlar", x => x.RezervasyonId);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "MusteriId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Odalar_OdaId",
                        column: x => x.OdaId,
                        principalTable: "Odalar",
                        principalColumn: "OdaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Odemeler",
                columns: table => new
                {
                    OdemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdemeTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OdemeYontemi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdemeRezervasyon_Id = table.Column<int>(type: "int", nullable: false),
                    RezervasyonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odemeler", x => x.OdemeId);
                    table.ForeignKey(
                        name: "FK_Odemeler_Rezervasyonlar_RezervasyonId",
                        column: x => x.RezervasyonId,
                        principalTable: "Rezervasyonlar",
                        principalColumn: "RezervasyonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Odalar_OtelId",
                table: "Odalar",
                column: "OtelId");

            migrationBuilder.CreateIndex(
                name: "IX_Odemeler_RezervasyonId",
                table: "Odemeler",
                column: "RezervasyonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_MusteriId",
                table: "Rezervasyonlar",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_OdaId",
                table: "Rezervasyonlar",
                column: "OdaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Odemeler");

            migrationBuilder.DropTable(
                name: "Rezervasyonlar");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropTable(
                name: "Odalar");

            migrationBuilder.DropTable(
                name: "Oteller");
        }
    }
}

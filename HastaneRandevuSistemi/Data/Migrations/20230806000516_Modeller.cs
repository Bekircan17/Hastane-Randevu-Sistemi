using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSau.Data.Migrations
{
    public partial class Modeller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poliklinik",
                columns: table => new
                {
                    PoliklinikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliklinikAdi = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliklinik", x => x.PoliklinikId);
                });

            migrationBuilder.CreateTable(
                name: "Doktor",
                columns: table => new
                {
                    DoktorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoliklinikId = table.Column<int>(type: "int", nullable: false),
                    DoktorTelefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktor", x => x.DoktorId);
                    table.ForeignKey(
                        name: "FK_Doktor_Poliklinik_PoliklinikId",
                        column: x => x.PoliklinikId,
                        principalTable: "Poliklinik",
                        principalColumn: "PoliklinikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Randevu",
                columns: table => new
                {
                    RandevuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorId = table.Column<int>(type: "int", nullable: false),
                    RandevuAyi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RandevuGunu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RandevuSaati = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevu", x => x.RandevuId);
                    table.ForeignKey(
                        name: "FK_Randevu_Doktor_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktor",
                        principalColumn: "DoktorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doktor_PoliklinikId",
                table: "Doktor",
                column: "PoliklinikId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_DoktorId",
                table: "Randevu",
                column: "DoktorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Randevu");

            migrationBuilder.DropTable(
                name: "Doktor");

            migrationBuilder.DropTable(
                name: "Poliklinik");
        }
    }
}

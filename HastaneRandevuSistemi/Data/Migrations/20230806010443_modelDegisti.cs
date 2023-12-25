using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSau.Data.Migrations
{
    public partial class modelDegisti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doktor_Poliklinik_PoliklinikId",
                table: "Doktor");

            migrationBuilder.DropTable(
                name: "Poliklinik");

            migrationBuilder.DropIndex(
                name: "IX_Doktor_PoliklinikId",
                table: "Doktor");

            migrationBuilder.DropColumn(
                name: "PoliklinikId",
                table: "Doktor");

            migrationBuilder.AddColumn<string>(
                name: "uzmanlikAlani",
                table: "Doktor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "uzmanlikAlani",
                table: "Doktor");

            migrationBuilder.AddColumn<int>(
                name: "PoliklinikId",
                table: "Doktor",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Doktor_PoliklinikId",
                table: "Doktor",
                column: "PoliklinikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doktor_Poliklinik_PoliklinikId",
                table: "Doktor",
                column: "PoliklinikId",
                principalTable: "Poliklinik",
                principalColumn: "PoliklinikId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

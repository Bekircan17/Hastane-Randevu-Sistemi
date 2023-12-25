using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSau.Data.Migrations
{
    public partial class modeller2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HastaAdi",
                table: "Randevu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HastaSoyAdi",
                table: "Randevu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IletisimNumarası",
                table: "Randevu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TcNo",
                table: "Randevu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HastaAdi",
                table: "Randevu");

            migrationBuilder.DropColumn(
                name: "HastaSoyAdi",
                table: "Randevu");

            migrationBuilder.DropColumn(
                name: "IletisimNumarası",
                table: "Randevu");

            migrationBuilder.DropColumn(
                name: "TcNo",
                table: "Randevu");
        }
    }
}

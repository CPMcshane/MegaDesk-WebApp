using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaDesk_WebApp.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "DeskQuote");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "DeskQuote",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}

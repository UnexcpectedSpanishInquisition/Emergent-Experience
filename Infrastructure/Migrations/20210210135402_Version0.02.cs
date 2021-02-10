using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Version002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bondxp",
                table: "Servers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Discoveryxp",
                table: "Servers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Goalxp",
                table: "Servers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Setbackxp",
                table: "Servers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bondxp",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "Discoveryxp",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "Goalxp",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "Setbackxp",
                table: "Servers");
        }
    }
}

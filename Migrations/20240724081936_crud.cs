using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prac_demo_enitity_framework.Migrations
{
    public partial class crud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminDept",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AdminImg",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminDept",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "AdminImg",
                table: "Admins");
        }
    }
}

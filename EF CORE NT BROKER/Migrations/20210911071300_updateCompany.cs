using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_CORE_NT_BROKER.Migrations
{
    public partial class updateCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrokerId",
                table: "Company");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrokerId",
                table: "Company",
                type: "int",
                nullable: true);
        }
    }
}

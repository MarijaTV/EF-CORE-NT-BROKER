using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_CORE_NT_BROKER.Migrations
{
    public partial class apartment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Apartments");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_CompanyId",
                table: "Apartments",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Company_CompanyId",
                table: "Apartments",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Company_CompanyId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_CompanyId",
                table: "Apartments");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

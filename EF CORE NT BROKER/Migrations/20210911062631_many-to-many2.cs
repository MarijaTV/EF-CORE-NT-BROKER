using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_CORE_NT_BROKER.Migrations
{
    public partial class manytomany2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrokerCompany_Companies_CompaniesCompanyId",
                table: "BrokerCompany");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Companies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CompaniesCompanyId",
                table: "BrokerCompany",
                newName: "CompaniesId");

            migrationBuilder.RenameIndex(
                name: "IX_BrokerCompany_CompaniesCompanyId",
                table: "BrokerCompany",
                newName: "IX_BrokerCompany_CompaniesId");

            migrationBuilder.AddForeignKey(
                name: "FK_BrokerCompany_Companies_CompaniesId",
                table: "BrokerCompany",
                column: "CompaniesId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrokerCompany_Companies_CompaniesId",
                table: "BrokerCompany");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Companies",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "CompaniesId",
                table: "BrokerCompany",
                newName: "CompaniesCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_BrokerCompany_CompaniesId",
                table: "BrokerCompany",
                newName: "IX_BrokerCompany_CompaniesCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BrokerCompany_Companies_CompaniesCompanyId",
                table: "BrokerCompany",
                column: "CompaniesCompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

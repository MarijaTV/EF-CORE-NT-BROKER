using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_CORE_NT_BROKER.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brokers_Companies_CompanyId",
                table: "Brokers");

            migrationBuilder.DropIndex(
                name: "IX_Brokers_CompanyId",
                table: "Brokers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Brokers");

            migrationBuilder.CreateTable(
                name: "BrokerCompany",
                columns: table => new
                {
                    BrokersId = table.Column<int>(type: "int", nullable: false),
                    CompaniesCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrokerCompany", x => new { x.BrokersId, x.CompaniesCompanyId });
                    table.ForeignKey(
                        name: "FK_BrokerCompany_Brokers_BrokersId",
                        column: x => x.BrokersId,
                        principalTable: "Brokers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrokerCompany_Companies_CompaniesCompanyId",
                        column: x => x.CompaniesCompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrokerCompany_CompaniesCompanyId",
                table: "BrokerCompany",
                column: "CompaniesCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrokerCompany");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Brokers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brokers_CompanyId",
                table: "Brokers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brokers_Companies_CompanyId",
                table: "Brokers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

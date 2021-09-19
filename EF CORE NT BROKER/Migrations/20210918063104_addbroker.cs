using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_CORE_NT_BROKER.Migrations
{
    public partial class addbroker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Apartments_BrokerId",
                table: "Apartments",
                column: "BrokerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Brokers_BrokerId",
                table: "Apartments",
                column: "BrokerId",
                principalTable: "Brokers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Brokers_BrokerId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_BrokerId",
                table: "Apartments");
        }
    }
}

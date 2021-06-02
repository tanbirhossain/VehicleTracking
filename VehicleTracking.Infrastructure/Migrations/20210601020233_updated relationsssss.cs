using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleTracking.Infrastructure.Migrations
{
    public partial class updatedrelationsssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Client_ClientId",
                table: "Vehicle");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Client",
                table: "Vehicle",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Client",
                table: "Vehicle");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Client_ClientId",
                table: "Vehicle",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

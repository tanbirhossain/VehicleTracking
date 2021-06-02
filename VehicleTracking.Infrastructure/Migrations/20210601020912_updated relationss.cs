using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleTracking.Infrastructure.Migrations
{
    public partial class updatedrelationss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Position_VehicleId",
                table: "Position",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Position_Vehicle",
                table: "Position",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Position_Vehicle",
                table: "Position");

            migrationBuilder.DropIndex(
                name: "IX_Position_VehicleId",
                table: "Position");
        }
    }
}

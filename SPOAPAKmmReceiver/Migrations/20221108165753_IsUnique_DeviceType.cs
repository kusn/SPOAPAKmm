using Microsoft.EntityFrameworkCore.Migrations;

namespace SPOAPAKmmReceiver.Migrations
{
    public partial class IsUnique_DeviceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DeviceTypes_Name",
                table: "DeviceTypes",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DeviceTypes_Name",
                table: "DeviceTypes");
        }
    }
}

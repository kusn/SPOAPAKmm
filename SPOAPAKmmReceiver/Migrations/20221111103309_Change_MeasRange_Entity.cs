using Microsoft.EntityFrameworkCore.Migrations;

namespace SPOAPAKmmReceiver.Migrations
{
    public partial class Change_MeasRange_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Range_SartFreq",
                table: "Devices",
                newName: "Range_StartFreq");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Range_StartFreq",
                table: "Devices",
                newName: "Range_SartFreq");
        }
    }
}

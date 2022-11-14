using Microsoft.EntityFrameworkCore.Migrations;

namespace SPOAPAKmmReceiver.Migrations
{
    public partial class ChangeMeasuringAndMeasPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageE",
                table: "Measurings");

            migrationBuilder.DropColumn(
                name: "DX",
                table: "Measurings");

            migrationBuilder.DropColumn(
                name: "E",
                table: "Measurings");

            migrationBuilder.AddColumn<double>(
                name: "Freq",
                table: "MeasPoints",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "P1",
                table: "MeasPoints",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "P2",
                table: "MeasPoints",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Freq",
                table: "MeasPoints");

            migrationBuilder.DropColumn(
                name: "P1",
                table: "MeasPoints");

            migrationBuilder.DropColumn(
                name: "P2",
                table: "MeasPoints");

            migrationBuilder.AddColumn<double>(
                name: "AverageE",
                table: "Measurings",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DX",
                table: "Measurings",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "E",
                table: "Measurings",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}

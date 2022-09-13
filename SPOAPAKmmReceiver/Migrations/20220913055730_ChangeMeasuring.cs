using Microsoft.EntityFrameworkCore.Migrations;

namespace SPOAPAKmmReceiver.Migrations
{
    public partial class ChangeMeasuring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Organizations",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Organizations",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace SPOAPAKmmReceiver.Migrations
{
    public partial class RemakeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageE",
                table: "MeasPoints");

            migrationBuilder.DropColumn(
                name: "DX",
                table: "MeasPoints");

            migrationBuilder.DropColumn(
                name: "E",
                table: "MeasPoints");

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

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    P1 = table.Column<double>(type: "REAL", nullable: false),
                    P2 = table.Column<double>(type: "REAL", nullable: false),
                    MeasureItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Levels_Measurings_MeasureItemId",
                        column: x => x.MeasureItemId,
                        principalTable: "Measurings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Levels_MeasureItemId",
                table: "Levels",
                column: "MeasureItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Levels");

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
                name: "AverageE",
                table: "MeasPoints",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DX",
                table: "MeasPoints",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "E",
                table: "MeasPoints",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

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
    }
}

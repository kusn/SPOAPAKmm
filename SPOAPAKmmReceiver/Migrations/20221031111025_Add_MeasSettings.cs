using Microsoft.EntityFrameworkCore.Migrations;

namespace SPOAPAKmmReceiver.Migrations
{
    public partial class Add_MeasSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeasSettingsId",
                table: "Rooms",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MeasSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartFrequency = table.Column<double>(type: "REAL", nullable: false),
                    EndFrequency = table.Column<double>(type: "REAL", nullable: false),
                    Step = table.Column<double>(type: "REAL", nullable: false),
                    Offset = table.Column<double>(type: "REAL", nullable: false),
                    Power = table.Column<double>(type: "REAL", nullable: false),
                    TimeOfEmission = table.Column<int>(type: "INTEGER", nullable: false),
                    Span = table.Column<double>(type: "REAL", nullable: false),
                    Rbw = table.Column<double>(type: "REAL", nullable: false),
                    Attenuation = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPreferredRow = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOwnRow = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsPreamp = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Frequencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Freq = table.Column<double>(type: "REAL", nullable: false),
                    MeasSettingsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Frequencies_MeasSettings_MeasSettingsId",
                        column: x => x.MeasSettingsId,
                        principalTable: "MeasSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_MeasSettingsId",
                table: "Rooms",
                column: "MeasSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Frequencies_MeasSettingsId",
                table: "Frequencies",
                column: "MeasSettingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_MeasSettings_MeasSettingsId",
                table: "Rooms",
                column: "MeasSettingsId",
                principalTable: "MeasSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_MeasSettings_MeasSettingsId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "Frequencies");

            migrationBuilder.DropTable(
                name: "MeasSettings");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_MeasSettingsId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "MeasSettingsId",
                table: "Rooms");
        }
    }
}

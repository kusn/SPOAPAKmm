using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SPOAPAKmmReceiver.Migrations
{
    public partial class ChangeDeviceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Devices",
                newName: "VerificationOrganization");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Devices",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<double>(
                name: "Range_EndFreq",
                table: "Devices",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Range_Id",
                table: "Devices",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Range_SartFreq",
                table: "Devices",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Devices",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VerificationDate",
                table: "Devices",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "VerificationInformation",
                table: "Devices",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DeviceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_TypeId",
                table: "Devices",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceTypes_TypeId",
                table: "Devices",
                column: "TypeId",
                principalTable: "DeviceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceTypes_TypeId",
                table: "Devices");

            migrationBuilder.DropTable(
                name: "DeviceTypes");

            migrationBuilder.DropIndex(
                name: "IX_Devices_TypeId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Range_EndFreq",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Range_Id",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Range_SartFreq",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "VerificationDate",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "VerificationInformation",
                table: "Devices");

            migrationBuilder.RenameColumn(
                name: "VerificationOrganization",
                table: "Devices",
                newName: "Type");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Devices",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}

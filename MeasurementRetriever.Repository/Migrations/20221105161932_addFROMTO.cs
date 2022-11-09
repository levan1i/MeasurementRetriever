using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeasurementRetriever.Repository.Migrations
{
    public partial class addFROMTO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "AgregatedMeasurments",
                newName: "To");

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "AgregatedMeasurments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "AgregatedMeasurments");

            migrationBuilder.RenameColumn(
                name: "To",
                table: "AgregatedMeasurments",
                newName: "DateTime");
        }
    }
}

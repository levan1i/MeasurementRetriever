using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeasurementRetriever.Repository.Migrations
{
    public partial class adddatasetid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "DatasetInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "AgregatedMeasurments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "DatasetId",
                table: "AgregatedMeasurments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "DatasetInfo");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "AgregatedMeasurments");

            migrationBuilder.DropColumn(
                name: "DatasetId",
                table: "AgregatedMeasurments");
        }
    }
}

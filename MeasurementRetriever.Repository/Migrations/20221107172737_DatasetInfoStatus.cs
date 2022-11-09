using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeasurementRetriever.Repository.Migrations
{
    public partial class DatasetInfoStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isProcessed",
                table: "DatasetInfo");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "DatasetInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OperationMessage",
                table: "DatasetInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StatusCode",
                table: "DatasetInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "PPlus",
                table: "AgregatedMeasurments",
                type: "decimal(2,2)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "DatasetInfo");

            migrationBuilder.DropColumn(
                name: "OperationMessage",
                table: "DatasetInfo");

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "DatasetInfo");

            migrationBuilder.AddColumn<bool>(
                name: "isProcessed",
                table: "DatasetInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "PPlus",
                table: "AgregatedMeasurments",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldPrecision: 2);
        }
    }
}

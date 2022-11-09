using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeasurementRetriever.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DatasetInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    isProcessed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatasetInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "AgregatedMeasurments",
                columns: table => new
                {
                    MeasurmentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<long>(type: "bigint", nullable: false),
                    PPlus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PMinus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgregatedMeasurments", x => x.MeasurmentId);
                    table.ForeignKey(
                        name: "FK_AgregatedMeasurments_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgregatedMeasurments_RegionId",
                table: "AgregatedMeasurments",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_RegionName",
                table: "Regions",
                column: "RegionName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgregatedMeasurments");

            migrationBuilder.DropTable(
                name: "DatasetInfo");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}

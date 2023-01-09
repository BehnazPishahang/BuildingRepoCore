using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorCount = table.Column<int>(type: "int", nullable: true),
                    Plaque = table.Column<int>(type: "int", nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EventDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BUILDINGID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    COSTTYPEID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OBJECTSTATEID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Costs_Buildings_BUILDINGID",
                        column: x => x.BUILDINGID,
                        principalTable: "Buildings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Costs_CostTypes_COSTTYPEID",
                        column: x => x.COSTTYPEID,
                        principalTable: "CostTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Costs_ObjectStates_OBJECTSTATEID",
                        column: x => x.OBJECTSTATEID,
                        principalTable: "ObjectStates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Costs_BUILDINGID",
                table: "Costs",
                column: "BUILDINGID");

            migrationBuilder.CreateIndex(
                name: "IX_Costs_COSTTYPEID",
                table: "Costs",
                column: "COSTTYPEID");

            migrationBuilder.CreateIndex(
                name: "IX_Costs_OBJECTSTATEID",
                table: "Costs",
                column: "OBJECTSTATEID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "CostTypes");

            migrationBuilder.DropTable(
                name: "ObjectStates");
        }
    }
}

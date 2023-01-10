using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("6ee8e8f0-d89a-487b-a1f9-0e13da4026c6"));

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("858791a0-03bc-4ba6-acc4-12f7c256f80a"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("5bc530db-e4ce-4046-ac4a-e0559b48d1a8"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("6bf35be1-1677-4245-bba0-622ee23ce9d7"));

            migrationBuilder.DeleteData(
                table: "CostTypes",
                keyColumn: "Id",
                keyValue: new Guid("170555a9-de79-4c3c-bb84-098408a8d30a"));

            migrationBuilder.DeleteData(
                table: "CostTypes",
                keyColumn: "Id",
                keyValue: new Guid("dc59b74c-f132-4943-aad2-5d16161287de"));

            migrationBuilder.DeleteData(
                table: "ObjectStates",
                keyColumn: "Id",
                keyValue: new Guid("20f179ef-ab00-40a1-a1a3-bc0e2444bc85"));

            migrationBuilder.DeleteData(
                table: "ObjectStates",
                keyColumn: "Id",
                keyValue: new Guid("80449d6d-a150-4f8f-a283-5bed489daf19"));

            migrationBuilder.CreateTable(
                name: "UserAccessTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccessTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserAccessTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccesses_UserAccessTypes_UserAccessTypeId",
                        column: x => x.UserAccessTypeId,
                        principalTable: "UserAccessTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccesses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccesses_UserAccessTypeId",
                table: "UserAccesses",
                column: "UserAccessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccesses_UserId",
                table: "UserAccesses",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccesses");

            migrationBuilder.DropTable(
                name: "UserAccessTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Address", "CityName", "FloorCount", "Plaque", "Title" },
                values: new object[,]
                {
                    { new Guid("5bc530db-e4ce-4046-ac4a-e0559b48d1a8"), "سه راه تقی آباد", "شهرری", 4, 16, "ساختمان مهندس" },
                    { new Guid("6bf35be1-1677-4245-bba0-622ee23ce9d7"), "تهران خیابان بهشتی", "تهران", 4, 30, "ساختمان آنو" }
                });

            migrationBuilder.InsertData(
                table: "CostTypes",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[,]
                {
                    { new Guid("170555a9-de79-4c3c-bb84-098408a8d30a"), "0002", "قبض برق" },
                    { new Guid("dc59b74c-f132-4943-aad2-5d16161287de"), "0001", "نظافت ساختمان" }
                });

            migrationBuilder.InsertData(
                table: "ObjectStates",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[,]
                {
                    { new Guid("20f179ef-ab00-40a1-a1a3-bc0e2444bc85"), "0002", "پرداخت نشده" },
                    { new Guid("80449d6d-a150-4f8f-a283-5bed489daf19"), "0001", "پرداخت شده" }
                });

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "BuildingId", "CashAmount", "CostTypeId", "EventDate", "FromDate", "ObjectStateId", "ToDate" },
                values: new object[] { new Guid("6ee8e8f0-d89a-487b-a1f9-0e13da4026c6"), 1000m, new Guid("5bc530db-e4ce-4046-ac4a-e0559b48d1a8"), 40000m, new Guid("170555a9-de79-4c3c-bb84-098408a8d30a"), "1401/01/01", null, new Guid("20f179ef-ab00-40a1-a1a3-bc0e2444bc85"), null });

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "BuildingId", "CashAmount", "CostTypeId", "EventDate", "FromDate", "ObjectStateId", "ToDate" },
                values: new object[] { new Guid("858791a0-03bc-4ba6-acc4-12f7c256f80a"), 2000m, new Guid("6bf35be1-1677-4245-bba0-622ee23ce9d7"), 30000m, new Guid("dc59b74c-f132-4943-aad2-5d16161287de"), "", "1401/01/01", new Guid("80449d6d-a150-4f8f-a283-5bed489daf19"), "1401/03/01" });
        }
    }
}

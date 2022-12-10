using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_Buildings_BUILDINGID",
                table: "Costs");

            migrationBuilder.DropForeignKey(
                name: "FK_Costs_CostTypes_COSTTYPEID",
                table: "Costs");

            migrationBuilder.DropForeignKey(
                name: "FK_Costs_ObjectStates_OBJECTSTATEID",
                table: "Costs");

            migrationBuilder.RenameColumn(
                name: "OBJECTSTATEID",
                table: "Costs",
                newName: "ObjectStateId");

            migrationBuilder.RenameColumn(
                name: "COSTTYPEID",
                table: "Costs",
                newName: "CostTypeId");

            migrationBuilder.RenameColumn(
                name: "BUILDINGID",
                table: "Costs",
                newName: "BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Costs_OBJECTSTATEID",
                table: "Costs",
                newName: "IX_Costs_ObjectStateId");

            migrationBuilder.RenameIndex(
                name: "IX_Costs_COSTTYPEID",
                table: "Costs",
                newName: "IX_Costs_CostTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Costs_BUILDINGID",
                table: "Costs",
                newName: "IX_Costs_BuildingId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ObjectStateId",
                table: "Costs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CostTypeId",
                table: "Costs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BuildingId",
                table: "Costs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_Buildings_BuildingId",
                table: "Costs",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_CostTypes_CostTypeId",
                table: "Costs",
                column: "CostTypeId",
                principalTable: "CostTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_ObjectStates_ObjectStateId",
                table: "Costs",
                column: "ObjectStateId",
                principalTable: "ObjectStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_Buildings_BuildingId",
                table: "Costs");

            migrationBuilder.DropForeignKey(
                name: "FK_Costs_CostTypes_CostTypeId",
                table: "Costs");

            migrationBuilder.DropForeignKey(
                name: "FK_Costs_ObjectStates_ObjectStateId",
                table: "Costs");

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

            migrationBuilder.RenameColumn(
                name: "ObjectStateId",
                table: "Costs",
                newName: "OBJECTSTATEID");

            migrationBuilder.RenameColumn(
                name: "CostTypeId",
                table: "Costs",
                newName: "COSTTYPEID");

            migrationBuilder.RenameColumn(
                name: "BuildingId",
                table: "Costs",
                newName: "BUILDINGID");

            migrationBuilder.RenameIndex(
                name: "IX_Costs_ObjectStateId",
                table: "Costs",
                newName: "IX_Costs_OBJECTSTATEID");

            migrationBuilder.RenameIndex(
                name: "IX_Costs_CostTypeId",
                table: "Costs",
                newName: "IX_Costs_COSTTYPEID");

            migrationBuilder.RenameIndex(
                name: "IX_Costs_BuildingId",
                table: "Costs",
                newName: "IX_Costs_BUILDINGID");

            migrationBuilder.AlterColumn<Guid>(
                name: "OBJECTSTATEID",
                table: "Costs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "COSTTYPEID",
                table: "Costs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "BUILDINGID",
                table: "Costs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_Buildings_BUILDINGID",
                table: "Costs",
                column: "BUILDINGID",
                principalTable: "Buildings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_CostTypes_COSTTYPEID",
                table: "Costs",
                column: "COSTTYPEID",
                principalTable: "CostTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_ObjectStates_OBJECTSTATEID",
                table: "Costs",
                column: "OBJECTSTATEID",
                principalTable: "ObjectStates",
                principalColumn: "Id");
        }
    }
}

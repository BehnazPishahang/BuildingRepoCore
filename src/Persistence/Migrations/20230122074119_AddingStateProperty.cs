using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddingStateProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("00c1ba3b-757e-4725-b4cf-cbc12b25f422"));

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("db0e1618-a056-406d-b2b6-c35acd3e4bdc"));

            migrationBuilder.DeleteData(
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("e6c8c666-5c23-42ee-9c92-bf72c812a4be"));

            migrationBuilder.DeleteData(
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("e9a352be-ffb5-41a1-b72d-b5a599e94a2d"));

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "ObjectStates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "CostTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "CostTypes",
                keyColumn: "Id",
                keyValue: new Guid("170555a9-de79-4c3c-bb84-098408a8d30a"),
                column: "State",
                value: true);

            migrationBuilder.UpdateData(
                table: "CostTypes",
                keyColumn: "Id",
                keyValue: new Guid("dc59b74c-f132-4943-aad2-5d16161287de"),
                column: "State",
                value: true);

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "BuildingId", "CashAmount", "CostTypeId", "EventDate", "FromDate", "ObjectStateId", "ToDate" },
                values: new object[,]
                {
                    { new Guid("1c0312f8-9f35-464a-a5e6-81ff618f28f3"), 1000m, new Guid("5bc530db-e4ce-4046-ac4a-e0559b48d1a8"), 40000m, new Guid("170555a9-de79-4c3c-bb84-098408a8d30a"), "1401/01/01", null, new Guid("20f179ef-ab00-40a1-a1a3-bc0e2444bc85"), null },
                    { new Guid("a5fd8d95-31d6-4372-bcdd-9f06a05bfd31"), 2000m, new Guid("6bf35be1-1677-4245-bba0-622ee23ce9d7"), 30000m, new Guid("dc59b74c-f132-4943-aad2-5d16161287de"), "", "1401/01/01", new Guid("80449d6d-a150-4f8f-a283-5bed489daf19"), "1401/03/01" }
                });

            migrationBuilder.UpdateData(
                table: "ObjectStates",
                keyColumn: "Id",
                keyValue: new Guid("20f179ef-ab00-40a1-a1a3-bc0e2444bc85"),
                column: "State",
                value: true);

            migrationBuilder.UpdateData(
                table: "ObjectStates",
                keyColumn: "Id",
                keyValue: new Guid("80449d6d-a150-4f8f-a283-5bed489daf19"),
                column: "State",
                value: true);

            migrationBuilder.InsertData(
                table: "UserAccesses",
                columns: new[] { "Id", "EndDate", "SignText", "StartDate", "UserAccessTypeId", "UserId" },
                values: new object[,]
                {
                    { new Guid("567394da-4be9-41e0-a195-04ce0f1fc56d"), "9999/99/99", "مجید عباسی _ مدیر ساختمان", "1401/10/20", new Guid("6524fa96-e320-413b-8695-8467c94465ee"), new Guid("75497455-5e77-42fa-87da-125b7686c3f2") },
                    { new Guid("f875701a-e6ab-48f3-a765-e454371704d3"), "9999/99/99", "بهناز پیشاهنگ _ اعضای ساختمان", "1401/10/20", new Guid("fa1d726c-615e-4e89-9aed-477e7cbd7e2b"), new Guid("d6023cd6-fde2-423d-a8ac-e2cfbd252ba3") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("1c0312f8-9f35-464a-a5e6-81ff618f28f3"));

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("a5fd8d95-31d6-4372-bcdd-9f06a05bfd31"));

            migrationBuilder.DeleteData(
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("567394da-4be9-41e0-a195-04ce0f1fc56d"));

            migrationBuilder.DeleteData(
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("f875701a-e6ab-48f3-a765-e454371704d3"));

            migrationBuilder.DropColumn(
                name: "State",
                table: "ObjectStates");

            migrationBuilder.DropColumn(
                name: "State",
                table: "CostTypes");

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "BuildingId", "CashAmount", "CostTypeId", "EventDate", "FromDate", "ObjectStateId", "ToDate" },
                values: new object[,]
                {
                    { new Guid("00c1ba3b-757e-4725-b4cf-cbc12b25f422"), 1000m, new Guid("5bc530db-e4ce-4046-ac4a-e0559b48d1a8"), 40000m, new Guid("170555a9-de79-4c3c-bb84-098408a8d30a"), "1401/01/01", null, new Guid("20f179ef-ab00-40a1-a1a3-bc0e2444bc85"), null },
                    { new Guid("db0e1618-a056-406d-b2b6-c35acd3e4bdc"), 2000m, new Guid("6bf35be1-1677-4245-bba0-622ee23ce9d7"), 30000m, new Guid("dc59b74c-f132-4943-aad2-5d16161287de"), "", "1401/01/01", new Guid("80449d6d-a150-4f8f-a283-5bed489daf19"), "1401/03/01" }
                });

            migrationBuilder.InsertData(
                table: "UserAccesses",
                columns: new[] { "Id", "EndDate", "SignText", "StartDate", "UserAccessTypeId", "UserId" },
                values: new object[,]
                {
                    { new Guid("e6c8c666-5c23-42ee-9c92-bf72c812a4be"), "9999/99/99", "بهناز پیشاهنگ _ اعضای ساختمان", "1401/10/20", new Guid("fa1d726c-615e-4e89-9aed-477e7cbd7e2b"), new Guid("d6023cd6-fde2-423d-a8ac-e2cfbd252ba3") },
                    { new Guid("e9a352be-ffb5-41a1-b72d-b5a599e94a2d"), "9999/99/99", "مجید عباسی _ مدیر ساختمان", "1401/10/20", new Guid("6524fa96-e320-413b-8695-8467c94465ee"), new Guid("75497455-5e77-42fa-87da-125b7686c3f2") }
                });
        }
    }
}

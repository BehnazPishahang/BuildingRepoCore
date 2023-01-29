using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class OwnType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("48b51ade-2d04-457b-86f9-a6c92a40304a"));

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("e1c1026c-7c37-47b7-b829-cdb9ef31d78a"));

            migrationBuilder.DeleteData(
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("3d8e4963-75e1-431f-8545-b76d6e18ec20"));

            migrationBuilder.DeleteData(
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("69dc2e41-957b-4a50-aecb-22900d16ac6e"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "BuildingHistory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "BuildingId", "CashAmount", "CostTypeId", "EventDate", "FromDate", "ObjectStateId", "ToDate" },
                values: new object[,]
                {
                    { new Guid("5c7fcee9-5ea4-433b-8f69-419f23f8a5ac"), 2000m, new Guid("6bf35be1-1677-4245-bba0-622ee23ce9d7"), 30000m, new Guid("dc59b74c-f132-4943-aad2-5d16161287de"), "", "1401/01/01", new Guid("80449d6d-a150-4f8f-a283-5bed489daf19"), "1401/03/01" },
                    { new Guid("d35b0913-4b32-4ecc-8054-73fadfe97129"), 1000m, new Guid("5bc530db-e4ce-4046-ac4a-e0559b48d1a8"), 40000m, new Guid("170555a9-de79-4c3c-bb84-098408a8d30a"), "1401/01/01", null, new Guid("20f179ef-ab00-40a1-a1a3-bc0e2444bc85"), null }
                });

            migrationBuilder.InsertData(
                table: "UserAccesses",
                columns: new[] { "Id", "EndDate", "SignText", "StartDate", "UserAccessTypeId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2ba47a01-6bfb-4227-9901-44c8c5015464"), "9999/99/99", "بهناز پیشاهنگ _ اعضای ساختمان", "1401/10/20", new Guid("fa1d726c-615e-4e89-9aed-477e7cbd7e2b"), new Guid("d6023cd6-fde2-423d-a8ac-e2cfbd252ba3") },
                    { new Guid("2c1505a8-6f3a-4929-93bc-b6171d5f5c79"), "9999/99/99", "مجید عباسی _ مدیر ساختمان", "1401/10/20", new Guid("6524fa96-e320-413b-8695-8467c94465ee"), new Guid("75497455-5e77-42fa-87da-125b7686c3f2") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("5c7fcee9-5ea4-433b-8f69-419f23f8a5ac"));

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("d35b0913-4b32-4ecc-8054-73fadfe97129"));

            migrationBuilder.DeleteData(
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("2ba47a01-6bfb-4227-9901-44c8c5015464"));

            migrationBuilder.DeleteData(
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("2c1505a8-6f3a-4929-93bc-b6171d5f5c79"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BuildingHistory");

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "BuildingId", "CashAmount", "CostTypeId", "EventDate", "FromDate", "ObjectStateId", "ToDate" },
                values: new object[,]
                {
                    { new Guid("48b51ade-2d04-457b-86f9-a6c92a40304a"), 2000m, new Guid("6bf35be1-1677-4245-bba0-622ee23ce9d7"), 30000m, new Guid("dc59b74c-f132-4943-aad2-5d16161287de"), "", "1401/01/01", new Guid("80449d6d-a150-4f8f-a283-5bed489daf19"), "1401/03/01" },
                    { new Guid("e1c1026c-7c37-47b7-b829-cdb9ef31d78a"), 1000m, new Guid("5bc530db-e4ce-4046-ac4a-e0559b48d1a8"), 40000m, new Guid("170555a9-de79-4c3c-bb84-098408a8d30a"), "1401/01/01", null, new Guid("20f179ef-ab00-40a1-a1a3-bc0e2444bc85"), null }
                });

            migrationBuilder.InsertData(
                table: "UserAccesses",
                columns: new[] { "Id", "EndDate", "SignText", "StartDate", "UserAccessTypeId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3d8e4963-75e1-431f-8545-b76d6e18ec20"), "9999/99/99", "مجید عباسی _ مدیر ساختمان", "1401/10/20", new Guid("6524fa96-e320-413b-8695-8467c94465ee"), new Guid("75497455-5e77-42fa-87da-125b7686c3f2") },
                    { new Guid("69dc2e41-957b-4a50-aecb-22900d16ac6e"), "9999/99/99", "بهناز پیشاهنگ _ اعضای ساختمان", "1401/10/20", new Guid("fa1d726c-615e-4e89-9aed-477e7cbd7e2b"), new Guid("d6023cd6-fde2-423d-a8ac-e2cfbd252ba3") }
                });
        }
    }
}

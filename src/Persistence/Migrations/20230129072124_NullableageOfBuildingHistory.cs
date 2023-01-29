using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class NullableageOfBuildingHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("42faf9fa-23f8-4a30-bbe9-aba4cf9f50b1"));

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("ffc0437c-cdb6-4ecb-9ed1-aedd0c1c8821"));

            migrationBuilder.DeleteData(
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("4a7c105a-2898-4599-8f55-0e322e7ab2a4"));

            migrationBuilder.DeleteData(
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("92a40e56-79f7-4a72-89af-53746a54be6f"));

            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "BuildingHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "BuildingId", "CashAmount", "CostTypeId", "EventDate", "FromDate", "ObjectStateId", "ToDate" },
                values: new object[,]
                {
                    { new Guid("5c9db8b4-f92d-4f75-92c0-d4154bede04f"), 1000m, new Guid("5bc530db-e4ce-4046-ac4a-e0559b48d1a8"), 40000m, new Guid("170555a9-de79-4c3c-bb84-098408a8d30a"), "1401/01/01", null, new Guid("20f179ef-ab00-40a1-a1a3-bc0e2444bc85"), null },
                    { new Guid("80957d72-4bba-42d7-8306-619081e93893"), 2000m, new Guid("6bf35be1-1677-4245-bba0-622ee23ce9d7"), 30000m, new Guid("dc59b74c-f132-4943-aad2-5d16161287de"), "", "1401/01/01", new Guid("80449d6d-a150-4f8f-a283-5bed489daf19"), "1401/03/01" }
                });

            migrationBuilder.InsertData(
                table: "UserAccesses",
                columns: new[] { "Id", "EndDate", "SignText", "StartDate", "UserAccessTypeId", "UserId" },
                values: new object[,]
                {
                    { new Guid("60ec61dc-1212-44ee-94c3-768de39201ad"), "9999/99/99", "بهناز پیشاهنگ _ اعضای ساختمان", "1401/10/20", new Guid("fa1d726c-615e-4e89-9aed-477e7cbd7e2b"), new Guid("d6023cd6-fde2-423d-a8ac-e2cfbd252ba3") },
                    { new Guid("a937d9d4-e9b0-401b-9b3c-60af5f686c8e"), "9999/99/99", "مجید عباسی _ مدیر ساختمان", "1401/10/20", new Guid("6524fa96-e320-413b-8695-8467c94465ee"), new Guid("75497455-5e77-42fa-87da-125b7686c3f2") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("5c9db8b4-f92d-4f75-92c0-d4154bede04f"));

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("80957d72-4bba-42d7-8306-619081e93893"));

            migrationBuilder.DeleteData(
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("60ec61dc-1212-44ee-94c3-768de39201ad"));

            migrationBuilder.DeleteData(
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("a937d9d4-e9b0-401b-9b3c-60af5f686c8e"));

            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "BuildingHistory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "BuildingId", "CashAmount", "CostTypeId", "EventDate", "FromDate", "ObjectStateId", "ToDate" },
                values: new object[,]
                {
                    { new Guid("42faf9fa-23f8-4a30-bbe9-aba4cf9f50b1"), 1000m, new Guid("5bc530db-e4ce-4046-ac4a-e0559b48d1a8"), 40000m, new Guid("170555a9-de79-4c3c-bb84-098408a8d30a"), "1401/01/01", null, new Guid("20f179ef-ab00-40a1-a1a3-bc0e2444bc85"), null },
                    { new Guid("ffc0437c-cdb6-4ecb-9ed1-aedd0c1c8821"), 2000m, new Guid("6bf35be1-1677-4245-bba0-622ee23ce9d7"), 30000m, new Guid("dc59b74c-f132-4943-aad2-5d16161287de"), "", "1401/01/01", new Guid("80449d6d-a150-4f8f-a283-5bed489daf19"), "1401/03/01" }
                });

            migrationBuilder.InsertData(
                table: "UserAccesses",
                columns: new[] { "Id", "EndDate", "SignText", "StartDate", "UserAccessTypeId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4a7c105a-2898-4599-8f55-0e322e7ab2a4"), "9999/99/99", "بهناز پیشاهنگ _ اعضای ساختمان", "1401/10/20", new Guid("fa1d726c-615e-4e89-9aed-477e7cbd7e2b"), new Guid("d6023cd6-fde2-423d-a8ac-e2cfbd252ba3") },
                    { new Guid("92a40e56-79f7-4a72-89af-53746a54be6f"), "9999/99/99", "مجید عباسی _ مدیر ساختمان", "1401/10/20", new Guid("6524fa96-e320-413b-8695-8467c94465ee"), new Guid("75497455-5e77-42fa-87da-125b7686c3f2") }
                });
        }
    }
}

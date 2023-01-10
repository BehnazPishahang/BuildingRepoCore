using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddmigrationData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "UserAccessTypes",
                columns: new[] { "Id", "Code", "State", "Title" },
                values: new object[,]
                {
                    { new Guid("6524fa96-e320-413b-8695-8467c94465ee"), "0001", 1, "مدیر ساختمان" },
                    { new Guid("fa1d726c-615e-4e89-9aed-477e7cbd7e2b"), "0002", 1, "اعضای ساختمان" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EndDate", "Family", "MobileNumber", "Name", "NationalCode", "PassWord", "Sex", "StartDate" },
                values: new object[,]
                {
                    { new Guid("75497455-5e77-42fa-87da-125b7686c3f2"), "9999/99/99", "عباسی", "09125873154", "مجید", "048403716", "gdyb21LQTcIANtvYMT7QVQ==", 2, "1401/10/20" },
                    { new Guid("d6023cd6-fde2-423d-a8ac-e2cfbd252ba3"), "9999/99/99", "پیشاهنگ", "09359384485", "بهناز", "1810089666", "gdyb21LQTcIANtvYMT7QVQ==", 1, "1401/10/20" }
                });

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "BuildingId", "CashAmount", "CostTypeId", "EventDate", "FromDate", "ObjectStateId", "ToDate" },
                values: new object[,]
                {
                    { new Guid("9869de4c-899a-4893-9fa8-4787ffb8937d"), 2000m, new Guid("6bf35be1-1677-4245-bba0-622ee23ce9d7"), 30000m, new Guid("dc59b74c-f132-4943-aad2-5d16161287de"), "", "1401/01/01", new Guid("80449d6d-a150-4f8f-a283-5bed489daf19"), "1401/03/01" },
                    { new Guid("b1a0f110-8d44-49e3-919c-4b92fb22e9c7"), 1000m, new Guid("5bc530db-e4ce-4046-ac4a-e0559b48d1a8"), 40000m, new Guid("170555a9-de79-4c3c-bb84-098408a8d30a"), "1401/01/01", null, new Guid("20f179ef-ab00-40a1-a1a3-bc0e2444bc85"), null }
                });

            migrationBuilder.InsertData(
                table: "UserAccesses",
                columns: new[] { "Id", "EndDate", "SignText", "StartDate", "UserAccessTypeId", "UserId" },
                values: new object[,]
                {
                    { new Guid("05b07b32-494c-47cd-9332-d4a1ffd4b670"), "9999/99/99", "بهناز پیشاهنگ _ اعضای ساختمان", "1401/10/20", new Guid("fa1d726c-615e-4e89-9aed-477e7cbd7e2b"), new Guid("d6023cd6-fde2-423d-a8ac-e2cfbd252ba3") },
                    { new Guid("7a57aecf-2187-43cb-9a53-5583aa082a30"), "9999/99/99", "مجید عباسی _ مدیر ساختمان", "1401/10/20", new Guid("6524fa96-e320-413b-8695-8467c94465ee"), new Guid("75497455-5e77-42fa-87da-125b7686c3f2") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("9869de4c-899a-4893-9fa8-4787ffb8937d"));

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("b1a0f110-8d44-49e3-919c-4b92fb22e9c7"));

            migrationBuilder.DeleteData(
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("05b07b32-494c-47cd-9332-d4a1ffd4b670"));

            migrationBuilder.DeleteData(
                table: "UserAccesses",
                keyColumn: "Id",
                keyValue: new Guid("7a57aecf-2187-43cb-9a53-5583aa082a30"));

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

            migrationBuilder.DeleteData(
                table: "UserAccessTypes",
                keyColumn: "Id",
                keyValue: new Guid("6524fa96-e320-413b-8695-8467c94465ee"));

            migrationBuilder.DeleteData(
                table: "UserAccessTypes",
                keyColumn: "Id",
                keyValue: new Guid("fa1d726c-615e-4e89-9aed-477e7cbd7e2b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("75497455-5e77-42fa-87da-125b7686c3f2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d6023cd6-fde2-423d-a8ac-e2cfbd252ba3"));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCRestaurant.Infrastructure.Migrations
{
    public partial class LogsDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SubmitDate",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15337A34-8592-4417-8C9E-ACF960B00102",
                column: "ConcurrencyStamp",
                value: "aadd7f87-cf21-4935-b4bf-017d799568c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29D9873B-8339-4E70-8DE4-544507529A74",
                column: "ConcurrencyStamp",
                value: "0b311a97-1da4-41a6-bb18-a15af390c5c6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5E1C722F-5CD8-45F4-94A9-14508F2C8E54",
                column: "ConcurrencyStamp",
                value: "950ef34a-bab3-4009-9979-c4926c33e082");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D0074DD6-E540-45D4-A804-5E1A42C81661",
                column: "ConcurrencyStamp",
                value: "7212e229-b1f3-43ca-b7af-5522968ce578");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5840658-d4ed-4f5b-a915-d8527205d355", "AQAAAAEAACcQAAAAEL+67sZeeKiDAmZytUOUI6RByjZ0t6tpffc9PjvbnlwXfGw70C7yMlb/dlO5Oz8WSw==", "dbe2c5cd-0d79-42bb-9a64-717434906d7b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B37C0271-DDD7-4124-AD52-69360F5A219F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23e678eb-110b-4a12-99a9-853ca562119c", "AQAAAAEAACcQAAAAEA8r/UKhoAyov90fvl211OzOdXctgFnOVZwmtcqVeZdACePzwok8x9iol2Ys7iO+9A==", "2980f0df-92be-4920-90de-474d34d463e2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmitDate",
                table: "Logs");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15337A34-8592-4417-8C9E-ACF960B00102",
                column: "ConcurrencyStamp",
                value: "ea68f40d-2351-4bc1-a62a-d9940f81b92d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29D9873B-8339-4E70-8DE4-544507529A74",
                column: "ConcurrencyStamp",
                value: "9bb2909f-bf51-4bc0-b0ba-c0e8a722ca0c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5E1C722F-5CD8-45F4-94A9-14508F2C8E54",
                column: "ConcurrencyStamp",
                value: "ced4e4bd-ff32-4061-a0b7-e6d4b479f707");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D0074DD6-E540-45D4-A804-5E1A42C81661",
                column: "ConcurrencyStamp",
                value: "4c763f5e-8bd2-432a-a26f-0db5899935bd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0fe9e22-1ed2-4cdf-87b4-9264c68c555b", "AQAAAAEAACcQAAAAEALV3JgAxa8ebvQU6Up1eT1DoDCr/JRN7LVToP310TeZ4fmx5DdIwTUKn+9HFaGwrQ==", "c9a7340a-9d7f-46bc-b00c-dc906f3dc3f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B37C0271-DDD7-4124-AD52-69360F5A219F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "230fd5bb-a9fa-4227-ac09-5cc08427e05c", "AQAAAAEAACcQAAAAEIc0WioJTbIs5zB+bLTL7UXRShboLzHGYy87TQuNN+Gf0KwYs4reajbqK3HtulJjQQ==", "d2980df2-b113-436f-a0c9-9d08efcdb39d" });
        }
    }
}

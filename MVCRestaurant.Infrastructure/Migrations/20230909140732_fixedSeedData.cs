using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCRestaurant.Infrastructure.Migrations
{
    public partial class fixedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "29D9873B-8339-4E70-8DE4-544507529A74", "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15337A34-8592-4417-8C9E-ACF960B00102",
                column: "ConcurrencyStamp",
                value: "e831bff1-9a10-410c-bf7a-3dd5ee8a3981");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29D9873B-8339-4E70-8DE4-544507529A74",
                column: "ConcurrencyStamp",
                value: "07ab8cfb-7f46-4ecb-b324-be27558668bc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5E1C722F-5CD8-45F4-94A9-14508F2C8E54",
                column: "ConcurrencyStamp",
                value: "e827b4d8-170d-44cb-9554-afae874bf533");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D0074DD6-E540-45D4-A804-5E1A42C81661",
                column: "ConcurrencyStamp",
                value: "9314bcf1-d253-4542-b3c2-73521f90c4db");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B37C0271-DDD7-4124-AD52-69360F5A219F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02717ee8-f535-4c57-8c56-ee4331f06ec1", "AQAAAAEAACcQAAAAEP2pOC8lC0mcFseqtdi2IW5OWfz2/XHehJ1gslGo3Q7NdcyzFMohmMPABIloTJ7HMQ==", "22112efb-ed6d-4c9b-9bdd-154be550b36f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                keyValue: "B37C0271-DDD7-4124-AD52-69360F5A219F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23e678eb-110b-4a12-99a9-853ca562119c", "AQAAAAEAACcQAAAAEA8r/UKhoAyov90fvl211OzOdXctgFnOVZwmtcqVeZdACePzwok8x9iol2Ys7iO+9A==", "2980f0df-92be-4920-90de-474d34d463e2" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "AltKey", "ConcurrencyStamp", "Email", "EmailConfirmed", "Latitude", "LockoutEnabled", "LockoutEnd", "Longitude", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E", 0, null, 2m, "c5840658-d4ed-4f5b-a915-d8527205d355", "admin@g.com", true, 0f, false, null, 0f, "ADMIN@G.COM", "ادمین", "AQAAAAEAACcQAAAAEL+67sZeeKiDAmZytUOUI6RByjZ0t6tpffc9PjvbnlwXfGw70C7yMlb/dlO5Oz8WSw==", null, false, "dbe2c5cd-0d79-42bb-9a64-717434906d7b", false, "ادمین" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "29D9873B-8339-4E70-8DE4-544507529A74", "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E" });
        }
    }
}

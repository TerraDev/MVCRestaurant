using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCRestaurant.Infrastructure.Migrations
{
    public partial class initAdminData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15337A34-8592-4417-8C9E-ACF960B00102",
                column: "ConcurrencyStamp",
                value: "be98bd66-b5ca-410e-8d36-fbecb42fc7fb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29D9873B-8339-4E70-8DE4-544507529A74",
                column: "ConcurrencyStamp",
                value: "c41bea66-641b-4053-8dd2-f8709e743d67");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5E1C722F-5CD8-45F4-94A9-14508F2C8E54",
                column: "ConcurrencyStamp",
                value: "a9cb16da-6072-4b5a-9e92-aaeddfe98180");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D0074DD6-E540-45D4-A804-5E1A42C81661",
                column: "ConcurrencyStamp",
                value: "e676c5d3-4968-49db-8998-3efcb40737f0");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "AltKey", "ConcurrencyStamp", "Email", "EmailConfirmed", "Latitude", "LockoutEnabled", "LockoutEnd", "Longitude", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E", 0, null, 2m, "e48917f1-c364-4428-b8e7-becb99f1e62c", "admin@g.com", true, 0f, false, null, 0f, "ADMIN@G.COM", "ادمین", "AQAAAAEAACcQAAAAECydUovOwrMoDu82mVZCjdZtEzl7D09z/FrvuhrN2XsZeXYrfQJbsZXtp3MKgljswQ==", null, false, "469886c8-9667-4f9c-bb37-739b702bbfaf", false, "ادمین" },
                    { "B37C0271-DDD7-4124-AD52-69360F5A219F", 0, null, 1m, "5067d922-1863-4271-a868-2103b21db029", "Sadmin@g.com", true, 0f, false, null, 0f, "SADMIN@G.COM", "ادمین کل", "AQAAAAEAACcQAAAAEHkcflrskAD71Z3mUTLRwwFLI1MlxZbgdzw5uD8UqrHpK5weoM15ST0epxH939ubyw==", null, false, "9a9bf565-f42e-4948-aeff-ab1e00f4c282", false, "ادمین کل" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "29D9873B-8339-4E70-8DE4-544507529A74", "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "15337A34-8592-4417-8C9E-ACF960B00102", "B37C0271-DDD7-4124-AD52-69360F5A219F" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "29D9873B-8339-4E70-8DE4-544507529A74", "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "15337A34-8592-4417-8C9E-ACF960B00102", "B37C0271-DDD7-4124-AD52-69360F5A219F" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B37C0271-DDD7-4124-AD52-69360F5A219F");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15337A34-8592-4417-8C9E-ACF960B00102",
                column: "ConcurrencyStamp",
                value: "312ec37d-434f-4550-a642-bcf0e1928a6f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29D9873B-8339-4E70-8DE4-544507529A74",
                column: "ConcurrencyStamp",
                value: "76f197c8-feca-4e08-a818-d3002827c936");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5E1C722F-5CD8-45F4-94A9-14508F2C8E54",
                column: "ConcurrencyStamp",
                value: "0369e746-302d-470f-b940-819b123ce409");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D0074DD6-E540-45D4-A804-5E1A42C81661",
                column: "ConcurrencyStamp",
                value: "85e362e4-cdea-4506-9338-bdd8fd92fae9");
        }
    }
}

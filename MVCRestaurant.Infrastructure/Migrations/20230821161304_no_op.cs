using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCRestaurant.Infrastructure.Migrations
{
    public partial class no_op : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15337A34-8592-4417-8C9E-ACF960B00102",
                column: "ConcurrencyStamp",
                value: "58d0536b-43cf-4d3b-9cf1-1f3fba59dbb5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29D9873B-8339-4E70-8DE4-544507529A74",
                column: "ConcurrencyStamp",
                value: "bdad63ae-a484-4f42-b121-e91bf2274bf6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5E1C722F-5CD8-45F4-94A9-14508F2C8E54",
                column: "ConcurrencyStamp",
                value: "ef6cb803-b184-49c0-8c39-043b4c7da27e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D0074DD6-E540-45D4-A804-5E1A42C81661",
                column: "ConcurrencyStamp",
                value: "8fa56791-479b-45c8-8d26-1900c1893a52");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3c9598b-c2e7-465c-b130-7c81dfbedf98", "AQAAAAEAACcQAAAAEKcJYBng2cH3iyKxXr0XIwoQlI5uygLnWY3QuFrFVlmRdgpHX6WCDZQGUV/rnY9Rsw==", "72a823e0-4ed9-4944-8289-d9a2158ec860" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B37C0271-DDD7-4124-AD52-69360F5A219F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5446cab2-6714-43c0-99cf-e75e63362a26", "AQAAAAEAACcQAAAAEOzRmW5WFh9lQYCTz3f/a5iTaMLwdXW7MbwQZj4wxyTVAKRfLy9okt27dlZzg96WWg==", "fe489586-b5ab-47b0-b070-9b07187431c0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e48917f1-c364-4428-b8e7-becb99f1e62c", "AQAAAAEAACcQAAAAECydUovOwrMoDu82mVZCjdZtEzl7D09z/FrvuhrN2XsZeXYrfQJbsZXtp3MKgljswQ==", "469886c8-9667-4f9c-bb37-739b702bbfaf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B37C0271-DDD7-4124-AD52-69360F5A219F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5067d922-1863-4271-a868-2103b21db029", "AQAAAAEAACcQAAAAEHkcflrskAD71Z3mUTLRwwFLI1MlxZbgdzw5uD8UqrHpK5weoM15ST0epxH939ubyw==", "9a9bf565-f42e-4948-aeff-ab1e00f4c282" });
        }
    }
}

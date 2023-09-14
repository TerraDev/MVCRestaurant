using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCRestaurant.Infrastructure.Migrations
{
    public partial class InvoicePathisNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InvoicePath",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15337A34-8592-4417-8C9E-ACF960B00102",
                column: "ConcurrencyStamp",
                value: "336366f3-92d8-401d-94f4-e4074765cd5c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29D9873B-8339-4E70-8DE4-544507529A74",
                column: "ConcurrencyStamp",
                value: "7bc174cf-8529-4d6e-bcb0-101c993d25ff");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5E1C722F-5CD8-45F4-94A9-14508F2C8E54",
                column: "ConcurrencyStamp",
                value: "099860f1-d1e5-47b4-a38f-40cafd848688");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D0074DD6-E540-45D4-A804-5E1A42C81661",
                column: "ConcurrencyStamp",
                value: "d7b11848-9b04-4a5f-951d-f4f34eb3e5bb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "688255d5-469d-4882-b900-62722a8cc2d0", "AQAAAAEAACcQAAAAEA0JckvBsHOYZlTieYaOZA2GsnDdv9R7oCtB+7O7ltupEAIgkCJraC8CN/HsUbdlcw==", "05a70e05-6eb5-4a86-ad96-3058d856c3ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B37C0271-DDD7-4124-AD52-69360F5A219F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcfb02dd-7b60-4778-96ac-65798416122b", "AQAAAAEAACcQAAAAENbiLul8zK6eyIq35YVmi9WnFwOcaFje5S/dtc34JGzu2vv/07uYODPzBTMZbC5Mzw==", "b4c11ac0-8468-4b3e-9c20-e518568dee28" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InvoicePath",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15337A34-8592-4417-8C9E-ACF960B00102",
                column: "ConcurrencyStamp",
                value: "554bd2a7-6828-495d-aba6-b238ade3aac0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29D9873B-8339-4E70-8DE4-544507529A74",
                column: "ConcurrencyStamp",
                value: "e23c40bd-bc27-4fd0-9184-ddc876c4642c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5E1C722F-5CD8-45F4-94A9-14508F2C8E54",
                column: "ConcurrencyStamp",
                value: "a4660269-a9a6-403d-b8d1-115a386bcec3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D0074DD6-E540-45D4-A804-5E1A42C81661",
                column: "ConcurrencyStamp",
                value: "122e8bb2-e667-4ff8-b426-c44d618e4ce5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2648c507-32eb-47b6-a2ea-38ba8b468dda", "AQAAAAEAACcQAAAAEGiPB9nCGJUy7ZjOkjGnvL4SITam/CokCZNIJ1sMN1ZIFiWzdWN3E45Vusybgw2AIQ==", "b13d9626-621a-4e25-8e99-0ac2e75ef5ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B37C0271-DDD7-4124-AD52-69360F5A219F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6b71b2e-6131-468a-8b1c-3b7c2ec60f14", "AQAAAAEAACcQAAAAEBXSVyk+6ZHjvG6MXgJaTR4+FyGsIx0uQ6eJG4Tqow9SZmNrmX98nNOZVQjmQCpQsw==", "7717f4fb-9206-4296-89e0-0f39dc5d0274" });
        }
    }
}

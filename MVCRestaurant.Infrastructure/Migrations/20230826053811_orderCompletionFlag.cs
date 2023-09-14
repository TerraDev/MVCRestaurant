using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCRestaurant.Infrastructure.Migrations
{
    public partial class orderCompletionFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoicePath",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "OrderCompleted",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15337A34-8592-4417-8C9E-ACF960B00102",
                column: "ConcurrencyStamp",
                value: "41cc2bd9-28cf-42f7-93b1-77a4ef601d0e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29D9873B-8339-4E70-8DE4-544507529A74",
                column: "ConcurrencyStamp",
                value: "4b3d8992-319a-4d89-bf3c-1b555badfb25");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5E1C722F-5CD8-45F4-94A9-14508F2C8E54",
                column: "ConcurrencyStamp",
                value: "68ae8bca-526f-4388-8f7c-c684129940df");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D0074DD6-E540-45D4-A804-5E1A42C81661",
                column: "ConcurrencyStamp",
                value: "d8f2b532-ddc1-4ab5-9555-8be4147f912e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d0b0821-e06d-44f4-919f-4212c324fdf2", "AQAAAAEAACcQAAAAEETvY0X+Ak9RHTvA+thf+vCFyEGstJecb03xay6OtFLLonHyHABaAZ89XqWEbQQZUw==", "85bdf094-4115-4f1d-b074-573d122af4b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B37C0271-DDD7-4124-AD52-69360F5A219F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0bf6fa8f-dc07-456d-8e2b-b7c3c660f4db", "AQAAAAEAACcQAAAAEET4W3eZnm7CihzbNYLsBJcm1mXEKEDKINGRhnE3NYh4KIfWUoHNLDPD4Sul48yrsg==", "599d844b-04ce-4265-8ca7-45e96fb829f1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCompleted",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "InvoicePath",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCRestaurant.Infrastructure.Migrations
{
    public partial class addedInvoicePathItemQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvoicePath",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "quantity",
                table: "OrderItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoicePath",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "OrderItems");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15337A34-8592-4417-8C9E-ACF960B00102",
                column: "ConcurrencyStamp",
                value: "ea2647e5-5648-4f50-9d23-baf3416b0b8e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29D9873B-8339-4E70-8DE4-544507529A74",
                column: "ConcurrencyStamp",
                value: "e743abd8-6665-4c54-8ce5-a29580bee42f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5E1C722F-5CD8-45F4-94A9-14508F2C8E54",
                column: "ConcurrencyStamp",
                value: "2d07e7d4-180f-43a2-ac51-fb323787280f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D0074DD6-E540-45D4-A804-5E1A42C81661",
                column: "ConcurrencyStamp",
                value: "c4443a6a-ca25-4850-b472-db489d49659b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c8e08ab-8da7-4848-bce8-9f2e750358c2", "AQAAAAEAACcQAAAAEFbs/ATMOuPyegAL8F71EDUcOOwJ0eUqCT9VhWWsSKxIneNyoJwfyrF1DQNStHiFHQ==", "ca38d08b-9b54-4056-9ff2-cd1ca4b91edf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B37C0271-DDD7-4124-AD52-69360F5A219F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5813aa44-a83c-439b-8385-0b3f19f2daa8", "AQAAAAEAACcQAAAAEDGNDFziM2QXRwJndne6vSc6UccFSEParHTb2WY5WgA2vK+50nGOgmtmZ5J3Zyy95A==", "0fe0ab73-4f26-4a07-9cd1-2c55a65cbc7a" });
        }
    }
}

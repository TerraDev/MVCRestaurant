using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCRestaurant.Infrastructure.Migrations
{
    public partial class LastModifiedDateisNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "FoodItems",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "FoodCategories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "FoodItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "FoodCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
    }
}

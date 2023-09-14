using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCRestaurant.Infrastructure.Migrations
{
    public partial class seedRolesWithNormalizedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15337A34-8592-4417-8C9E-ACF960B00102",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "ea68f40d-2351-4bc1-a62a-d9940f81b92d", "SUPERADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29D9873B-8339-4E70-8DE4-544507529A74",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "9bb2909f-bf51-4bc0-b0ba-c0e8a722ca0c", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5E1C722F-5CD8-45F4-94A9-14508F2C8E54",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "ced4e4bd-ff32-4061-a0b7-e6d4b479f707", "EMPLOYEE" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D0074DD6-E540-45D4-A804-5E1A42C81661",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "4c763f5e-8bd2-432a-a26f-0db5899935bd", "CUSTOMER" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15337A34-8592-4417-8C9E-ACF960B00102",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "41cc2bd9-28cf-42f7-93b1-77a4ef601d0e", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29D9873B-8339-4E70-8DE4-544507529A74",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "4b3d8992-319a-4d89-bf3c-1b555badfb25", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5E1C722F-5CD8-45F4-94A9-14508F2C8E54",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "68ae8bca-526f-4388-8f7c-c684129940df", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D0074DD6-E540-45D4-A804-5E1A42C81661",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "d8f2b532-ddc1-4ab5-9555-8be4147f912e", null });

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
    }
}

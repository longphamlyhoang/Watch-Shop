using Microsoft.EntityFrameworkCore.Migrations;

namespace watchShop.Migrations
{
    public partial class login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12966b9e-eca5-4356-83d7-cb356e4aa898", "AQAAAAEAACcQAAAAENhEPCUCU8/iCN4MVSRj+PlFvgpE5r+MuzEfQxhUNV4L0xC15H0rjcC04//m0TtbxA==", "8da9f58d-6d4d-4b0d-9ceb-603910be2ebe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29c5e814-7220-4f04-a6a9-345f6bd13042", "AQAAAAEAACcQAAAAEGSv+Vw0z3Md2b01VF57wrznClcqSYt2LiL9rNWEVnhAGyTuR23dDdhwgTqKYEl3vA==", "23a81350-e7af-4d31-bf24-130877bf2ba5" });
        }
    }
}

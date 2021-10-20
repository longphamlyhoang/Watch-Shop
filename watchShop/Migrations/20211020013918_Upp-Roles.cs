using Microsoft.EntityFrameworkCore.Migrations;

namespace watchShop.Migrations
{
    public partial class UppRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6cc911c3-0846-4bdf-bfd2-dcb7065a2cfe", "AQAAAAEAACcQAAAAEP5zF3XYDIgyqeAD5syI3zF5EEP9DB/U3mflDmbqrlC2bPGgJgjmSyKLjnjlamYlCg==", "b10c8ecf-a334-4547-a397-9364ec2695ee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12966b9e-eca5-4356-83d7-cb356e4aa898", "AQAAAAEAACcQAAAAENhEPCUCU8/iCN4MVSRj+PlFvgpE5r+MuzEfQxhUNV4L0xC15H0rjcC04//m0TtbxA==", "8da9f58d-6d4d-4b0d-9ceb-603910be2ebe" });
        }
    }
}

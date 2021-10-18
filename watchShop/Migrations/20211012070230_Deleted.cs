using Microsoft.EntityFrameworkCore.Migrations;

namespace watchShop.Migrations
{
    public partial class Deleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "products",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Quantity",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "CategoryId", "Pictures", "Price", "ProductName", "Quantity", "Status", "TradeMark" },
                values: new object[] { 1, 1, "~/Images/nam.png", 23000000, "Đồng hồ nam Seiko5", "Đồng hồ nam Seiko5", true, "Nhật Bản" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "CategoryId", "Pictures", "Price", "ProductName", "Quantity", "Status", "TradeMark" },
                values: new object[] { 2, 2, "~/Images/nu.png", 23000000, "Đồng hồ nữ SUR280P1", "Đồng hồ nam SUR280P1", true, "Hàn Quốc" });
        }
    }
}

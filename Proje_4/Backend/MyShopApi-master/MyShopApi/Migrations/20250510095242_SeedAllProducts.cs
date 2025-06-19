using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShopApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedAllProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Stock",
                value: 10);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "Price", "Stock" },
                values: new object[] { 3, "Şık dijital kol saati", "/images/watch.jpg", "Kol Saati", 129.99m, 5 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Stock",
                value: 5);
        }
    }
}

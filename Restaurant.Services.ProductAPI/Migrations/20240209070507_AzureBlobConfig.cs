using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurant.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class AzureBlobConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "DateDeleted", "ImageUrl", "ProductDescription", "ProductName", "ProductPrice" },
                values: new object[,]
                {
                    { 1, "Appetizer", null, "https://sarovarblob.blob.core.windows.net/restaurant/1.jpg", "Samosa Ho yarr", "Samosa", 15.0 },
                    { 2, "Appetizer", null, "https://sarovarblob.blob.core.windows.net/restaurant/2.jpg", "Mittho Chicken Momo", "Chicken Momo", 53.990000000000002 },
                    { 3, "Dessert", null, "https://sarovarblob.blob.core.windows.net/restaurant/3.jpg", "Yesko craving bhaira cha", "Cheese Cake", 10.99 },
                    { 4, "Entree", null, "https://sarovarblob.blob.core.windows.net/restaurant/4.jpg", "4 Products are enough", "Chowmein", 15.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Products");
        }
    }
}

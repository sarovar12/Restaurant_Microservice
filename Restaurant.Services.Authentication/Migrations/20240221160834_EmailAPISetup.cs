using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurant.Services.Authentication.Migrations
{
    /// <inheritdoc />
    public partial class EmailAPISetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3790ec2c-4085-4e53-a45d-79090d748ce1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8ed15c1-a5a0-48b2-b656-77a9f50c49ef");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40ddae72-9e6c-4c74-8964-d001d023aae1", null, "Customer", "CUSTOMER" },
                    { "aed8c21c-cc34-466a-b61e-f7a7dc5f4bfa", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40ddae72-9e6c-4c74-8964-d001d023aae1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aed8c21c-cc34-466a-b61e-f7a7dc5f4bfa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3790ec2c-4085-4e53-a45d-79090d748ce1", null, "Customer", "CUSTOMER" },
                    { "c8ed15c1-a5a0-48b2-b656-77a9f50c49ef", null, "Admin", "ADMIN" }
                });
        }
    }
}

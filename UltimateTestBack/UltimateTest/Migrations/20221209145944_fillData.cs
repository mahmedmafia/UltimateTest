using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UltimateTest.Migrations
{
    /// <inheritdoc />
    public partial class fillData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Code", "Description", "Mobile", "Name" },
                values: new object[,]
                {
                    { 1, "122", "Good customer", "01202112", "Farid" },
                    { 2, "515", "customer", "021312312", "Saner" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "Building", "City", "CustomerId", "Floor", "Street", "Zone" },
                values: new object[,]
                {
                    { 1, 2, "CWQ", 1, 2, "SA", "HAs" },
                    { 2, 2, "qwq", 1, 2, "asa", "safa" },
                    { 3, 2, "aSA", 2, 2, "qeq", "vzv" },
                    { 4, 2, "assa", 2, 2, "vzvz", "xzxz" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);
        }
    }
}

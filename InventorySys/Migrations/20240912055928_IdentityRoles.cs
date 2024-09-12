using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventorySys.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34396205-d46a-443b-b0e2-bb7fb1ede9e9", "f0cfbe80-2ede-49d0-807a-124f43e8b22f", "Admin", "ADMIN" },
                    { "c5fbe0ae-8e0b-481d-90c6-af96b91bcbde", "25d6ae38-3e8a-49dd-a5bd-c42515770b65", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34396205-d46a-443b-b0e2-bb7fb1ede9e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5fbe0ae-8e0b-481d-90c6-af96b91bcbde");
        }
    }
}

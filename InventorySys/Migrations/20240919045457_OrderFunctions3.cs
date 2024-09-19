using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventorySys.Migrations
{
    /// <inheritdoc />
    public partial class OrderFunctions3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4df26f4f-d7b1-4013-849e-1e9e1dd97427");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cca1f633-00f9-4756-8f12-8d74d18ac0df");

            migrationBuilder.AddColumn<bool>(
                name: "isCompleted",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2228678f-469d-4995-a206-76ad955209e3", "becee750-c732-472c-a8b5-60166e46b2c1", "Admin", "ADMIN" },
                    { "d4b42db4-d7c7-46d7-8f2c-b98f20f95a99", "0479fd43-575e-46d6-a3e7-b605f892a945", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2228678f-469d-4995-a206-76ad955209e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4b42db4-d7c7-46d7-8f2c-b98f20f95a99");

            migrationBuilder.DropColumn(
                name: "isCompleted",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4df26f4f-d7b1-4013-849e-1e9e1dd97427", "b261ea46-f605-46ae-9a38-ec2f7a7a6b48", "Admin", "ADMIN" },
                    { "cca1f633-00f9-4756-8f12-8d74d18ac0df", "515f6ca2-71aa-491b-a86f-5f5b434c27b5", "User", "USER" }
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class rolesmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "guid_ekta_1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c320a492-c8ea-496a-9b63-dbe070b29d9e", "7844e2ea-83ce-480c-8550-61f00305fdc1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "guid_ekta_2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "33662aa7-57ad-4a88-8bfe-6d2bb2d99a2c", "f2b25603-32c3-41a8-bfd9-52bc8a4fc23c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "guid_ekta_1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dbb51655-524d-41ec-9f81-54e8f8d88b67", "c175275b-0340-4469-9c25-6c67abc18442" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "guid_ekta_2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "42ff157b-6058-4669-b81d-acd46750bad1", "362110e4-49ff-4147-b906-f2b80680c521" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Analysis.Data.Migrations
{
    /// <inheritdoc />
    public partial class RolesSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0630d869-9d72-4e41-a4c7-877be549aeed", "2", "Supervisor", "Supervisor" },
                    { "8f22c0d7-8e1c-45e3-9136-77d1ec4d3dc0", "3", "Manager", "Manager" },
                    { "bed16cd3-9557-4869-b0b0-04a1d0e11c74", "1", "Analyst", "Analyst" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0630d869-9d72-4e41-a4c7-877be549aeed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f22c0d7-8e1c-45e3-9136-77d1ec4d3dc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bed16cd3-9557-4869-b0b0-04a1d0e11c74");
        }
    }
}

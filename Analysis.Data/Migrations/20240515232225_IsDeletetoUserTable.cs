using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Analysis.Data.Migrations
{
    /// <inheritdoc />
    public partial class IsDeletetoUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7704fc31-3e9a-4ea7-8198-f1acbd96d2b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f4e5078-bc11-4dd4-8fe6-5bddd6b3c350");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af9a05c1-91b4-4998-8c1a-d6250e713adf");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4100745e-bfb2-4bbc-a743-5e6443eff2fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99e52313-7995-4597-addf-9818c358617a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef51ffc0-477d-4464-bdb4-627543a186c2");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7704fc31-3e9a-4ea7-8198-f1acbd96d2b9", "2", "Supervisor", "Supervisor" },
                    { "7f4e5078-bc11-4dd4-8fe6-5bddd6b3c350", "1", "Analyst", "Analyst" },
                    { "af9a05c1-91b4-4998-8c1a-d6250e713adf", "3", "Manager", "Manager" }
                });
        }
    }
}

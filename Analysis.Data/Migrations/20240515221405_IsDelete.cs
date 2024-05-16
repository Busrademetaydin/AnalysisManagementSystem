using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Analysis.Data.Migrations
{
    /// <inheritdoc />
    public partial class IsDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "329fe4e1-f62c-4c78-8ed1-4a3fb5094bcc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fca1ff6-fd86-4574-8851-1ece9bab717a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3698f77-b87d-4cf1-97d7-2366ae85a462");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "HPLCEquipments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Drugs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "TcNo",
                table: "AspNetUsers",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "AnalyzeTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Analyzes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "AnalyzeDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Analysts",
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
                keyValue: "7704fc31-3e9a-4ea7-8198-f1acbd96d2b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f4e5078-bc11-4dd4-8fe6-5bddd6b3c350");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af9a05c1-91b4-4998-8c1a-d6250e713adf");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "HPLCEquipments");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "AnalyzeTypes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Analyzes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "AnalyzeDetails");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Analysts");

            migrationBuilder.AlterColumn<string>(
                name: "TcNo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "329fe4e1-f62c-4c78-8ed1-4a3fb5094bcc", "3", "Manager", "Manager" },
                    { "8fca1ff6-fd86-4574-8851-1ece9bab717a", "2", "Supervisor", "Supervisor" },
                    { "b3698f77-b87d-4cf1-97d7-2366ae85a462", "1", "Analyst", "Analyst" }
                });
        }
    }
}

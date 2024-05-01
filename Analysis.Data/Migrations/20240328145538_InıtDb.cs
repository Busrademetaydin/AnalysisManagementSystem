using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Analysis.Data.Migrations
{
	/// <inheritdoc />
	public partial class InıtDb : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Analysts",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Gender = table.Column<bool>(type: "bit", nullable: true),
					Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					IdentificationNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
					Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
					UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Analysts", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AnalyzeTypes",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
					Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
					Active = table.Column<bool>(type: "bit", nullable: false),
					CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
					UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AnalyzeTypes", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Drugs",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ProductCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
					BatchNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
					Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
					DosageForm = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
					MFGDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
					EXPDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
					StorageCondition = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
					UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Drugs", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "HPLCEquipments",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Brand = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
					SerialNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
					CalibrationDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
					UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_HPLCEquipments", x => x.Id);
				});





			migrationBuilder.CreateTable(
				name: "Analyzes",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),

					StartDate = table.Column<DateOnly>(type: "date", nullable: false),
					EndDate = table.Column<DateOnly>(type: "date", nullable: false),
					Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
					AnalystId = table.Column<int>(type: "int", nullable: false),
					EquipmentId = table.Column<int>(type: "int", nullable: false),
					AnalyzeTypeId = table.Column<int>(type: "int", nullable: false),
					CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
					UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Analyzes", x => x.Id);
					table.ForeignKey(
						name: "FK_Analyzes_Analysts_AnalystId",
						column: x => x.AnalystId,
						principalTable: "Analysts",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Analyzes_AnalyzeTypes_AnalyzeTypeId",
						column: x => x.AnalyzeTypeId,
						principalTable: "AnalyzeTypes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Analyzes_HPLCEquipments_EquipmentId",
						column: x => x.EquipmentId,
						principalTable: "HPLCEquipments",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});



			migrationBuilder.CreateTable(
				name: "AnalyzeDetails",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					AnalyzeId = table.Column<int>(type: "int", nullable: false),
					DrugId = table.Column<int>(type: "int", nullable: false),
					Limit = table.Column<int>(type: "int", maxLength: 50, nullable: false),
					Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
					CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
					UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AnalyzeDetails", x => x.Id);
					table.ForeignKey(
						name: "FK_AnalyzeDetails_Analyzes_AnalyzeId",
						column: x => x.AnalyzeId,
						principalTable: "Analyzes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AnalyzeDetails_Drugs_DrugId",
						column: x => x.DrugId,
						principalTable: "Drugs",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});



			migrationBuilder.CreateIndex(
				name: "IX_Analysts_Email",
				table: "Analysts",
				column: "Email",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Analysts_IdentificationNumber",
				table: "Analysts",
				column: "IdentificationNumber",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Analysts_Phone",
				table: "Analysts",
				column: "Phone",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_AnalyzeDetails_AnalyzeId",
				table: "AnalyzeDetails",
				column: "AnalyzeId");

			migrationBuilder.CreateIndex(
				name: "IX_AnalyzeDetails_DrugId",
				table: "AnalyzeDetails",
				column: "DrugId");

			migrationBuilder.CreateIndex(
				name: "IX_Analyzes_AnalystId",
				table: "Analyzes",
				column: "AnalystId");

			migrationBuilder.CreateIndex(
				name: "IX_Analyzes_AnalyzeTypeId",
				table: "Analyzes",
				column: "AnalyzeTypeId");

			migrationBuilder.CreateIndex(
				name: "IX_Analyzes_EquipmentId",
				table: "Analyzes",
				column: "EquipmentId");




		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "AnalyzeDetails");


			migrationBuilder.DropTable(
				name: "Analyzes");

			migrationBuilder.DropTable(
				name: "Drugs");





			migrationBuilder.DropTable(
				name: "Analysts");

			migrationBuilder.DropTable(
				name: "AnalyzeTypes");

			migrationBuilder.DropTable(
				name: "HPLCEquipments");
		}
	}
}

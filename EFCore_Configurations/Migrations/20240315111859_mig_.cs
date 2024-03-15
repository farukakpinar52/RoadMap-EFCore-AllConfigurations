using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_Configurations.Migrations
{
    /// <inheritdoc />
    public partial class mig_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departmans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmanName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmanId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Midname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prim = table.Column<float>(type: "real", nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false),
                    ComputedColumn = table.Column<float>(type: "real", nullable: true, computedColumnSql: "[Prim]+[Salary]"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotMappedPropumuz = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyCheckColumn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Departmans_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departmans",
                columns: new[] { "Id", "DepartmanName" },
                values: new object[] { 5, "Insan Kaynaks" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "ConcurrencyCheckColumn", "CreatedDate", "DepartmanId", "Midname", "Name", "NotMappedPropumuz", "Prim", "Salary", "Surname" },
                values: new object[] { 5, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "", "Ali", 0, 5f, 100f, "KK" });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DepartmanId",
                table: "Persons",
                column: "DepartmanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Departmans");
        }
    }
}

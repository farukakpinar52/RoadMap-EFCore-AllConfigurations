using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_Configurations.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departmans",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<float>(
                name: "ComputedColumn",
                table: "Persons",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true,
                oldComputedColumnSql: "[Prim]+[Salary]");

            migrationBuilder.CreateTable(
                name: "BaseEntitys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseProp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ayırıcı = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Derived1Prop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Derived2Prop = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntitys", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseEntitys");

            migrationBuilder.AlterColumn<float>(
                name: "ComputedColumn",
                table: "Persons",
                type: "real",
                nullable: true,
                computedColumnSql: "[Prim]+[Salary]",
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Departmans",
                columns: new[] { "Id", "DepartmanName" },
                values: new object[] { 5, "Insan Kaynaks" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "ConcurrencyCheckColumn", "CreatedDate", "DepartmanId", "Midname", "Name", "NotMappedPropumuz", "Prim", "Salary", "Surname" },
                values: new object[] { 5, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "", "Ali", 0, 5f, 100f, "KK" });
        }
    }
}

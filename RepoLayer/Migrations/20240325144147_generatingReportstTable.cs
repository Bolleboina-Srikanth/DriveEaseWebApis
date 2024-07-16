using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepoLayer.Migrations
{
    public partial class generatingReportstTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "PaymentsTable",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "ReportTable",
                columns: table => new
                {
                    ReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(nullable: false),
                    CarBrand = table.Column<string>(nullable: true),
                    CarName = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    PresentDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    NoOfBookings = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportTable", x => x.ReportId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportTable");

            migrationBuilder.AlterColumn<long>(
                name: "Amount",
                table: "PaymentsTable",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}

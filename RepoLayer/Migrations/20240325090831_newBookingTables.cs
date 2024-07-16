using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepoLayer.Migrations
{
    public partial class newBookingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingsTable",
                columns: table => new
                {
                    BookingId = table.Column<string>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    CarBrand = table.Column<string>(nullable: true),
                    CarName = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    RentDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingsTable", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "CarsTable",
                columns: table => new
                {
                    CarID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarBrand = table.Column<string>(nullable: true),
                    CarName = table.Column<string>(nullable: true),
                    CarNumber = table.Column<string>(nullable: true),
                    Transmission = table.Column<string>(nullable: true),
                    Fuel = table.Column<string>(nullable: true),
                    CarColor = table.Column<string>(nullable: true),
                    Seating = table.Column<string>(nullable: true),
                    CarStatus = table.Column<string>(nullable: true),
                    PriceperHour = table.Column<decimal>(nullable: false),
                    PriceperDay = table.Column<decimal>(nullable: false),
                    CarPhoto = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsTable", x => x.CarID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentsTable",
                columns: table => new
                {
                    paymentId = table.Column<string>(nullable: false),
                    BookingId = table.Column<string>(nullable: true),
                    CarId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    paymentType = table.Column<string>(nullable: true),
                    paymmentDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentsTable", x => x.paymentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingsTable");

            migrationBuilder.DropTable(
                name: "CarsTable");

            migrationBuilder.DropTable(
                name: "PaymentsTable");
        }
    }
}

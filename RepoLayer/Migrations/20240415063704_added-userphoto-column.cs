using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepoLayer.Migrations
{
    public partial class addeduserphotocolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserPhoto",
                table: "UserTable",
                nullable: true);

           /* migrationBuilder.CreateTable(
                name: "OrdersTable",
                columns: table => new
                {
                    OrderID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(nullable: false),
                    usertableUserID = table.Column<long>(nullable: true),
                    BookingId = table.Column<string>(nullable: true),
                    BookingTableBookingId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CarPhoto = table.Column<string>(nullable: true),
                    CarBrand = table.Column<string>(nullable: true),
                    CarName = table.Column<string>(nullable: true),
                    Transmission = table.Column<string>(nullable: true),
                    Fuel = table.Column<string>(nullable: true),
                    CarColor = table.Column<string>(nullable: true),
                    Seating = table.Column<string>(nullable: true),
                    RentDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false),
                    BookingTime = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersTable", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_OrdersTable_BookingsTable_BookingTableBookingId",
                        column: x => x.BookingTableBookingId,
                        principalTable: "BookingsTable",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdersTable_UserTable_usertableUserID",
                        column: x => x.usertableUserID,
                        principalTable: "UserTable",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });*/

          /*  migrationBuilder.CreateIndex(
                name: "IX_OrdersTable_BookingTableBookingId",
                table: "OrdersTable",
                column: "BookingTableBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersTable_usertableUserID",
                table: "OrdersTable",
                column: "usertableUserID");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.DropTable(
                name: "OrdersTable");*/

            migrationBuilder.DropColumn(
                name: "UserPhoto",
                table: "UserTable");
        }
    }
}

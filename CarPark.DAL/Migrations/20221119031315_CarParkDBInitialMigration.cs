using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPark.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CarParkDBInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EmployeeAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmployeeBirthday = table.Column<DateTime>(type: "date", nullable: false),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeePhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "ParkingLots",
                columns: table => new
                {
                    ParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkArea = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ParkName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParkPlace = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ParkPrice = table.Column<int>(type: "int", nullable: false),
                    ParkStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLots", x => x.ParkId);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookedTicketNumber = table.Column<int>(type: "int", nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "date", nullable: false),
                    DepartureTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Driver = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    MaximumOnlineTicketNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    LicensePlate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CarColor = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.LicensePlate);
                    table.ForeignKey(
                        name: "FK_Cars_ParkingLots_ParkId",
                        column: x => x.ParkId,
                        principalTable: "ParkingLots",
                        principalColumn: "ParkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingOffices",
                columns: table => new
                {
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OfficePhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    OfficePlace = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OfficePrice = table.Column<int>(type: "int", nullable: false),
                    StartContractDeadline = table.Column<DateTime>(type: "date", nullable: false),
                    EndContractDeadline = table.Column<DateTime>(type: "date", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingOffices", x => x.OfficeId);
                    table.ForeignKey(
                        name: "FK_BookingOffices_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LicensePlate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TripId = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Cars_LicensePlate",
                        column: x => x.LicensePlate,
                        principalTable: "Cars",
                        principalColumn: "LicensePlate");
                    table.ForeignKey(
                        name: "FK_Tickets_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingOffices_TripId",
                table: "BookingOffices",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ParkId",
                table: "Cars",
                column: "ParkId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_LicensePlate",
                table: "Tickets",
                column: "LicensePlate");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TripId",
                table: "Tickets",
                column: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingOffices");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "ParkingLots");
        }
    }
}

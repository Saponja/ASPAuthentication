using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class createDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airplanes",
                columns: table => new
                {
                    AirplaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.AirplaneId);
                });

            migrationBuilder.CreateTable(
                name: "Passangers",
                columns: table => new
                {
                    PassangerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passangers", x => x.PassangerId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightDuration = table.Column<double>(type: "float", nullable: false),
                    AirplaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_Airplanes_AirplaneId",
                        column: x => x.AirplaneId,
                        principalTable: "Airplanes",
                        principalColumn: "AirplaneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AirplaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seats_Airplanes_AirplaneId",
                        column: x => x.AirplaneId,
                        principalTable: "Airplanes",
                        principalColumn: "AirplaneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    PassangerId = table.Column<int>(type: "int", nullable: false),
                    DateOfReservation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => new { x.SeatId, x.PassangerId, x.DateOfReservation });
                    table.ForeignKey(
                        name: "FK_Reservations_Passangers_PassangerId",
                        column: x => x.PassangerId,
                        principalTable: "Passangers",
                        principalColumn: "PassangerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "SeatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "AirplaneId", "Company", "Model", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Model1", "Airplane1" },
                    { 2, 5, "Model2", "Airplane2" },
                    { 3, 1, "Model1", "Airplane3" },
                    { 4, 2, "Model3", "Airplane4" },
                    { 5, 1, "Model2", "Airplane5" },
                    { 6, 3, "Model6", "Airplane6" }
                });

            migrationBuilder.InsertData(
                table: "Passangers",
                columns: new[] { "PassangerId", "Age", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 21, "Jovan", "Saponjic" },
                    { 2, 30, "Pera", "Peric" },
                    { 3, 45, "Zika", "Zikic" },
                    { 4, 17, "Milan", "Jovanovic" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Admin", "Email", "Password", "Username" },
                values: new object[,]
                {
                    { "0f8fad5b-d9cb-469f-a165-70867728950e", true, "pera@gmail.com", "pera123", "Pera" },
                    { "7c9e6679-7425-40de-944b-e07fc1f90ae7", false, "zika@gmail.com", "zika123", "Zika" }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "AirplaneId", "Destination", "FlightDuration" },
                values: new object[,]
                {
                    { 1, 1, "Mexico City", 17.0 },
                    { 7, 5, "Melbourne", 25.0 },
                    { 6, 5, "London", 8.0 },
                    { 5, 4, "Moscow", 6.0 },
                    { 3, 2, "Mexico City", 14.0 },
                    { 4, 3, "Madrid", 5.0 },
                    { 2, 1, "New York", 21.0 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "SeatId", "AirplaneId", "Class", "Price" },
                values: new object[,]
                {
                    { 3, 1, "Economy", 100.0 },
                    { 5, 2, "Business", 160.0 },
                    { 6, 2, "Economy", 90.0 },
                    { 7, 2, "Economy", 100.0 },
                    { 14, 6, "FirstClass", 225.0 },
                    { 8, 3, "FirstClass", 250.0 },
                    { 9, 3, "Business", 190.0 },
                    { 2, 1, "Business", 180.0 },
                    { 10, 4, "Economy", 80.0 },
                    { 11, 4, "Economy", 110.0 },
                    { 1, 1, "Business", 150.0 },
                    { 12, 5, "Business", 175.0 },
                    { 13, 5, "Economy", 120.0 },
                    { 4, 1, "FirstClass", 220.0 },
                    { 15, 6, "FirstClass", 240.0 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "DateOfReservation", "PassangerId", "SeatId" },
                values: new object[,]
                {
                    { new DateTime(2021, 2, 4, 19, 5, 42, 683, DateTimeKind.Local).AddTicks(1974), 1, 2 },
                    { new DateTime(2021, 2, 4, 19, 5, 42, 688, DateTimeKind.Local).AddTicks(9073), 2, 4 },
                    { new DateTime(2021, 2, 4, 19, 5, 42, 688, DateTimeKind.Local).AddTicks(9089), 4, 6 },
                    { new DateTime(2021, 2, 4, 19, 5, 42, 688, DateTimeKind.Local).AddTicks(9083), 3, 11 },
                    { new DateTime(2021, 2, 4, 19, 5, 42, 688, DateTimeKind.Local).AddTicks(8980), 1, 14 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirplaneId",
                table: "Flights",
                column: "AirplaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PassangerId",
                table: "Reservations",
                column: "PassangerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SeatId",
                table: "Reservations",
                column: "SeatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_AirplaneId",
                table: "Seats",
                column: "AirplaneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Passangers");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Airplanes");
        }
    }
}

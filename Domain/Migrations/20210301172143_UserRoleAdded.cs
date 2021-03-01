using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class UserRoleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumns: new[] { "DateOfReservation", "PassangerId", "SeatId" },
                keyValues: new object[] { new DateTime(2021, 2, 4, 19, 5, 42, 683, DateTimeKind.Local).AddTicks(1974), 1, 2 });

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumns: new[] { "DateOfReservation", "PassangerId", "SeatId" },
                keyValues: new object[] { new DateTime(2021, 2, 4, 19, 5, 42, 688, DateTimeKind.Local).AddTicks(9073), 2, 4 });

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumns: new[] { "DateOfReservation", "PassangerId", "SeatId" },
                keyValues: new object[] { new DateTime(2021, 2, 4, 19, 5, 42, 688, DateTimeKind.Local).AddTicks(9089), 4, 6 });

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumns: new[] { "DateOfReservation", "PassangerId", "SeatId" },
                keyValues: new object[] { new DateTime(2021, 2, 4, 19, 5, 42, 688, DateTimeKind.Local).AddTicks(9083), 3, 11 });

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumns: new[] { "DateOfReservation", "PassangerId", "SeatId" },
                keyValues: new object[] { new DateTime(2021, 2, 4, 19, 5, 42, 688, DateTimeKind.Local).AddTicks(8980), 1, 14 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "0f8fad5b-d9cb-469f-a165-70867728950e");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7c9e6679-7425-40de-944b-e07fc1f90ae7");

            migrationBuilder.DropColumn(
                name: "Admin",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "DateOfReservation", "PassangerId", "SeatId" },
                values: new object[,]
                {
                    { new DateTime(2021, 3, 1, 18, 21, 42, 518, DateTimeKind.Local).AddTicks(8535), 1, 2 },
                    { new DateTime(2021, 3, 1, 18, 21, 42, 528, DateTimeKind.Local).AddTicks(9157), 1, 14 },
                    { new DateTime(2021, 3, 1, 18, 21, 42, 528, DateTimeKind.Local).AddTicks(9250), 2, 4 },
                    { new DateTime(2021, 3, 1, 18, 21, 42, 528, DateTimeKind.Local).AddTicks(9260), 3, 11 },
                    { new DateTime(2021, 3, 1, 18, 21, 42, 528, DateTimeKind.Local).AddTicks(9266), 4, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumns: new[] { "DateOfReservation", "PassangerId", "SeatId" },
                keyValues: new object[] { new DateTime(2021, 3, 1, 18, 21, 42, 518, DateTimeKind.Local).AddTicks(8535), 1, 2 });

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumns: new[] { "DateOfReservation", "PassangerId", "SeatId" },
                keyValues: new object[] { new DateTime(2021, 3, 1, 18, 21, 42, 528, DateTimeKind.Local).AddTicks(9250), 2, 4 });

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumns: new[] { "DateOfReservation", "PassangerId", "SeatId" },
                keyValues: new object[] { new DateTime(2021, 3, 1, 18, 21, 42, 528, DateTimeKind.Local).AddTicks(9266), 4, 6 });

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumns: new[] { "DateOfReservation", "PassangerId", "SeatId" },
                keyValues: new object[] { new DateTime(2021, 3, 1, 18, 21, 42, 528, DateTimeKind.Local).AddTicks(9260), 3, 11 });

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumns: new[] { "DateOfReservation", "PassangerId", "SeatId" },
                keyValues: new object[] { new DateTime(2021, 3, 1, 18, 21, 42, 528, DateTimeKind.Local).AddTicks(9157), 1, 14 });

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "DateOfReservation", "PassangerId", "SeatId" },
                values: new object[,]
                {
                    { new DateTime(2021, 2, 4, 19, 5, 42, 683, DateTimeKind.Local).AddTicks(1974), 1, 2 },
                    { new DateTime(2021, 2, 4, 19, 5, 42, 688, DateTimeKind.Local).AddTicks(8980), 1, 14 },
                    { new DateTime(2021, 2, 4, 19, 5, 42, 688, DateTimeKind.Local).AddTicks(9073), 2, 4 },
                    { new DateTime(2021, 2, 4, 19, 5, 42, 688, DateTimeKind.Local).AddTicks(9083), 3, 11 },
                    { new DateTime(2021, 2, 4, 19, 5, 42, 688, DateTimeKind.Local).AddTicks(9089), 4, 6 }
                });
        }
    }
}

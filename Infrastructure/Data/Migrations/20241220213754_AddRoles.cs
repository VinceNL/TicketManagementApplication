using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a1b2c3d4-e5f6-7890-abcd-ef1234567890", null, "User", "USER" },
                    { "d3b07384-d9a0-4c8b-8b0d-2f3b8b6e0a1e", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountConfirmed", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isDeleted" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", 0, false, null, "9d166e6b-f175-4641-89bb-607e2eb68cde", "test@gmail.com", true, false, null, "TEST@GMAIL.COM", "TEST@GMAIL.COM", "AQAAAAIAAYagAAAAEDf7cWxDq6No/Hg1Fkf8r+BxO2TB9+GZ6VtK5umAEpbJwJ/vnA2Wrcm8KCzgVNH3FA==", null, false, "9a3b5a38-0778-4b3d-affe-7a5b59d1366b", false, "test@gmail.com", false });

            migrationBuilder.UpdateData(
                table: "Priorities",
                keyColumn: "PriorityId",
                keyValue: 1,
                column: "ExpectedDays",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Priorities",
                keyColumn: "PriorityId",
                keyValue: 2,
                column: "ExpectedDays",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Priorities",
                keyColumn: "PriorityId",
                keyValue: 3,
                column: "ExpectedDays",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 9,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 10,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 11,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 12,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 13,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 14,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 15,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 16,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 17,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 18,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 19,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 20,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 21,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 22,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 23,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 24,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 25,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 26,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 27,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 28,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 29,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 30,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 31,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 32,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 33,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 34,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 35,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 36,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 37,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 38,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 39,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 40,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 41,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 42,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 43,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 44,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 45,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 46,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 47,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 48,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 49,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 50,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 51,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 52,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 53,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 54,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 55,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 56,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 57,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 58,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 59,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 60,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d3b07384-d9a0-4c8b-8b0d-2f3b8b6e0a1e", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "AssignedToId", "CategoryId", "ClosedBy", "ClosedDate", "Description", "ExpectedDate", "LastUpdateDate", "PriorityId", "ProductId", "RaisedBy", "RaisedDate", "Status", "Summary" },
                values: new object[,]
                {
                    { 61, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", 2, null, null, "Description for ticket 61", new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 61" },
                    { 62, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", 3, null, null, "Description for ticket 62", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", "Sample ticket 62" },
                    { 63, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", 1, null, null, "Description for ticket 63", new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 63" },
                    { 64, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", 2, null, null, "Description for ticket 64", new DateTime(2024, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", "Sample ticket 64" },
                    { 65, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", 3, null, null, "Description for ticket 65", new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 65" },
                    { 66, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", 1, null, null, "Description for ticket 66", new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 2, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", "Sample ticket 66" },
                    { 67, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", 2, null, null, "Description for ticket 67", new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 67" },
                    { 68, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", 3, null, null, "Description for ticket 68", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", "Sample ticket 68" },
                    { 69, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", 1, null, null, "Description for ticket 69", new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 69" },
                    { 70, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", 2, null, null, "Description for ticket 70", new DateTime(2024, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", "Sample ticket 70" },
                    { 71, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", 3, null, null, "Description for ticket 71", new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 71" },
                    { 72, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", 1, null, null, "Description for ticket 72", new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 2, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", "Sample ticket 72" },
                    { 73, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", 2, null, null, "Description for ticket 73", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 73" },
                    { 74, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", 3, null, null, "Description for ticket 74", new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", "Sample ticket 74" },
                    { 75, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", 1, null, null, "Description for ticket 75", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1, "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 75" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7890-abcd-ef1234567890");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d3b07384-d9a0-4c8b-8b0d-2f3b8b6e0a1e", "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c" });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3b07384-d9a0-4c8b-8b0d-2f3b8b6e0a1e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountConfirmed", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f913664c-8c15-4da8-977b-fce1df2e0d16", 0, false, null, "82484742-1d19-4162-8fb8-51d1c3b1b901", "test@gmail.com", true, false, null, "TEST@GMAIL.COM", "TEST@GMAIL.COM", "AQAAAAIAAYagAAAAEOm64z3pTF9zSaocCTpbiDpx2ADowcuLuqmwCkISo8RbZEAE/c87OXbGyPBVDc/0bg==", null, false, "89a625c4-f116-4d6d-9deb-20452d1a8afa", false, "test@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Priorities",
                keyColumn: "PriorityId",
                keyValue: 1,
                column: "ExpectedDays",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Priorities",
                keyColumn: "PriorityId",
                keyValue: 2,
                column: "ExpectedDays",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Priorities",
                keyColumn: "PriorityId",
                keyValue: 3,
                column: "ExpectedDays",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 9,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 10,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 11,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 12,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 13,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 14,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 15,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 16,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 17,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 18,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 19,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 20,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 21,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 22,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 23,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 24,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 25,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 26,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 27,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 28,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 29,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 30,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 31,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 32,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 33,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 34,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 35,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 36,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 37,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 38,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 39,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 40,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 41,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 42,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 43,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 44,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 45,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 46,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 47,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 48,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 49,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 50,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 51,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 52,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 53,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 54,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 55,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 56,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 57,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 58,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 59,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 60,
                columns: new[] { "AssignedToId", "RaisedBy" },
                values: new object[] { null, "f913664c-8c15-4da8-977b-fce1df2e0d16" });
        }
    }
}

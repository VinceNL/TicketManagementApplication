using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClosedByTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_AssignedToId",
                table: "Tickets");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RaisedBy",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedToId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ClosedBy",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedDate",
                table: "Tickets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Tickets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountConfirmed", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8c6afcfa-3695-4178-b8bf-6996395744a9", 0, false, null, "04e302b5-c76f-40fd-b5cc-79227774df3d", "test@gmail.com", true, false, null, "TEST@GMAIL.COM", "TEST@GMAIL.COM", "AQAAAAIAAYagAAAAEL3M0eToTSYO2Ekvz8CkMZkpKWH6FR/uKCKTRfdiqdBUPVJnHkoHcFJxWM213sa3rQ==", null, false, "f5bdab8c-4672-46d7-adc3-4266741f0ac3", false, "test@gmail.com" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Application Bug" },
                    { 2, "Network Issue" },
                    { 3, "Feature Request" }
                });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "PriorityId", "ExpectedDays", "PriorityName" },
                values: new object[,]
                {
                    { 1, 0, "Low" },
                    { 2, 0, "Medium" },
                    { 3, 0, "High" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductName" },
                values: new object[,]
                {
                    { 1, "Product 1" },
                    { 2, "Product 2" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "AssignedToId", "CategoryId", "ClosedBy", "ClosedDate", "Description", "ExpectedDate", "LastUpdateDate", "PriorityId", "ProductId", "RaisedBy", "RaisedDate", "Status", "Summary" },
                values: new object[,]
                {
                    { 1, null, 1, null, null, "Description for ticket 1", new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 1" },
                    { 2, null, 2, null, null, "Description for ticket 2", new DateTime(2024, 9, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 2" },
                    { 3, null, 3, null, null, "Description for ticket 3", new DateTime(2024, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 3" },
                    { 4, null, 1, null, null, "Description for ticket 4", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 4" },
                    { 5, null, 2, null, null, "Description for ticket 5", new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 5" },
                    { 6, null, 3, null, null, "Description for ticket 6", new DateTime(2024, 9, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 6" },
                    { 7, null, 1, null, null, "Description for ticket 7", new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 7" },
                    { 8, null, 2, null, null, "Description for ticket 8", new DateTime(2024, 9, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 8" },
                    { 9, null, 3, null, null, "Description for ticket 9", new DateTime(2024, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 9" },
                    { 10, null, 1, null, null, "Description for ticket 10", new DateTime(2024, 9, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 10" },
                    { 11, null, 2, null, null, "Description for ticket 11", new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 11" },
                    { 12, null, 3, null, null, "Description for ticket 12", new DateTime(2024, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW", "Sample ticket 12" },
                    { 13, null, 1, null, null, "Description for ticket 13", new DateTime(2024, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", "Sample ticket 13" },
                    { 14, null, 2, null, null, "Description for ticket 14", new DateTime(2024, 9, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", "Sample ticket 14" },
                    { 15, null, 3, null, null, "Description for ticket 15", new DateTime(2024, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", "Sample ticket 15" },
                    { 16, null, 1, null, null, "Description for ticket 16", new DateTime(2024, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", "Sample ticket 16" },
                    { 17, null, 2, null, null, "Description for ticket 17", new DateTime(2024, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", "Sample ticket 17" },
                    { 18, null, 3, null, null, "Description for ticket 18", new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", "Sample ticket 18" },
                    { 19, null, 1, null, null, "Description for ticket 19", new DateTime(2024, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", "Sample ticket 19" },
                    { 20, null, 2, null, null, "Description for ticket 20", new DateTime(2024, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", "Sample ticket 20" },
                    { 21, null, 3, null, null, "Description for ticket 21", new DateTime(2024, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", "Sample ticket 21" },
                    { 22, null, 1, null, null, "Description for ticket 22", new DateTime(2024, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", "Sample ticket 22" },
                    { 23, null, 2, null, null, "Description for ticket 23", new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", "Sample ticket 23" },
                    { 24, null, 3, null, null, "Description for ticket 24", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 24" },
                    { 25, null, 1, null, null, "Description for ticket 25", new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 25" },
                    { 26, null, 2, null, null, "Description for ticket 26", new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 26" },
                    { 27, null, 3, null, null, "Description for ticket 27", new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 27" },
                    { 28, null, 1, null, null, "Description for ticket 28", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 28" },
                    { 29, null, 2, null, null, "Description for ticket 29", new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 29" },
                    { 30, null, 3, null, null, "Description for ticket 30", new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 30" },
                    { 31, null, 1, null, null, "Description for ticket 31", new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 31" },
                    { 32, null, 2, null, null, "Description for ticket 32", new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 32" },
                    { 33, null, 3, null, null, "Description for ticket 33", new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 33" },
                    { 34, null, 1, null, null, "Description for ticket 34", new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 34" },
                    { 35, null, 2, null, null, "Description for ticket 35", new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 35" },
                    { 36, null, 3, null, null, "Description for ticket 36", new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 36" },
                    { 37, null, 1, null, null, "Description for ticket 37", new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 37" },
                    { 38, null, 2, null, null, "Description for ticket 38", new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 38" },
                    { 39, null, 3, null, null, "Description for ticket 39", new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 39" },
                    { 40, null, 1, null, null, "Description for ticket 40", new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 40" },
                    { 41, null, 2, null, null, "Description for ticket 41", new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 41" },
                    { 42, null, 3, null, null, "Description for ticket 42", new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 42" },
                    { 43, null, 1, null, null, "Description for ticket 43", new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 43" },
                    { 44, null, 2, null, null, "Description for ticket 44", new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 44" },
                    { 45, null, 3, null, null, "Description for ticket 45", new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 45" },
                    { 46, null, 2, null, null, "Description for ticket 46", new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 46" },
                    { 47, null, 3, null, null, "Description for ticket 47", new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 47" },
                    { 48, null, 1, null, null, "Description for ticket 48", new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 48" },
                    { 49, null, 2, null, null, "Description for ticket 49", new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 49" },
                    { 50, null, 3, null, null, "Description for ticket 50", new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 50" },
                    { 51, null, 1, null, null, "Description for ticket 51", new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 51" },
                    { 52, null, 2, null, null, "Description for ticket 52", new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 52" },
                    { 53, null, 3, null, null, "Description for ticket 53", new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 53" },
                    { 54, null, 1, null, null, "Description for ticket 54", new DateTime(2024, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 54" },
                    { 55, null, 2, null, null, "Description for ticket 55", new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 55" },
                    { 56, null, 3, null, null, "Description for ticket 56", new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 56" },
                    { 57, null, 1, null, null, "Description for ticket 57", new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 57" },
                    { 58, null, 2, null, null, "Description for ticket 58", new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 58" },
                    { 59, null, 3, null, null, "Description for ticket 59", new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 59" },
                    { 60, null, 1, null, null, "Description for ticket 60", new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 2, "8c6afcfa-3695-4178-b8bf-6996395744a9", new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLOSED", "Sample ticket 60" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_AssignedToId",
                table: "Tickets",
                column: "AssignedToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_AssignedToId",
                table: "Tickets");

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c6afcfa-3695-4178-b8bf-6996395744a9");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "PriorityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "PriorityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "PriorityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ClosedBy",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ClosedDate",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "Tickets");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RaisedBy",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AssignedToId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_AssignedToId",
                table: "Tickets",
                column: "AssignedToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

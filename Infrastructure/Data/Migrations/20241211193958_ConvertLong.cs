using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConvertLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_AssignedToId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_RaisedBy",
                table: "Tickets");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "Attachments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountConfirmed", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f913664c-8c15-4da8-977b-fce1df2e0d16", 0, false, null, "82484742-1d19-4162-8fb8-51d1c3b1b901", "test@gmail.com", true, false, null, "TEST@GMAIL.COM", "TEST@GMAIL.COM", "AQAAAAIAAYagAAAAEOm64z3pTF9zSaocCTpbiDpx2ADowcuLuqmwCkISo8RbZEAE/c87OXbGyPBVDc/0bg==", null, false, "89a625c4-f116-4d6d-9deb-20452d1a8afa", false, "test@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 9,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 10,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 11,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 12,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 13,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 14,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 15,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 16,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 17,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 18,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 19,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 20,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 21,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 22,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 23,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 24,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 25,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 26,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 27,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 28,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 29,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 30,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 31,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 32,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 33,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 34,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 35,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 36,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 37,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 38,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 39,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 40,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 41,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 42,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 43,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 44,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 45,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 46,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 47,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 48,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 49,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 50,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 51,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 52,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 53,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 54,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 55,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 56,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 57,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 58,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 59,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 60,
                column: "RaisedBy",
                value: "f913664c-8c15-4da8-977b-fce1df2e0d16");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f913664c-8c15-4da8-977b-fce1df2e0d16");

            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "Attachments",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountConfirmed", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "53db9d6d-e08f-4244-883f-20c81b929a55", 0, false, null, "d29382c2-5b68-4f9f-87f1-a92a5d422685", "test@gmail.com", true, false, null, "TEST@GMAIL.COM", "TEST@GMAIL.COM", "AQAAAAIAAYagAAAAEJkZz9P53cMuVWz0r0x5+vYiR+LYRuJEXFZ0Uhp5rEQMNHXzsUHNYf1D9DHk9tOUsw==", null, false, "2d7c8bfd-c15a-4b3f-a411-72e2218b4170", false, "test@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 9,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 10,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 11,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 12,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 13,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 14,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 15,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 16,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 17,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 18,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 19,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 20,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 21,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 22,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 23,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 24,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 25,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 26,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 27,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 28,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 29,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 30,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 31,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 32,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 33,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 34,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 35,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 36,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 37,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 38,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 39,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 40,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 41,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 42,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 43,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 44,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 45,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 46,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 47,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 48,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 49,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 50,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 51,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 52,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 53,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 54,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 55,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 56,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 57,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 58,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 59,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 60,
                column: "RaisedBy",
                value: "53db9d6d-e08f-4244-883f-20c81b929a55");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_AssignedToId",
                table: "Tickets",
                column: "AssignedToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_RaisedBy",
                table: "Tickets",
                column: "RaisedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

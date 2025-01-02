using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class NullableFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_AspNetUsers_UserId",
                table: "Discussions");

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Discussions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Discussions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45663211-fa1f-4101-9349-0d72d213f50c", "AQAAAAIAAYagAAAAEKR/Y37mG7zsI/VLmSrR+FqtNg3FR8Ze3xL29l86RukyOUsvzmoIy7t4VW97C5f8uA==", "9ee739a9-8818-4f23-a3b8-02c9fbcae75f" });

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_AspNetUsers_UserId",
                table: "Discussions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_AspNetUsers_UserId",
                table: "Discussions");

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Discussions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Discussions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d166e6b-f175-4641-89bb-607e2eb68cde", "AQAAAAIAAYagAAAAEDf7cWxDq6No/Hg1Fkf8r+BxO2TB9+GZ6VtK5umAEpbJwJ/vnA2Wrcm8KCzgVNH3FA==", "9a3b5a38-0778-4b3d-affe-7a5b59d1366b" });

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_AspNetUsers_UserId",
                table: "Discussions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

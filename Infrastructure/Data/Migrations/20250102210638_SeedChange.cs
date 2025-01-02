using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c",
                columns: new[] { "AccountConfirmed", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { true, "6e299689-dcb0-4af9-baf5-960240b485cb", "AQAAAAIAAYagAAAAEA9E8c3UkmIIfPnbRTFksYi816wZdYvU33eU5AawnEsnog6/CbMQE/QS25HxZm6oGw==", "870fd7ce-cf2e-4b7f-b24b-3e2e66b2cbff" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3fa6a5d-ff0d-4ea6-a2b5-f9ce7e77b36c",
                columns: new[] { "AccountConfirmed", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { false, "45663211-fa1f-4101-9349-0d72d213f50c", "AQAAAAIAAYagAAAAEKR/Y37mG7zsI/VLmSrR+FqtNg3FR8Ze3xL29l86RukyOUsvzmoIy7t4VW97C5f8uA==", "9ee739a9-8818-4f23-a3b8-02c9fbcae75f" });
        }
    }
}

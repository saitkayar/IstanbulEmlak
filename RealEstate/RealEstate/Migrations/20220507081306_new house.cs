using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Migrations
{
    public partial class newhouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "DistrictId", "Image", "LocationId", "Price", "RoomNumber", "Square", "StatusId", "Title" },
                values: new object[,]
                {
                    { 3, null, null, 3, 1150000, 5, 120, 1, "Ucuz Ev" },
                    { 4, null, null, 4, 1150000, 5, 120, 1, "Ucuz Ev" },
                    { 5, null, null, 5, 1150000, 5, 120, 2, "Ucuz Ev" },
                    { 6, null, null, 6, 1150000, 5, 120, 1, "Ucuz Ev" },
                    { 7, null, null, 7, 1150000, 5, 120, 1, "Ucuz Ev" },
                    { 8, null, null, 8, 1150000, 5, 120, 2, "Ucuz Ev" },
                    { 9, null, null, 9, 1150000, 5, 120, 2, "Ucuz Ev" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}

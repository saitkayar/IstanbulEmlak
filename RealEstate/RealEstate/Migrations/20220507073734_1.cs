using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Statu = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Square = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Houses_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "LocationName" },
                values: new object[,]
                {
                    { 1, "Üsküdar" },
                    { 2, "Ümraniye" },
                    { 3, "Kadıköy" },
                    { 4, "Maltepe" },
                    { 5, "Bağcılar" },
                    { 6, "Adalar" },
                    { 7, "Arnavutköy" },
                    { 8, "Ataşehir" },
                    { 9, "Avcılar" },
                    { 10, "Bahçelievler" },
                    { 11, "Bakırköy" },
                    { 12, "Başakşehir" },
                    { 13, "Bayrampaşa" },
                    { 14, "Beşiktaş" },
                    { 15, "Beykoz" },
                    { 16, "Beylikdüzü" },
                    { 17, "Beyoğlu" },
                    { 18, "Büyükçekmece" },
                    { 19, "Çatalca" },
                    { 20, "Çekmeköy" },
                    { 21, "Esenler" },
                    { 22, "Esenyurt" },
                    { 23, "Eyüpsultan" },
                    { 24, "Fatih" },
                    { 25, "Gaziosmanpaşa" },
                    { 26, "Güngören" },
                    { 27, "Küçükçekmece" },
                    { 28, "Kağıthane" },
                    { 29, "Kartal" },
                    { 30, "Pendik" },
                    { 31, "Sancaktepe" },
                    { 32, "Sarıyer" },
                    { 33, "Silivri" },
                    { 34, "Sultanbeyli" },
                    { 35, "Sultangazi" },
                    { 36, "Şile" },
                    { 37, "Şişli" },
                    { 38, "Tuzla" },
                    { 39, "Zeytinburnu" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "RoleName" },
                values: new object[,]
                {
                    { 1, "PasifKullanıcı" },
                    { 2, "AktifKullanıcı" },
                    { 3, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "RoleName" },
                values: new object[] { 4, "Supervisor" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Statu" },
                values: new object[] { 1, "Kiralık" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Statu" },
                values: new object[] { 2, "Satılık" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "DistrictId", "Image", "LocationId", "Price", "RoomNumber", "Square", "StatusId", "Title" },
                values: new object[,]
                {
                    { 1, null, null, 1, 9000, 3, 100, 1, "Güzel Ev" },
                    { 2, null, null, 2, 1150000, 5, 120, 2, "Ucuz Ev" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "Password", "RoleID", "UserName" },
                values: new object[,]
                {
                    { 1, "admin@test.com", "test123", 3, "Admin" },
                    { 2, "aktif@test.com", "test123", 2, "aktif" },
                    { 3, "pasif@test.com", "test123", 1, "pasif" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Houses_DistrictId",
                table: "Houses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_StatusId",
                table: "Houses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

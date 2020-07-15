using Microsoft.EntityFrameworkCore.Migrations;

namespace BoatProject.Migrations
{
    public partial class ThirdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentedBoat");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Boats",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRented",
                table: "Boats",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReturned",
                table: "Boats",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Boats");

            migrationBuilder.DropColumn(
                name: "IsRented",
                table: "Boats");

            migrationBuilder.DropColumn(
                name: "IsReturned",
                table: "Boats");

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRented = table.Column<bool>(type: "bit", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentedBoat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoatId = table.Column<int>(type: "int", nullable: false),
                    RentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentedBoat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentedBoat_Boats_BoatId",
                        column: x => x.BoatId,
                        principalTable: "Boats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentedBoat_Rents_RentId",
                        column: x => x.RentId,
                        principalTable: "Rents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentedBoat_BoatId",
                table: "RentedBoat",
                column: "BoatId");

            migrationBuilder.CreateIndex(
                name: "IX_RentedBoat_RentId",
                table: "RentedBoat",
                column: "RentId");
        }
    }
}

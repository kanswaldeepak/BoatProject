using Microsoft.EntityFrameworkCore.Migrations;

namespace BoatProject.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentedBoatDetail_Boats_BoatId",
                table: "RentedBoatDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_RentedBoatDetail_RentDetail_RentId",
                table: "RentedBoatDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentedBoatDetail",
                table: "RentedBoatDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentDetail",
                table: "RentDetail");

            migrationBuilder.RenameTable(
                name: "RentedBoatDetail",
                newName: "RentedBoat");

            migrationBuilder.RenameTable(
                name: "RentDetail",
                newName: "Rents");

            migrationBuilder.RenameIndex(
                name: "IX_RentedBoatDetail_RentId",
                table: "RentedBoat",
                newName: "IX_RentedBoat_RentId");

            migrationBuilder.RenameIndex(
                name: "IX_RentedBoatDetail_BoatId",
                table: "RentedBoat",
                newName: "IX_RentedBoat_BoatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentedBoat",
                table: "RentedBoat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rents",
                table: "Rents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentedBoat_Boats_BoatId",
                table: "RentedBoat",
                column: "BoatId",
                principalTable: "Boats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentedBoat_Rents_RentId",
                table: "RentedBoat",
                column: "RentId",
                principalTable: "Rents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentedBoat_Boats_BoatId",
                table: "RentedBoat");

            migrationBuilder.DropForeignKey(
                name: "FK_RentedBoat_Rents_RentId",
                table: "RentedBoat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rents",
                table: "Rents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentedBoat",
                table: "RentedBoat");

            migrationBuilder.RenameTable(
                name: "Rents",
                newName: "RentDetail");

            migrationBuilder.RenameTable(
                name: "RentedBoat",
                newName: "RentedBoatDetail");

            migrationBuilder.RenameIndex(
                name: "IX_RentedBoat_RentId",
                table: "RentedBoatDetail",
                newName: "IX_RentedBoatDetail_RentId");

            migrationBuilder.RenameIndex(
                name: "IX_RentedBoat_BoatId",
                table: "RentedBoatDetail",
                newName: "IX_RentedBoatDetail_BoatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentDetail",
                table: "RentDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentedBoatDetail",
                table: "RentedBoatDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentedBoatDetail_Boats_BoatId",
                table: "RentedBoatDetail",
                column: "BoatId",
                principalTable: "Boats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentedBoatDetail_RentDetail_RentId",
                table: "RentedBoatDetail",
                column: "RentId",
                principalTable: "RentDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

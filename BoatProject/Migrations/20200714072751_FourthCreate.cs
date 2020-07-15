using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoatProject.Migrations
{
    public partial class FourthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RentEnd",
                table: "Boats",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RentStart",
                table: "Boats",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RentTime",
                table: "Boats",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentEnd",
                table: "Boats");

            migrationBuilder.DropColumn(
                name: "RentStart",
                table: "Boats");

            migrationBuilder.DropColumn(
                name: "RentTime",
                table: "Boats");
        }
    }
}

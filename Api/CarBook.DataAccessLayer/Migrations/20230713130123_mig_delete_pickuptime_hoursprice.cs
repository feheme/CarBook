using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.DataAccessLayer.Migrations
{
    public partial class mig_delete_pickuptime_hoursprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickUpTime",
                table: "RentCars");

            migrationBuilder.DropColumn(
                name: "HourPrice",
                table: "Details");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PickUpTime",
                table: "RentCars",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HourPrice",
                table: "Details",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}

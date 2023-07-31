using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.DataAccessLayer.Migrations
{
    public partial class mig_add_car : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarName",
                table: "RentCars",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "Car",
                table: "RentCars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "RentCars",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Car",
                table: "RentCars");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "RentCars");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "RentCars",
                newName: "CarName");
        }
    }
}

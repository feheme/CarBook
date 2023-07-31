using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.DataAccessLayer.Migrations
{
    public partial class mig_add_carname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarName",
                table: "RentCars",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarName",
                table: "RentCars");
        }
    }
}

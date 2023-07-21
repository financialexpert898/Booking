using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Migrations
{
    public partial class innit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "RoomTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);
            migrationBuilder.DropColumn(
                name: "Sophong",
                table: "Rooms"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Rooms");
            migrationBuilder.AddColumn<int>(
                name: "Sophong",
                table: "Rooms"
                );
        }
    }
}
